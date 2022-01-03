using Microsoft.AspNetCore.Mvc;
using Webzine.ViewModels;

namespace Webzine.WebApplication.Controllers
{
    [Area("administration")]
    public class CommentaireController : Controller
    {
        public IActionResult Index()
        {

            CommentairesViewModel model = new CommentairesViewModel();
            model.Generate();
            return View("Commentaires",model);
        }

        public IActionResult delete(int id)
        {
            CommentairesViewModel model = new CommentairesViewModel();
            model.Acquire(id);

            return View(model);
        }

    }
}
