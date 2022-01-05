using Webzine.Entity;

namespace Webzine.Repository.Contracts
{
    public interface ICommentaireRepository
    {
        public void Add(Commentaire commentaire);
        public void Delete(int id);
        public Commentaire Find(int id);
        public IEnumerable<Commentaire> FindAll();
    }
}
