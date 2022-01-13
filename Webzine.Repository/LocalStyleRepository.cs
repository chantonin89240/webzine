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
            if (this.rechercheStyle(style) == null)
            {
                style.Libelle = this.boldStyle(style);
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
            var style = this.Styles.First(s => s.IdStyle == id);
            return style;
        }

        /// <summary>
        /// Récupération de tout les styles 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Style> FindAll()
        {
            IEnumerable<Style> styles = this.Styles.ToList().OrderBy(s => s.Libelle);
            return styles;
        }

        /// <summary>
        /// Modification d'un style
        /// </summary>
        /// <param name="style"></param>
        public void Update(Style style)
        {
            if (this.rechercheStyle(style) == null)
            {
                style.Libelle = this.boldStyle(style);
                this.Update(style);
            }

        }

        /// <summary>
        /// méthode qui vérifie que le style n'existe pas déjà avec le libelle placé en minuscule
        /// </summary>
        /// <param name="style"></param>
        /// <returns></returns>
        public Style rechercheStyle(Style style)
        {
            var styles = this.Styles.FirstOrDefault(s => s.Libelle.ToLower() == style.Libelle.ToLower());
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
