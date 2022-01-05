namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.WebApplication.Areas.Admin.ViewModels;

    /// <summary>
    /// Représente le controlleur pour la partie des Titres dans la zone d'administration.
    /// </summary>
    [Area("administration")]
    public class TitreController : Controller
    {
        /// <summary>
        /// Page par défaut du controlleur: Une vue d'ensemble de tous les titres, en mode d'administration.
        /// </summary>
        /// <returns>
        /// La vue correspondante à l'administration des titres.
        /// </returns>
        public IActionResult Index()
        {
            TitreViewModel model = new TitreViewModel();
            model.GetTitres();
            return this.View(model.Titres);
        }

        /// <summary>
        /// Page de création d'un nouveau titre.
        /// </summary>
        /// <returns>
        /// Une page permettant la création d'un nouveau titre.
        /// </returns>
        public IActionResult Creation()
        {
            TitreViewModel model = new TitreViewModel();
            //model.GetStyles();
            model.GetArtistes();

            return this.View(model);
        }

        /// <summary>
        /// Page permettant la modification des données enregistrées sur un titre.
        /// Préchargé avec les données déja enregistrées.
        /// </summary>
        /// <param name="id">ID Du titre à éditer.</param>
        /// <returns>
        /// La page de modification d'un titre.
        /// </returns>
        public IActionResult Edit(int id)
        {
            TitreViewModel model = new TitreViewModel();
            model.GetTitre(id);
           // model.GetStyle(model.Titre);
            //model.GetStyles();
            model.GetArtistes();

            return this.View(model);
        }

        /// <summary>
        /// Page de vérification de la suppression d'un titre.
        /// Charge certaines données du titre.
        /// </summary>
        /// <param name="id">ID du titre à supprimer.</param>
        /// <returns>
        /// Page de vérification de suppression.
        /// </returns>
        public IActionResult Suppression(int id)
        {
            TitreViewModel model = new TitreViewModel();
            model.GetTitre(id);
            return this.View(model.Titre);
        }

    }
}
