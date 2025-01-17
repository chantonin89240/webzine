﻿namespace Webzine.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using Webzine.EntitiesContext;
    using Microsoft.EntityFrameworkCore;
    using Webzine.Repository.Contracts;
    using Webzine.Entity;

    public class DbTitreRepository : ITitreRepository
    {
        private WebzineDbContext _context;
        public DbTitreRepository(WebzineDbContext context){
            this._context = context;
        }

        public void Add(Titre titre)
        {
            // titre.Artiste = null;
            // context.Entry(titre.Artiste).State = EntityState.Modified;
            titre.DateCreation = DateTime.Now;
            this._context.Titres.Add(titre);
            this._context.SaveChanges();
        }

        public void AddStyles(Titre titre, List<string> listeStyles)
        {   
            listeStyles.ForEach(style =>
                this._context.TitresStyles.Add(new TitreStyle(){
                    IdTitre = titre.IdTitre,
                    IdStyle = Int32.Parse(style),
                }));
            this._context.SaveChanges();
        }

        public int Count()
        {
            return this._context.Titres.Count();
        }

        public void Delete(Titre titre)
        {
            this._context.Titres.Remove(titre);
            this._context.SaveChanges();
        }

        public Titre Find(int idTitre)
        {
            var titre = this._context.Titres
                .Include(t => t.Artiste)
                .Include(t => t.Commentaires)
                .Include(t => t.TitresStyles)
                .ThenInclude(ts => ts.Style)
                .FirstOrDefault(t => t.IdTitre == idTitre);

            return titre;
        }

        public IEnumerable<Titre> FindAll()
        {   
            var titres = this._context.Titres
                .Include(t => t.Artiste)
                .Include(t => t.Commentaires)
                .Include(t => t.TitresStyles)
                .ThenInclude(ts => ts.Style);

            return titres;
        }

        public IEnumerable<Titre> FindTitres(int offset, int limit)
        {
            try
            {
                var titres = this._context.Titres.OrderByDescending(t => t.DateCreation).Skip(offset);
                titres = titres
                    .Include(t => t.Artiste)
                    .Include(t => t.TitresStyles)
                    .ThenInclude(ts => ts.Style);
                if (titres.ToList().Count() < limit)
                {
                    return titres;
                }
                else
                {
                    return titres.Take(limit);
                }
            }
            catch
            {
                return new List<Titre>();
            }
        }

        public void IncrementNbLectures(Titre titre)
        {
            int nbTotal = this._context.Titres.FirstOrDefault(t => t == titre).NbLectures + 1;
            this._context.Titres.FirstOrDefault(t => t == titre).NbLectures = nbTotal;
            this._context.Titres.Update(titre);
            this._context.SaveChanges();
        }

        public void DecrementNbLectures(Titre titre)
        {
            int nbTotal = this._context.Titres.FirstOrDefault(t => t == titre).NbLectures - 1;

            if(nbTotal > 0)
            {
                this._context.Titres.FirstOrDefault(t => t == titre).NbLectures = nbTotal;
                this._context.Titres.Update(titre);
                this._context.SaveChanges();
            }
        }

        public void IncrementNbLikes(Titre titre)
        {
            int nbTotal = this._context.Titres.FirstOrDefault(t => t == titre).NbLikes + 1;
            this._context.Titres.FirstOrDefault(t => t == titre).NbLikes = nbTotal;
            this._context.Titres.Update(titre);
            this._context.SaveChanges();
        }

        public IEnumerable<Titre> Search(string mot)
        {
            var titres = this._context.Titres.Where(t => t.Libelle.Contains(mot));
            return titres;
        }


        public IEnumerable<Titre> SearchByStyle(string libelle)
        {
            string decoded = System.Net.WebUtility.UrlDecode(libelle);
            if (!this._context.Styles.ToList().Exists(s => s.Libelle == decoded))
            {
                return Enumerable.Empty<Titre>();
            }

            var idStyle = this._context.Styles.FirstOrDefault(s => s.Libelle == decoded).IdStyle;
            var titres = this.FindAll().Where(t => t.TitresStyles.ToList().Exists(ts => ts.IdStyle == idStyle));
            return titres;
        }

        public void Update(Titre titre)
        {
            this._context.Titres.Update(titre);

            this._context.Entry(titre).State = EntityState.Modified;
            this._context.SaveChanges();
        }

        public void UpdateStyles(int idTitre, List<string> listRemove, List<string> listAdd)
        {
            listAdd.ForEach(style =>
                this._context.TitresStyles.Add(new TitreStyle(){
                    IdStyle = Int32.Parse(style),
                    IdTitre = idTitre,
                }));

            listRemove.ForEach(style =>
                this._context.TitresStyles.Remove(new TitreStyle(){
                    IdStyle = Int32.Parse(style),
                    IdTitre = idTitre,
                }));
            this._context.SaveChanges();
        }
    }
}
