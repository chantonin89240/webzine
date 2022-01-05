using Webzine.Entity;

namespace Webzine.Repository.Contracts
{
    public interface ITitreRepository
    {
        void Add(Titre titre);
        int Count();
        void Delete(Titre titre);
        Titre Find(int idTitre);
        IEnumerable<Titre> FindAll();
        IEnumerable<Titre> FindTitres(int offset, int limit);
        void IncrementNbLectures(Titre titre);
        void IncrementNbLikes(Titre titre);
        IEnumerable<Titre> Search(string mot);
        IEnumerable<Titre> SearchByStyle(string libelle);
        void Update(Titre titre);

    }
}
