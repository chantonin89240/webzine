namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.ViewModels;

    [Area("administration")]
    public class CommentaireController : Controller
    {
        public IActionResult Index()
        {

            CommentairesViewModel model = new CommentairesViewModel();
            model.Generate();
            return this.View(model);
        }

        public IActionResult delete(int id)
        {
            CommentairesViewModel model = new CommentairesViewModel();
            model.Acquire(id);

            return this.View(model);
        }

    }
}
