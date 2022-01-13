namespace Webzine.Repository
{
    using Webzine.Entity;
    using Webzine.Entity.Factory;
    using Webzine.Repository.Contracts;

    /// <summary>
    /// Represents the local repository for <see cref="Titre"/>s.
    /// </summary>
    public class LocalTitreRepository : ITitreRepository
    {
        private List<Titre> titres = TitreFactory.CreateTitre(10, ArtisteFactory.CreateArtiste(10), StyleFactory.GetStyles()).ToList();
        private List<Style> styles = StyleFactory.CreateStyle().ToList();

        /// <summary>
        /// Adds a <see cref="Titre"/> to local repository.
        /// </summary>
        /// <param name="titre"><see cref="Titre"/> to add.</param>
        public void Add(Titre titre)
        {
            this.titres.Add(titre);
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
            return this.titres.Count;
        }

        /// <summary>
        /// Deletes a <see cref="Titre"/> from the local repository.
        /// </summary>
        /// <param name="titre"><see cref="Titre"/> to remove.</param>
        public void Delete(Titre titre)
        {
            this.titres.Remove(titre);
        }

        /// <summary>
        /// Finds a specific <see cref="Titre"/> in the local repository.
        /// </summary>
        /// <param name="idTitre">ID of the <see cref="Titre"/> to find.</param>
        /// <returns><see cref="Titre"/> with given ID.</returns>
        public Titre Find(int idTitre)
        {
            return this.titres.First(t => t.IdTitre == idTitre);
        }

        /// <summary>
        /// Returns the entire repository of <see cref="Titre"/>s.
        /// </summary>
        /// <returns>whole <see cref="Titre"/> List.</returns>
        public IEnumerable<Titre> FindAll()
        {
            return this.titres;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <returns>List of <see cref="Titre"/>s.</returns>
        public IEnumerable<Titre> FindTitres(int offset, int limit)
        {
            return this.titres.Skip(limit).Take(offset);
        }

        /// <summary>
        /// increments the NbLectures value within a given <see cref="Titre"/>.
        /// </summary>
        /// <param name="titre"><see cref="Titre"/> to increment.</param>
        public void IncrementNbLectures(Titre titre)
        {
            int nbTotal = this.titres.FirstOrDefault(t => t == titre).NbLectures + 1;
            this.titres.FirstOrDefault(t => t == titre).NbLectures = nbTotal;
            this.Update(titre);
        }

        /// <summary>
        /// increments the NvLikes value within a given <see cref="Titre"/>.
        /// </summary>
        /// <param name="titre"><see cref="Titre"/> to increment.</param>
        public void IncrementNbLikes(Titre titre)
        {
            int nbTotal = this.titres.FirstOrDefault(t => t == titre).NbLikes + 1;
            this.titres.FirstOrDefault(t => t == titre).NbLikes = nbTotal;
            this.Update(titre);
        }

        /// <summary>
        /// Searches for specific <see cref="Titre"/>s which's names contain a keyword.
        /// </summary>
        /// <param name="mot">Keyword to search for.</param>
        /// <returns><see cref="Titre"/>s containing given keyword.</returns>
        public IEnumerable<Titre> Search(string mot)
        {
            return this.titres.Where(t => t.Libelle.Contains(mot));
        }

        /// <summary>
        /// Searches for specific <see cref="Titre"/>s which have a specific <see cref="Style"/>.
        /// </summary>
        /// <param name="libelle">keyword for the <see cref="Style"/> to search for</param>
        /// <returns><see cref="Titre"/>s with the given Style.</returns>
        public IEnumerable<Titre> SearchByStyle(string libelle)
        {
            var idStyle = this.styles.First(s => s.Libelle.Contains(libelle)).IdStyle;
            return this.titres.FindAll(t => t.TitresStyles.ToList().Exists(item => item.IdStyle == idStyle));
        }

        /// <summary>
        /// Updates a <see cref="Titre"/> based on ???.
        /// </summary>
        /// <param name="titre">Updated <see cref="Titre"/>.</param>
        /// <exception cref="NotImplementedException">Not yet implemented.</exception>
        public void Update(Titre titre)
        {
            //this.titres.Find(t => t == titre).updateDbTitle(................);
            throw new NotImplementedException();
        }

        public void UpdateStyles(int IdTitre, List<string> listRemove, List<string> listAdd)
        {
            //this.titres.Find(t => t == titre).updateDbTitle(................);
            throw new NotImplementedException();
        }
    }
}
