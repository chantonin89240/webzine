namespace Webzine.Repository
{
    using System.Collections.Generic;
    using Webzine.EntitiesContext;
    using Webzine.Repository.Contracts;
    using Webzine.Entity;

    public class DbTitreRepository : ITitreRepository
    {
        WebzineDbContext context = new WebzineDbContext();
        public void Add(Titre titre)
        {

        }

        public int Count()
        {
            return 0;
        }

        public void Delete(Titre titre)
        {
            context.Titres.Remove(titre);
            context.SaveChanges();
        }

        public Titre Find(int idTitre)
        {
            return null;
        }

        public IEnumerable<Titre> FindAll()
        {
            var Titres = context.Titres;
            Titres.ToList().ForEach(t => t.Artiste = context.Artistes.FirstOrDefault(a => a.IdArtiste == t.IdArtiste));
            Titres.ToList().ForEach(t => t.TitresStyles.AddRange(context.TitreStyles.Where(ts => ts.IdTitre == t.IdTitre)));
            return Titres;
        }

        public IEnumerable<Titre> FindTitres(int offset, int limit)
        {
            return Enumerable.Empty<Titre>();
        }

        public void IncrementNbLectures(Titre titre)
        {

        }

        public void IncrementNbLikes(Titre titre)
        {

        }

        public IEnumerable<Titre> Search(string mot)
        {
            return new List<Titre>();
        }

        public IEnumerable<Titre> SearchByStyle(string libelle)
        {
            return Search(libelle);
        }

        public void Update(Titre titre)
        {
            context.Titres.Update(titre);
            context.SaveChanges();
        }
    }
}
