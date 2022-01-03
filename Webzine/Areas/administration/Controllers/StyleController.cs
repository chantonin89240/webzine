using Microsoft.AspNetCore.Mvc;
using Webzine.WebApplication.ViewModels;

namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    [Area("administration")]
    public class StyleController : Controller
    {
        TitreViewModel model = new TitreViewModel();
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
            this.model.GetLibelle(idStyle);

            return View(model);
        }

        public IActionResult Suppression(int idStyle)
        {
            this.model.GetLibelle(idStyle);
            return View(model);
        }
    }
}
