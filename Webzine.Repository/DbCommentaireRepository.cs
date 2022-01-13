using Webzine.Repository.Contracts;
using Webzine.Entity;
using Webzine.EntitiesContext;
using Microsoft.EntityFrameworkCore;

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
            return this.FindAll().First(comm => comm.IdCommentaire == id);
        }

        public IEnumerable<Commentaire> FindAll()
        {
            return this._context.Commentaires
                .Include(comment => comment.Titre);
        }
    }
}
