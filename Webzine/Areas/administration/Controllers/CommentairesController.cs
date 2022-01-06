namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Webzine.ViewModels;

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
