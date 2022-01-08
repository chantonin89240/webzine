namespace Webzine.Repository
{
    using Webzine.EntitiesContext;
    using Webzine.Entity;
    using Webzine.Repository.Contracts;

    public class DbStyleRepository : IStyleRepository 
    {
        WebzineDbContext Context = new WebzineDbContext();

        /// <summary>
        /// Ajout du style
        /// </summary>
        /// <param name="style"></param>
        public void Add(Style style)
        {
            Context.Add(style);
        }

        /// <summary>
        /// Suppression du style
        /// </summary>
        /// <param name="style"></param>
        public void Delete(Style style)
        {
            
            Context.Remove(style);
            Context.SaveChanges();
        }

        /// <summary>
        /// Récupére un style
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Style Find(int id)
        {
            Style style = this.Context.Styles.First(s => s.IdStyle == id);
            return style;
        }

        /// <summary>
        /// Récupére tout les styles
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Style> FindAll()
        {
            IEnumerable<Style> styles = this.Context.Styles.ToList();
            return styles;
        }

        /// <summary>
        /// Modifie un style
        /// </summary>
        /// <param name="style"></param>
        public void Update(Style style)
        {
            Context.Styles.Update(style);
        }
    }
}
