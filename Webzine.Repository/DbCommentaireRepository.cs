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
            this.context.Add(commentaire);
            //this.context.SaveChanges();
        }

        public void Delete(int id)
        {
            this.context.Remove(this.Find(id));
            this.context.SaveChanges();
        }

        public Commentaire Find(int id)
        {
            {
                return this.context.Commentaires.Find(id);
            }
        }

        public IEnumerable<Commentaire> FindAll()
        {
            return this.context.Commentaires;
        }
    }
}
