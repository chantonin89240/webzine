using Webzine.Entity;
using Webzine.Entity.Factory;
using Webzine.Repository.Contracts;

namespace Webzine.Repository
{
    public class LocalCommentaireRepository : ICommentaireRepository
    {
        private List<Commentaire> commentaires;

        public void Add(Commentaire commentaire)
        {
            commentaires.Add(commentaire);
        }

        public void Delete(int id)
        {
            if (commentaires.Exists(C => C.IdCommentaire == id))
                commentaires.Remove(commentaires.First(C => C.IdCommentaire == id));
        }

        public Commentaire Find(int id)
        {
            if (commentaires.Exists(C => C.IdCommentaire == id))
                return commentaires.First(C => C.IdCommentaire == id);
            else return new Commentaire();
        }

        public IEnumerable<Commentaire> FindAll()
        {
            return commentaires;
        }

        public LocalCommentaireRepository()
        {
            commentaires = CommentaireFactory.CreateCommentaire().ToList();
        }

    }
}
