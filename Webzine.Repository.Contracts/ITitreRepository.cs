namespace Webzine.Repository.Contracts
{
    using Webzine.Entity;

    public interface ITitreRepository
    {
        void Add(Titre titre);
        void AddStyles(Titre titre, List<string> styles);
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
        void UpdateStyles(int idTitre, List<string> listRemove, List<string> listAdd);
    }
}
