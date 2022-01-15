namespace Webzine.Repository
{
    using Webzine.Entity;
    using Webzine.EntitiesContext;
    using Webzine.Repository.Contracts;

    /// <summary>
    /// Represent the local repository for this._context.Artistes.
    /// </summary>
    public class LocalArtisteRepository : IArtisteRepository
    {
        private WebzineDbContext _context;
        public LocalArtisteRepository(WebzineDbContext context){
            this._context = context;
        }

        /// <summary>
        /// Adds an <see cref="Artiste"/> to the local repository.
        /// </summary>
        /// <param name="artiste">Artiste to add.</param>
        /// <exception cref="NotImplementedException">Not yet implemented.</exception>
        public void Add(Artiste artiste)
        {
            this._context.Artistes.Add(artiste);
        }

        /// <summary>
        /// Deletes an <see cref="Artiste"/> from the local repository.
        /// </summary>
        /// <param name="artiste"><see cref="Artiste"/> to be removed.</param>
        /// <exception cref="NotImplementedException">Not yet implemented.</exception>
        public void Delete(Artiste artiste)
        {
            this._context.Artistes.Remove(artiste);
        }

        /// <summary>
        /// Searches for a specific iteration of <see cref="Artiste"/> in the repository.
        /// </summary>
        /// <param name="id">ID of the <see cref="Artiste"/> to search for.</param>
        /// <returns><see cref="Artiste"/> with given ID.</returns>
        public Artiste Find(int id)
        {
            return this._context.Artistes.First(a => a.IdArtiste == id);
        }

        /// <summary>
        /// Returns all valid <see cref="Artiste"/>s from local repository.
        /// </summary>
        /// <returns>Whole <see cref="Artiste"/> list.</returns>
        public IEnumerable<Artiste> FindAll()
        {
            return this._context.Artistes;
        }

        /// <summary>
        /// Updates an <see cref="Artiste"/> in the repository based on ???.
        /// </summary>
        /// <param name="artiste">New or Updated <see cref="Artiste"/></param>
        /// <exception cref="NotImplementedException">Not yet implemented.</exception>
        public void Update(Artiste artiste)
        {
            
        }
    }
}