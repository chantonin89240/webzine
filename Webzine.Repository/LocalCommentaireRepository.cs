namespace Webzine.Repository
{
    using Webzine.Entity;
    using Webzine.EntitiesContext;
    using Webzine.Repository.Contracts;

    /// <summary>
    /// Represents the Local Repository for <see cref="Commentaire"/>s.
    /// </summary>
    public class LocalCommentaireRepository : ICommentaireRepository
    {
        
        private WebzineDbContext _context;
        public LocalCommentaireRepository(WebzineDbContext context){
            this._context = context;
        }

        /// <summary>
        /// Adds a <see cref="Commentaire"/> to local repository.
        /// </summary>
        /// <param name="commentaire"><see cref="Commentaire"/> to add.</param>
        public void Add(Commentaire commentaire)
        {
            this._context.Commentaires.Add(commentaire);
        }

        /// <summary>
        /// Deletes a <see cref="Commentaire"/> from repository with given ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="Commentaire"/> to remove.</param>
        public void Delete(int id)
        {
            if (this._context.Commentaires.ToList().Exists(comm => comm.IdCommentaire == id))
            {
                this._context.Commentaires.Remove(this.Find(id));
            }
        }

        /// <summary>
        /// Searches local repository for a specific <see cref="Commentaire"/>.
        /// </summary>
        /// <param name="id">ID of the <see cref="Commentaire"/> to find.</param>
        /// <returns><see cref="Commentaire"/> in repository with requested ID.</returns>
        public Commentaire Find(int id)
        {
            if (this._context.Commentaires.ToList().Exists(comm => comm.IdCommentaire == id))
            {
                return this._context.Commentaires.First(comm => comm.IdCommentaire == id);
            }
            else { return new Commentaire(); }
        }

        /// <summary>
        /// Returns all valid <see cref="Commentaire"/>s in local repository.
        /// </summary>
        /// <returns><see cref="Commentaire"/> list.</returns>
        public IEnumerable<Commentaire> FindAll()
        {
            return this._context.Commentaires.ToList().FindAll(comm => comm is not null);
        }


    }
}
