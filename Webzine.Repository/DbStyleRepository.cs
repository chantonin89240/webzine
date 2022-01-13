namespace Webzine.Repository
{
    using Webzine.Entity;
    using Webzine.Repository.Contracts;
    using Webzine.EntitiesContext;

    public class DbStyleRepository : IStyleRepository 
    {
        private WebzineDbContext _context;
        public DbStyleRepository(WebzineDbContext context){
            this._context = context;
        }

        /// <summary>
        /// Ajout du style
        /// </summary>
        /// <param name="style"></param>
        public void Add(Style style)
        {
            if (this.rechercheStyle(style) == null)
            {
                style.Libelle = this.boldStyle(style);
                this._context.Add(style);
                this._context.SaveChanges();
            }
        }

        /// <summary>
        /// Suppression du style
        /// </summary>
        /// <param name="style"></param>
        public void Delete(Style style)
        {
            this._context.Remove(style);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Récupére un style
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Style Find(int id)
        {
            var style = this._context.Styles.First(s => s.IdStyle == id);
            return style;
        }

        /// <summary>
        /// Récupére tout les styles
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Style> FindAll()
        {
            IEnumerable<Style> styles = this._context.Styles.ToList().OrderBy(s => s.Libelle);
            return styles;
        }

        /// <summary>
        /// Modifie un style
        /// </summary>
        /// <param name="style"></param>
        public void Update(Style style)
        {
            if (this.rechercheStyle(style) == null)
            {
                style.Libelle = this.boldStyle(style);
                this._context.Update(style);
                this._context.SaveChanges();
            }
        }

        /// <summary>
        /// méthode qui vérifie que le style n'existe pas déjà avec le libelle placé en minuscule
        /// </summary>
        /// <param name="style"></param>
        /// <returns></returns>
        public Style rechercheStyle(Style style)
        {
            var styles = this._context.Styles.FirstOrDefault(s => s.Libelle.ToLower() == style.Libelle.ToLower());
            return styles;
        }

        /// <summary>
        /// méthode qui modifie la première lettre du libelle de style en majuscule
        /// </summary>
        /// <param name="style"></param>
        /// <returns></returns>
        public string boldStyle(Style style)
        {
            var boldStyle = style.Libelle.First().ToString().ToUpper() + style.Libelle.Remove(0, 1).ToLower();
            return boldStyle;
        }
    }
}
