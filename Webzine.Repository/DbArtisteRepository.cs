using Webzine.EntitiesContext;
using Webzine.Entity;
using Webzine.Repository.Contracts;

namespace Webzine.Repository
{
    public  class DbArtisteRepository : IArtisteRepository
    {
        WebzineDbContext context = new WebzineDbContext();


        /// <summary>
        /// Adds an <see cref="Artiste"/> to the local repository.
        /// </summary>
        /// <param name="artiste">Artiste to add.</param>
        /// <exception cref="NotImplementedException">Not yet implemented.</exception>
        public void Add(Artiste artiste)
        {
            throw new NotImplementedException();

            // artistes.Add(artiste);
        }

        /// <summary>
        /// Deletes an <see cref="Artiste"/> from the local repository.
        /// </summary>
        /// <param name="artiste"><see cref="Artiste"/> to be removed.</param>
        /// <exception cref="NotImplementedException">Not yet implemented.</exception>
        public void Delete(Artiste artiste)
        {
            context.Remove(artiste);
            context.SaveChanges();
        }

        /// <summary>
        /// Searches for a specific iteration of <see cref="Artiste"/> in the repository.
        /// </summary>
        /// <param name="id">ID of the <see cref="Artiste"/> to search for.</param>
        /// <returns><see cref="Artiste"/> with given ID.</returns>
        public Artiste Find(int id)
        {
            Artiste artiste = this.context.Artistes.First(a => a.IdArtiste == id);
            return artiste;
        }

        /// <summary>
        /// Returns all valid <see cref="Artiste"/>s from local repository.
        /// </summary>
        /// <returns>Whole <see cref="Artiste"/> list.</returns>
        public IEnumerable<Artiste> FindAll()
        {
            IEnumerable<Artiste> artistes = this.context.Artistes.ToList();
            return artistes;

            // .FindAll(a => a.IdArtiste != null).ToList();
        }

        /// <summary>
        /// Updates an <see cref="Artiste"/> in the repository based on ???.
        /// </summary>
        /// <param name="artiste">New or Updated <see cref="Artiste"/></param>
        /// <exception cref="NotImplementedException">Not yet implemented.</exception>
        public void Update(Artiste artiste)
        {
           context.Artistes.Update(artiste);

        }
    }
}
