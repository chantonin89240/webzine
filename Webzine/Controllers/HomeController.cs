using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webzine.Entity;
using Webzine.Entity.Factory;
using Webzine.Repository;
using Webzine.WebApplication.ViewModels;

namespace Webzine.Controllers
{
    /// <summary>
    /// Page d'accueil.
    /// </summary>
    public class HomeController : Controller
    {
        //private HomeViewModel model = new HomeViewModel();
        private LocalTitreRepository localTitreRepository = new LocalTitreRepository();

        // GET: HomeController
        public IActionResult Index()
        {
            TitreViewModel model = new TitreViewModel()
            {
                Titres = this.localTitreRepository.FindAll().ToList(),
            };
            return this.View(model);
        }
    }
}
