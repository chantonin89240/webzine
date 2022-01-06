namespace Webzine.Repository
{
    using System.Collections.Generic;
    using Webzine.Entity;

    public class DbTitreRepository
    {
        public void Add(Titre titre)
        {

        }

        public int Count()
        {
            return 0;
        }

        public void Delete(Titre titre)
        {

        }

        public Titre Find(int idTitre)
        {
            return null;
        }

        public IEnumerable<Titre> FindAll()
        {
            return Enumerable.Empty<Titre>();
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

        }
    }
}
