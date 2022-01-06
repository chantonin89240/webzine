namespace Webzine.Repository
{
    using Webzine.Entity;
    using Webzine.Entity.Factory;
    using Webzine.Repository.Contracts;

    /// <summary>
    /// Represents the Local Repository for <see cref="Commentaire"/>s.
    /// </summary>
    public class LocalCommentaireRepository : ICommentaireRepository
    {
        private List<Commentaire> commentaires = CommentaireFactory.CreateCommentaire().ToList();

        /// <summary>
        /// Adds a <see cref="Commentaire"/> to local repository.
        /// </summary>
        /// <param name="commentaire"><see cref="Commentaire"/> to add.</param>
        public void Add(Commentaire commentaire)
        {
            this.commentaires.Add(commentaire);
        }

        /// <summary>
        /// Deletes a <see cref="Commentaire"/> from repository with given ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="Commentaire"/> to remove.</param>
        public void Delete(int id)
        {
            if (this.commentaires.Exists(comm => comm.IdCommentaire == id))
            {
                this.commentaires.Remove(this.Find(id));
            }
        }

        /// <summary>
        /// Searches local repository for a specific <see cref="Commentaire"/>.
        /// </summary>
        /// <param name="id">ID of the <see cref="Commentaire"/> to find.</param>
        /// <returns><see cref="Commentaire"/> in repository with requested ID.</returns>
        public Commentaire Find(int id)
        {
            if (this.commentaires.Exists(comm => comm.IdCommentaire == id))
            {
                return this.commentaires.First(comm => comm.IdCommentaire == id);
            }
            else { return new Commentaire(); }
        }

        /// <summary>
        /// Returns all valid <see cref="Commentaire"/>s in local repository.
        /// </summary>
        /// <returns><see cref="Commentaire"/> list.</returns>
        public IEnumerable<Commentaire> FindAll()
        {
            return this.commentaires.FindAll(comm => comm is not null);
        }


    }
}
