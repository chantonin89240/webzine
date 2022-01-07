using Webzine.Repository.Contracts;
using Webzine.Entity;
using Webzine.EntitiesContext;

namespace Webzine.Repository
{
    public class DbCommentaireRepository : ICommentaireRepository
    {
        WebzineDbContext context = new WebzineDbContext();

        public void Add(Commentaire commentaire)
        {
            this.context.Commentaires.Add(commentaire);
        }

        public void Delete(int id)
        {
            context.Commentaires.Remove(this.Find(id));
        }

        public Commentaire? Find(int id)
        {
            return context.Commentaires.Find(id);
        }

        public IEnumerable<Commentaire> FindAll()
        {
            return context.Commentaires;
        }
    }
}
