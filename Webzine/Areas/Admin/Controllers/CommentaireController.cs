using Microsoft.AspNetCore.Mvc;
using Webzine.ViewModels;

namespace Webzine.WebApplication.Controllers
{
    [Area("Admin")]
    public class CommentaireController : Controller
    {
        public IActionResult Index()
        {

            CommentairesViewModel model = new CommentairesViewModel();
            model.Generate();
            return View(model);
        }

        public IActionResult Supprimer(int id)
        {
            DeleteCommentaireViewModel model= new DeleteCommentaireViewModel();
            model.Acquire(id);

            return View(model);
        }

    }
}
