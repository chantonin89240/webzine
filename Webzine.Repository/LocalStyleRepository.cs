namespace Webzine.Repository
{
    using Webzine.Entity;
    using Webzine.Entity.Factory;
    using Webzine.Repository.Contracts;

    public class LocalStyleRepository : IStyleRepository
    {
        public List<Style> Styles = StyleFactory.CreateStyle().ToList();

        /// <summary>
        /// Ajout d'un style        /// </summary>
        /// <param name="style"></param>
        public void Add(Style style)
        {
            Styles.Add(style);
        }

        /// <summary>
        /// Suppression d'un style
        /// </summary>
        /// <param name="style"></param>
        public void Delete(Style style)
        {
            Styles.Remove(style);
        }

        /// <summary>
        /// Récupération d'un style
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Style Find(int id)
        {
            return Styles.First(a => a.IdStyle == id);
        }

        /// <summary>
        /// Récupération de tout les styles 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Style> FindAll()
        {
            return Styles;
        }

        /// <summary>
        /// Modification d'un style
        /// </summary>
        /// <param name="style"></param>
        public void Update(Style style)
        {
            Styles.Find(a => a == style);
        }

    }
}
