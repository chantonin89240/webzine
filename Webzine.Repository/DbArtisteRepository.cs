using Microsoft.EntityFrameworkCore;
using Webzine.EntitiesContext;
using Webzine.Entity;
using Webzine.Repository.Contracts;

namespace Webzine.Repository
{
    public class DbArtisteRepository : IArtisteRepository
    {
        private WebzineDbContext _context;
        public DbArtisteRepository(WebzineDbContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Adds an <see cref="Artiste"/> to the local repository.
        /// </summary>
        /// <param name="artiste">Artiste to add.</param>
        /// <exception cref="NotImplementedException">Not yet implemented.</exception>
        public void Add(Artiste artiste)
        {
            var art = artiste.Nom;


            // s'il n'existe pas on le crée
            if (this.rechercheArtiste(artiste) == null)
            {
                artiste.Nom = art;
                artiste.Nom = this.boldArtiste(artiste);
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
        {            var artistes = this._context.Artistes.Where(a => a.IdArtiste != artiste.IdArtiste).FirstOrDefault(art => art.Nom.ToLower() == artiste.Nom.ToLower());
            if (artistes == null)
            {
                artiste.Nom = this.boldArtiste(artiste);
                this._context.Update(artiste);
                this._context.SaveChanges();
            }


            this._context.Entry(artiste).State = EntityState.Modified;
        }

        public Artiste rechercheArtiste(Artiste artiste)
        {
            var artistes = this._context.Artistes.FirstOrDefault(art => art.Nom.ToLower() == artiste.Nom.ToLower());
            return artistes;
        }

        public string boldArtiste(Artiste artiste)
        {
            var bold = artiste.Nom.First().ToString().ToUpper() + artiste.Nom.Remove(0, 1);
            return bold;

        }
    }
}