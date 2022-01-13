namespace Webzine.Repository
{
    using Microsoft.EntityFrameworkCore;
    using Webzine.EntitiesContext;
    using Webzine.Entity;
    using Webzine.Repository.Contracts;

    public class DbStyleRepository : IStyleRepository 
    {
        private WebzineDbContext _context;
        public DbStyleRepository(WebzineDbContext context){
            this._context = context;
        }

        /// <summary>
        /// Ajout du style.
        /// </summary>
        /// <param name="style">Style qui sera ajouté.</param>
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
        /// Suppression du style.
        /// </summary>
        /// <param name="style">Style qui sera supprimé.</param>
        public void Delete(Style style)
        {
            this._context.Remove(style);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Récupère un style.
        /// </summary>
        /// <param name="id">ID du style à récupérer.</param>
        /// <returns>Style avec l'ID correspondant.</returns>
        public Style Find(int id)
        {
            var style = this.FindAll().First(s => s.IdStyle == id);
            return style;
        }

        /// <summary>
        /// Récupére tout les styles.
        /// </summary>
        /// <returns>Tous les Styles dans la Database.</returns>
        public IEnumerable<Style> FindAll()
        {
            IEnumerable<Style> styles = this._context.Styles
                .Include(style => style.TitresStyles)
                .ThenInclude(titreStyle => titreStyle.Titre)
                .ToList().OrderBy(s => s.Libelle);
            return styles;
        }

        /// <summary>
        /// Modifie un style.
        /// </summary>
        /// <param name="style">style mis à jour avec ID identique.</param>
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
