namespace Webzine.Repository.Contracts
{
    using Webzine.Entity;

    public interface ICommentaireRepository
    {
        public void Add(Commentaire commentaire);

        public void Delete(int id);

        public Commentaire Find(int id);

        public IEnumerable<Commentaire> FindAll();
    }
}
