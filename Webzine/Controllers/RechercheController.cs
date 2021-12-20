using Microsoft.AspNetCore.Mvc;
using Webzine.ViewModels;

namespace Webzine.WebApplication.Controllers
{
    public class RechercheController : Controller
    {
        public IActionResult Index()
        {
            string searchedItem = Request.Form["searchedItem"].ToString();
            RechercheViewModel model = new RechercheViewModel(searchedItem);
            //model.Rechercher()

            return View(model);
        }

        //[HttpPost]
        //public IActionResult Rechercher()
        //{


        //    //get recherche viewmodel

        //    return this.View(model);
        //}

    }
}
