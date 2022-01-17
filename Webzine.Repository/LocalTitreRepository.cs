namespace Webzine.Repository
{
    using Webzine.Entity;
    using Webzine.Repository.Contracts;
    using Webzine.EntitiesContext;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Represents the local repository for <see cref="Titre"/>s.
    /// </summary>
    public class LocalTitreRepository : ITitreRepository
    {
        private WebzineDbContext _context;
        public LocalTitreRepository(WebzineDbContext context){
            this._context = context;
        }

        /// <summary>
        /// Adds a <see cref="Titre"/> to local repository.
        /// </summary>
        /// <param name="titre"><see cref="Titre"/> to add.</param>
        public void Add(Titre titre)
        {
            this._context.Titres.Add(titre);
        }

        public void AddStyles(Titre titre, List<string> styles)
        {

        }

        /// <summary>
        /// Counts the amount of <see cref="Titre"/> in repository.
        /// </summary>
        /// <returns>how many <see cref="Titre"/>s are in the repository.</returns>
        public int Count()
        {
            return this._context.Titres.Count();
        }

        /// <summary>
        /// Deletes a <see cref="Titre"/> from the local repository.
        /// </summary>
        /// <param name="titre"><see cref="Titre"/> to remove.</param>
        public void Delete(Titre titre)
        {
            this._context.Titres.Remove(titre);
        }

        /// <summary>
        /// Finds a specific <see cref="Titre"/> in the local repository.
        /// </summary>
        /// <param name="idTitre">ID of the <see cref="Titre"/> to find.</param>
        /// <returns><see cref="Titre"/> with given ID.</returns>
        public Titre Find(int idTitre)
        {
            return this._context.Titres.First(t => t.IdTitre == idTitre);
        }

        /// <summary>
        /// Returns the entire repository of <see cref="Titre"/>s.
        /// </summary>
        /// <returns>whole <see cref="Titre"/> List.</returns>
        public IEnumerable<Titre> FindAll()
        {
            var titres = this._context.Titres
                .Include(t => t.Artiste)
                .Include(t => t.Commentaires)
                .Include(t => t.TitresStyles)
                .ThenInclude(ts => ts.Style);

            return titres;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <returns>List of <see cref="Titre"/>s.</returns>
        public IEnumerable<Titre> FindTitres(int offset, int limit)
        {
            var titres = this._context.Titres.Skip(offset).Take(limit);
            return this._context.Titres.Skip(offset).Take(limit);
        }

        /// <summary>
        /// increments the NbLectures value within a given <see cref="Titre"/>.
        /// </summary>
        /// <param name="titre"><see cref="Titre"/> to increment.</param>
        public void IncrementNbLectures(Titre titre)
        {
            int nbTotal = this._context.Titres.FirstOrDefault(t => t == titre).NbLectures + 1;
            this._context.Titres.FirstOrDefault(t => t == titre).NbLectures = nbTotal;
            // this.Update(titre);
        }

        /// <summary>
        /// increments the NvLikes value within a given <see cref="Titre"/>.
        /// </summary>
        /// <param name="titre"><see cref="Titre"/> to increment.</param>
        public void IncrementNbLikes(Titre titre)
        {
            int nbTotal = this._context.Titres.FirstOrDefault(t => t == titre).NbLikes + 1;
            this._context.Titres.FirstOrDefault(t => t == titre).NbLikes = nbTotal;
            // this.Update(titre);
        }

        /// <summary>
        /// Searches for specific <see cref="Titre"/>s which's names contain a keyword.
        /// </summary>
        /// <param name="mot">Keyword to search for.</param>
        /// <returns><see cref="Titre"/>s containing given keyword.</returns>
        public IEnumerable<Titre> Search(string mot)
        {
            return this._context.Titres.Where(t => t.Libelle.Contains(mot));
        }

        /// <summary>
        /// Searches for specific <see cref="Titre"/>s which have a specific <see cref="Style"/>.
        /// </summary>
        /// <param name="libelle">keyword for the <see cref="Style"/> to search for</param>
        /// <returns><see cref="Titre"/>s with the given Style.</returns>
        public IEnumerable<Titre> SearchByStyle(string libelle)
        {
            var idStyle = this._context.Styles.First(s => s.Libelle.Contains(libelle)).IdStyle;
            return this._context.Titres.ToList().FindAll(t => t.TitresStyles.ToList().Exists(item => item.IdStyle == idStyle));
        }

        /// <summary>
        /// Updates a <see cref="Titre"/> based on ???.
        /// </summary>
        /// <param name="titre">Updated <see cref="Titre"/>.</param>
        /// <exception cref="NotImplementedException">Not yet implemented.</exception>
        public void Update(Titre titre)
        {
            //this._context.Titres.Find(t => t == titre).updateDbTitle(................);
            throw new NotImplementedException();
        }

        public void UpdateStyles(int IdTitre, List<string> listRemove, List<string> listAdd)
        {
            //this._context.Titres.Find(t => t == titre).updateDbTitle(................);
            throw new NotImplementedException();
        }
    }
}