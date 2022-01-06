namespace Webzine.Repository
{
    using Webzine.Entity;
    using Webzine.Entity.Factory;
    using Webzine.Repository.Contracts;

    public class LocalCommentaireRepository : ICommentaireRepository
    {
        private List<Commentaire> commentaires;

        public void Add(Commentaire commentaire)
        {
            this.commentaires.Add(commentaire);
        }

        public void Delete(int id)
        {
            if (this.commentaires.Exists(C => C.IdCommentaire == id))
            {
                this.commentaires.Remove(this.commentaires.First(C => C.IdCommentaire == id));
            }
        }

        public Commentaire Find(int id)
        {
            if (this.commentaires.Exists(C => C.IdCommentaire == id))
            {
                return this.commentaires.First(C => C.IdCommentaire == id);
            }
            else
            {
                return new Commentaire();
            }
        }

        public IEnumerable<Commentaire> FindAll()
        {
            return this.commentaires;
        }

        public LocalCommentaireRepository()
        {
            this.commentaires = CommentaireFactory.CreateCommentaire().ToList();
        }

    }
}
