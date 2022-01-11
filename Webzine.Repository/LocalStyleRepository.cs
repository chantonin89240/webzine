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
            var styles = this.rechercheStyle(style);
            if (styles == null)
            {
                this.Styles.Add(style);
            }
        }

        /// <summary>
        /// Suppression d'un style
        /// </summary>
        /// <param name="style"></param>
        public void Delete(Style style)
        {
            this.Styles.Remove(style);
        }

        /// <summary>
        /// Récupération d'un style
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Style Find(int id)
        {
            return this.Styles.First(a => a.IdStyle == id);
        }

        /// <summary>
        /// Récupération de tout les styles 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Style> FindAll()
        {
            return this.Styles;
        }

        /// <summary>
        /// Modification d'un style
        /// </summary>
        /// <param name="style"></param>
        public void Update(Style style)
        {
            this.Styles.Find(a => a == style);
        }

        /// <summary>
        /// Recherche si le style libelle existe déjà pour l'ajout et la modification
        /// </summary>
        /// <param name="style"></param>
        /// <returns></returns>
        public Style rechercheStyle(Style style)
        {
            var styles = this.Styles.FirstOrDefault(s => s.Libelle.ToLower() == style.Libelle.ToLower());
            return styles;
        }

    }
}
