using Microsoft.AspNetCore.Mvc;
using Webzine.WebApplication.ViewModels;

namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    [Area("administration")]
    public class StyleController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Creation()
        {
            return View();
        }

        public IActionResult Edit(int idStyle)
        {
            TitreViewModel viewModel = new TitreViewModel();

            return View(viewModel.GetLibelle(idStyle));
        }

        public IActionResult Suppression(int idStyle)
        {
            TitreViewModel viewModel = new TitreViewModel();

            return View(viewModel.GetLibelle(idStyle));
        }
    }
}
