﻿
namespace Webzine.WebApplication.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.Repository;
    using Webzine.Repository.Contracts;
    using Webzine.ViewModels;
    using Webzine.WebApplication.ViewModels;

    /// <summary>
    /// Contrôleur pour la vue d'Artistes.
    /// </summary>
    public class ArtisteController : Controller
    {
        private IArtisteRepository artisteRepository;
        private ArtisteViewModel model = new ArtisteViewModel();

        /// <summary>
        /// Initialize une nouvelle instance de la classe <see cref="ArtisteController"/>.
        /// prépare les données à utiliser dans la vue.
        /// </summary>
        /// <param name="artisteRepository">Artiste repository model.</param>
        public ArtisteController(IArtisteRepository artisteRepository)
        {
            this.artisteRepository = artisteRepository;
        }

        /// <summary>
        /// Produit la vue Artiste.
        /// </summary>
        /// <param name="nomArtiste">nom de l'Artiste documenté par la vue.</param>
        /// <returns>Vue correspondant à un artiste.</returns>
        public IActionResult Artiste(string nomArtiste)
        {
            string nom = System.Net.WebUtility.UrlDecode(nomArtiste);
            try
            {
                this.model.Artiste = this.artisteRepository.FindAll().First(artiste => artiste.Nom == nom);
                return this.View(this.model);
            }
            catch (Exception)
            {
                return this.Redirect("/");
            }
        }
    }
}
