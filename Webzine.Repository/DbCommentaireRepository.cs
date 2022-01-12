using Webzine.Repository.Contracts;
using Webzine.Entity;
using Webzine.EntitiesContext;

namespace Webzine.Repository
{
    public class DbCommentaireRepository : ICommentaireRepository
    {
        private WebzineDbContext _context;
        public DbCommentaireRepository(WebzineDbContext context){
            this._context = context;
        }

        public void Add(Commentaire commentaire)
        {
            this._context.Add(commentaire);
            this._context.SaveChanges();
        }

        public void Delete(int id)
        {
            this._context.Remove(this.Find(id));
            this._context.SaveChanges();
        }

        public Commentaire Find(int id)
        {
            return this._context.Commentaires.Find(id);
        }

        public IEnumerable<Commentaire> FindAll()
        {
            return this._context.Commentaires;
        }
    }
}
