namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.EntitiesContext;
    using Webzine.Entity;
    using Webzine.Repository;
    using Webzine.Repository.Contracts;
    using Webzine.WebApplication.Areas.Admin.ViewModels;

    /// <summary>
    /// Représente le contröleur pour les vues en rapport aux <see cref="Artiste"/>s dans la partie Administration.
    /// </summary>
    [Area("administration")]
    public class ArtisteController : Controller
    {
        private IArtisteRepository artisteRepository;
        private ArtisteViewModel model = new ArtisteViewModel();

        /// <summary>
        /// Initializes a new instance of the <see cref="ArtisteController"/> class.
        /// Contrôleur pour les vues d'administration d'artistes.
        /// </summary>
        /// <param name="artisteRepository">Repos contenant les Artistes.</param>
        public ArtisteController(IArtisteRepository artisteRepository)
        {
            this.artisteRepository = artisteRepository;

        }

        /// <summary>
        /// Renvoie la vue sur chemin "/administration/<see cref="Artiste"/>".
        /// </summary>
        /// <returns>vue d'ensemble de tous les <see cref="Artiste"/>s.</returns>
        public IActionResult Index()
        {
            this.model.Artistes = this.artisteRepository.FindAll().OrderBy(a => a.Nom).ToList();
            return this.View(this.model);
        }

        /// <summary>
        /// Renvoie la vue sur chemin "/administration/Artiste/Creation".
        /// </summary>
        /// <returns>Vue pour la création d'un <see cref="Artiste"/>.</returns>
        public IActionResult Create()
        {
            return this.View();
        }

        /// <summary>
        /// Crée un artiste
        /// </summary>
        /// <returns>Vue pour la création d'un <see cref="Artiste"/>.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("create")]
        public IActionResult Create(ArtisteViewModel model)
        {
            try
            {
                if (this.ModelState.IsValid)
                {
                    this.artisteRepository.Add(model.Artiste);
                    return this.RedirectToAction(nameof(this.Index));
                }
            }
            catch
            {
                this.ModelState.AddModelError(" ", "Error");
            }

            return this.View(model.Artiste);
        }

        /// <summary>
        /// Renvoie la vue sur chemin "/administration/Artiste/Edit?IdArtiste=(Id de l'<see cref="Artiste"/>)".
        /// </summary>
        /// <param name="id">Id de l'<see cref="Artiste"/> géré par la vue.</param>
        /// <returns>Vue web pour l'édition d'un <see cref="Artiste"/> qui sera modifié.</returns>
        public IActionResult Edit(int id)
        {
            var artiste = this.artisteRepository.Find(id);
            this.model.Artiste = artiste;
            return this.View(this.model);
        }

        /// <summary>
        /// Edits an Artiste in the database.
        /// </summary>
        /// <param name="model">updated Artiste loaded into a viewmodel.</param>
        /// <param name="id">ID of the updated artist.</param>
        /// <returns>returns to index if succesful, returns with in-web errors if it fails. Triggers an exception otherwise.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("edit")]
        public IActionResult Edit(ArtisteViewModel model, int id)
        {
            try
            {
                if (this.ModelState.IsValid)
                {
                    model.Artiste.IdArtiste = id;
                    this.artisteRepository.Update(model.Artiste);
                    return this.RedirectToAction(nameof(this.Index));
                }
            }
            catch
            {
                this.ModelState.AddModelError(" ", "Error");
            }

            return this.View(model.Artiste);
        }

        /// <summary>
        /// Génère et renvoie la vue de vérification pour la suppression d'un <see cref="Artiste"/>.
        /// </summary>
        /// <param name="id">ID de l'<see cref="Artiste"/> à supprimer par la vue.</param>
        /// <returns>Vue web pour la suppression d'un <see cref="Artiste"/>.</returns>
        [ActionName("delete")]
        public IActionResult Delete(int id)
        {
            var artiste = this.artisteRepository.Find(id);
            this.model.Artiste = artiste;
            return this.View(this.model);
        }

        /// <summary>
        /// Supprime un artiste dans la database.
        /// </summary>
        /// <param name="id">id de l'artiste effacé.</param>
        /// <returns>Redirection to Index view.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("delete")]
        public IActionResult ConfirmedDelete(int id)
        {
            var artiste = this.artisteRepository.Find(id);
            this.artisteRepository.Delete(artiste);
            return this.RedirectToAction("Index");
        }
    }
}