namespace Webzine.Repository
{
    using System.Collections.Generic;
    using Webzine.EntitiesContext;
    using Webzine.Entity.Factory;
    using Webzine.Repository.Contracts;
    using Microsoft.EntityFrameworkCore;
    using Webzine.Entity;
    using System.Linq;

    public class DbTitreRepository : ITitreRepository
    {
        private WebzineDbContext context = new WebzineDbContext();
        public void Add(Titre titre)
        {
            this.context.Titres.Add(titre);
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
            var titres = this.context.Titres;
            titres.ToList().ForEach(t => t.Artiste = this.context.Artistes.FirstOrDefault(a => a.IdArtiste == t.IdArtiste));
            titres.ToList().ForEach(t => t.TitresStyles.AddRange(this.context.TitreStyles.Where(ts => ts.IdTitre == t.IdTitre)));
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
        }

        public IEnumerable<Titre> Search(string mot)
        {
            var titres = this.context.Titres.Where(t => t.Libelle.Contains(mot));
            return titres;
        }


        public IEnumerable<Titre> SearchByStyle(string libelle)
        {
            var idStyle = this.context.Styles.First(s => s.Libelle == libelle).IdStyle;

            var titres = new List<Titre>();

            this.context.TitreStyles.ToList().FindAll(ts => ts.IdStyle == idStyle).ForEach(ts => titres.Add(this.context.Titres.First(t => t.IdTitre == ts.IdTitre)));
            return titres;
        }

        public void Update(Titre titre)
        {
            this.context.Titres.Update(titre);
            this.context.SaveChanges();
        }
    }
}
