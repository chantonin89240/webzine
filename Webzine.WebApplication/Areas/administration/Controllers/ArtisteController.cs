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
    [Route("[controller]")]
    public class ArtisteController : Controller
    {
        private IArtisteRepository _artisteRepository;
        private ArtisteViewModel model = new ArtisteViewModel();

        public ArtisteController(IArtisteRepository artisteRepository)
        {
            this._artisteRepository = artisteRepository;

        }

        /// <summary>
        /// Renvoie la vue sur chemin "/administration/<see cref="Artiste"/>".
        /// </summary>
        /// <returns>vue d'ensemble de tous les <see cref="Artiste"/>s.</returns>
        [Route("")]
        [HttpGet("[action]")]
        public IActionResult Index()
        {
            this.model.Artistes = this._artisteRepository.FindAll().ToList();
            return this.View(this.model);
        }

        /// <summary>
        /// Renvoie la vue sur chemin "/administration/Artiste/Creation".
        /// </summary>
        /// <returns>Vue pour la création d'un <see cref="Artiste"/>.</returns>
        [HttpGet("[action]")]
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
        [Route("[action]")]
        public IActionResult Create(ArtisteViewModel model)
        {
            try
            {
                // if (this.ModelState.IsValid)
                // {
                    this._artisteRepository.Add(model.Artiste);
                    return this.RedirectToAction(nameof(this.Index));
                // }
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
        /// <param name="idArtiste">Id de l'<see cref="Artiste"/> géré par la vue.</param>
        /// <returns>Vue web pour l'édition d'un <see cref="Artiste"/> qui sera modifié.</returns>
        [HttpGet("[action]")]
        public IActionResult Edit(int id)
        {
            var artiste = this._artisteRepository.Find(id);
            this.model.Artiste = artiste;
            return this.View(this.model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("edit")]
        [Route("[action]")]
        public IActionResult Edit(ArtisteViewModel model, int id)
        {
            try
            {
                // if (this.ModelState.IsValid)
                // {
                    model.Artiste.IdArtiste = id;
                    this._artisteRepository.Update(model.Artiste);
                    return this.RedirectToAction(nameof(this.Index));
                // }
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
        /// <param name="idArtiste">ID de l'<see cref="Artiste"/> à supprimer par la vue.</param>
        /// <returns>Vue web pour la suppression d'un <see cref="Artiste"/>.</returns>
        [HttpGet("[action]")]
        public IActionResult delete(int id)
        {
            var artiste = this._artisteRepository.Find(id);
            this.model.Artiste = artiste;
            return this.View(this.model);
        }

        /// <summary>
        /// Supprime un artiste
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("delete")]
        [Route("[action]")]
        public IActionResult delete(ArtisteViewModel model, int id)
        {
            var artiste = this._artisteRepository.Find(id);
            this._artisteRepository.Delete(artiste);
            return this.RedirectToAction("Index");
        }
    }
}