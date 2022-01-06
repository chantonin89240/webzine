namespace Webzine.Repository
{
    using Webzine.Entity;
    using Webzine.Entity.Factory;
    using Webzine.Repository.Contracts;

    /// <summary>
    /// Represents the local repository for <see cref="Style"/>s.
    /// </summary>
    public class LocalStyleRepository : IStyleRepository
    {
        private List<Style> styles = StyleFactory.CreateStyle().ToList();

        /// <summary>
        /// Adds a <see cref="Style"/> to the local repository.
        /// </summary>
        /// <param name="style"><see cref="Style"/> to add.</param>
        public void Add(Style style)
        {
            this.styles.Add(style);
        }

        /// <summary>
        /// Deletes a <see cref="Style"/> from the local repository.
        /// </summary>
        /// <param name="style"><see cref="Style"/> to remove.</param>
        public void Delete(Style style)
        {
            this.styles.Remove(style);
        }

        /// <summary>
        /// Searches for a specific <see cref="Style"/> in the local repository.
        /// </summary>
        /// <param name="id">ID of the <see cref="Style"/> to find.</param>
        /// <returns><see cref="Style"/> with given ID.</returns>
        public Style Find(int id)
        {
            return this.styles.First(a => a.IdStyle == id);
        }

        /// <summary>
        /// returns all <see cref="Style"/>s in repository.
        /// </summary>
        /// <returns>complete <see cref="Style"/> List.</returns>
        public IEnumerable<Style> FindAll()
        {
            return this.styles;
        }

        /// <summary>
        /// Updates a <see cref="Style"/> based on ???.
        /// </summary>
        /// <param name="style">Updated <see cref="Style"/>.</param>
        public void Update(Style style)
        {
            this.styles.Find(a => a == style);
        }

    }
}
