namespace Webzine.WebApplication.ViewModels
{
    using Webzine.Entity;
    using Webzine.Entity.Factory;

    /// <summary>
    /// Représente les données et fonctions utilisées par ..? (Home utilise TitreViewModel...)
    /// </summary>
    public class HomeViewModel
    {
        /// <summary>
        /// Représente la liste de tous les Titres de la base de données.
        /// </summary>
        public List<Titre> Titres { get; set; } = TitreFactory.CreateTitre2().ToList();

        /// <summary>
        /// Représente la liste de titres populaires.
        /// </summary>
        public List<Titre> TitresPOP { get; set; } = TitreFactory.CreateTitre2().ToList();

        /// <summary>
        /// Représente la page actuellement visionnée par l'utilisateur.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Représente la quantité de titres à afficher par page.
        /// </summary>
        public int TitreTotal { get; set; } = 3;

        /// <summary>
        /// retourne le nombre de pages total.
        /// </summary>
        /// <param name="titreTotal">Quantité de titres affichés par page.</param>
        /// <returns>La quantité de pages de l'application.</returns>
        public int PageCount(int titreTotal)
        {
            return (this.Titres.Count() - (1 / titreTotal)) - (((this.Titres.Count() - 1) / titreTotal) % 1);
        }

        /// <summary>
        /// retourne la liste des <see cref="Titre"/>s pour une page.
        /// </summary>
        /// <param name="page">Représente le numéro de la page correspondante.</param>
        /// <returns>Liste des <see cref="Titre"/>s spécifiques à la page demandée.</returns>
        public List<Titre> TitresPourPage(int page)
        {
            int countPage = this.PageCount(this.TitreTotal);
            if (countPage < page)
            {
                page = countPage;
            }

            List<Titre> output = this.Titres.OrderByDescending(t => t.DateCreation).Chunk(this.TitreTotal).ElementAt(page).ToList();

            return output;
        }

    }
}
