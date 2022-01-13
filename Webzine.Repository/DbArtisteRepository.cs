using Microsoft.EntityFrameworkCore;
using Webzine.EntitiesContext;
using Webzine.Entity;
using Webzine.Repository.Contracts;

namespace Webzine.Repository
{
    public class DbArtisteRepository : IArtisteRepository
    {
        private WebzineDbContext _context;
        public DbArtisteRepository(WebzineDbContext context){
            this._context = context;
        }

        /// <summary>
        /// Adds an <see cref="Artiste"/> to the local repository.
        /// </summary>
        /// <param name="artiste">Artiste to add.</param>
        /// <exception cref="NotImplementedException">Not yet implemented.</exception>
        public void Add(Artiste artiste)
        {
            // recherceh si l' artiste existe déjà
            var artistes = this._context.Artistes.FirstOrDefault(art => art.Nom.ToLower() == artiste.Nom.ToLower());

            // s'il n'existe pas on le crée
            if (artistes == null)
            {
                this._context.Add(artiste);
                this._context.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes an <see cref="Artiste"/> from the local repository.
        /// </summary>
        /// <param name="artiste"><see cref="Artiste"/> to be removed.</param>
        /// <exception cref="NotImplementedException">Not yet implemented.</exception>
        public void Delete(Artiste artiste)
        {
            this._context.Remove(artiste);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Searches for a specific iteration of <see cref="Artiste"/> in the repository.
        /// </summary>
        /// <param name="id">ID of the <see cref="Artiste"/> to search for.</param>
        /// <returns><see cref="Artiste"/> with given ID.</returns>
        public Artiste Find(int id)
        {
            Artiste artiste = this._context.Artistes.First(a => a.IdArtiste == id);
            artiste.Titres = this._context.Titres.Where(t => t.IdArtiste == artiste.IdArtiste).ToList();

            return artiste;
        }

        /// <summary>
        /// Returns all valid <see cref="Artiste"/>s from local repository.
        /// </summary>
        /// <returns>Whole <see cref="Artiste"/> list.</returns>
        public IEnumerable<Artiste> FindAll()
        {
            IEnumerable<Artiste> artistes = this._context.Artistes
                .Include(artiste => artiste.Titres);
            return artistes;
        }

        /// <summary>
        /// Updates an <see cref="Artiste"/> in the repository based on it's ID.
        /// </summary>
        /// <param name="artiste">New or Updated <see cref="Artiste"/></param>
        public void Update(Artiste artiste)
        {
            var artistes = this._context.Artistes.Where(a => a.IdArtiste != artiste.IdArtiste);
            var result = false;
            foreach (var artis in artistes)
            {
                if (artiste.Nom == artis.Nom )
                {
                    result = true;
                }
            }
            if (result != true )
            {
                this._context.Artistes.Update(artiste);
                this._context.SaveChanges();
            }

            this._context.Entry(artiste).State = EntityState.Modified;
        }
    }
}