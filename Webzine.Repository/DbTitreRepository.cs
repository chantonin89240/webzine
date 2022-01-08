namespace Webzine.Repository
{
    using System.Collections.Generic;
    using Webzine.EntitiesContext;
    using Webzine.Entity.Factory;
    using Webzine.Repository.Contracts;
    using Webzine.Entity;

    public class DbTitreRepository : ITitreRepository
    {
        private List<Style> styles = StyleFactory.CreateStyle().ToList();
        WebzineDbContext context = new WebzineDbContext();
        public void Add(Titre titre)
        {
            context.Titres.Add(titre);
        }

        public int Count()
        {
            return context.Titres.Count();
        }

        public void Delete(Titre titre)
        {
            context.Titres.Remove(titre);
            context.SaveChanges();
        }

        public Titre Find(int idTitre)
        {
            var titre = context.Titres.FirstOrDefault(t => t.IdTitre == idTitre);
            titre.Artiste = context.Artistes.FirstOrDefault(a => a.IdArtiste == titre.IdArtiste);
            titre.TitresStyles = context.TitreStyles.Where(s => s.IdTitre == titre.IdTitre).ToList();
            return titre;
        }

        public IEnumerable<Titre> FindAll()
        {
            var titres = context.Titres;
            titres.ToList().ForEach(t => t.Artiste = context.Artistes.FirstOrDefault(a => a.IdArtiste == t.IdArtiste));
            titres.ToList().ForEach(t => t.TitresStyles.AddRange(context.TitreStyles.Where(ts => ts.IdTitre == t.IdTitre)));
            return titres;
        }

        public IEnumerable<Titre> FindTitres(int offset, int limit)
        {
            var titres = context.Titres.Skip(limit).Take(offset);
            return titres;
        }

        public void IncrementNbLectures(Titre titre)
        {
            context.Titres.First(t => t == titre).NbLectures++;
        }

        public void IncrementNbLikes(Titre titre)
        {
            context.Titres.First(t => t == titre).NbLikes++; 
        }

        public IEnumerable<Titre> Search(string mot)
        {
            var titres = context.Titres.Where(t => t.Libelle.Contains(mot));
            return titres;
        }


        public IEnumerable<Titre> SearchByStyle(string libelle)
        {
            var idStyle = this.styles.First(s => s.Libelle.Contains(libelle)).IdStyle;
            return context.Titres.ToList().FindAll(t => t.TitresStyles.Exists(item => item.IdStyle == idStyle));
        }

        public void Update(Titre titre)
        {
            context.Titres.Update(titre);
            context.SaveChanges();
        }
    }
}
