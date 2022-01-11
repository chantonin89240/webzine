namespace Webzine.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using Webzine.EntitiesContext;
    using Microsoft.EntityFrameworkCore;
    using Webzine.Repository.Contracts;
    using Webzine.Entity;

    public class DbTitreRepository : ITitreRepository
    {
        private WebzineDbContext context = new WebzineDbContext();
        public void Add(Titre titre)
        {
            // titre.Artiste = null;
            // context.Entry(titre.Artiste).State = EntityState.Modified;
            titre.DateCreation = DateTime.Now;
            this.context.Titres.Add(titre);
            context.SaveChanges();
        }

        public void AddStyles(Titre titre, List<string> listeStyles)
        {   
            listeStyles.ForEach(style =>
                this.context.TitreStyles.Add(new TitreStyle(){
                    IdTitre = titre.IdTitre,
                    IdStyle = Int32.Parse(style),
                }));
            context.SaveChanges();
        }

        public int Count()
        {
            return this.context.Titres.Count();
        }

        public void Delete(Titre titre)
        {
            this.context.Titres.Remove(titre);
            this.context.SaveChanges();
        }

        public Titre Find(int idTitre)
        {
            var titre = this.context.Titres.FirstOrDefault(t => t.IdTitre == idTitre);
            titre.Artiste = this.context.Artistes.FirstOrDefault(a => a.IdArtiste == titre.IdArtiste);
            titre.TitresStyles = this.context.TitreStyles.Where(s => s.IdTitre == titre.IdTitre).ToList();
            return titre;
        }

        public IEnumerable<Titre> FindAll()
        {
            var titres = this.context.Titres
            .Include(t => t.TitresStyles)
            .ThenInclude(ts => ts.Style)
            .Include(t => t.Artiste)
            .Include(t => t.Commentaires);
            return titres;
        }

        public IEnumerable<Titre> FindTitres(int offset, int limit)
        {
            var titres = this.context.Titres.Skip(limit).Take(offset);
            return titres;
        }

        public void IncrementNbLectures(Titre titre)
        {
            this.context.Titres.First(t => t == titre).NbLectures++;
        }

        public void IncrementNbLikes(Titre titre)
        {
            this.context.Titres.First(t => t == titre).NbLikes++;
            this.context.SaveChanges();
        }

        public IEnumerable<Titre> Search(string mot)
        {
            var titres = this.context.Titres.Where(t => t.Libelle.Contains(mot));
            return titres;
        }


        public IEnumerable<Titre> SearchByStyle(string libelle)
        {
            var idStyle = this.context.Styles.First(s => s.Libelle == libelle).IdStyle;
            var titres = this.context.Titres.ToList().FindAll(t => this.context.TitreStyles.ToList().FindAll(ts => ts.IdStyle == idStyle).Exists(ts => ts.IdTitre == t.IdTitre));
            return titres;
        }

        public void Update(Titre titre)
        {
            titre.DateCreation = DateTime.Now;
            this.context.Titres.Update(titre);
            context.Entry(titre).State = EntityState.Modified;
            this.context.SaveChanges();
        }
    }
}
