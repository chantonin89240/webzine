using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webzine.ViewModels;

namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    [Area("administration")]
    public class CommentairesController : Controller
    {
        // GET: HomeController
        public ActionResult Index()
        {
            CommentairesViewModel model = new CommentairesViewModel();
            model.Generate();
            return View(model);
        }
    }
}
