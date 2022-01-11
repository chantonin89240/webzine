namespace Webzine.Repository.Contracts
{
    using Webzine.Entity;

    public interface IArtisteRepository
    {
        void Add(Artiste artiste);

        void Delete(Artiste artiste);

        Artiste Find(int id);

        IEnumerable<Artiste> FindAll();

        void Update(Artiste artiste);

    }
}