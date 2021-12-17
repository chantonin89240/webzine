using Microsoft.AspNetCore.Mvc;

namespace Webzine.WebApplication.Controllers
{
    [Area("Admin")]
    public class CommentaireController : Controller
    {
        public IActionResult Index()
        {

            //CommentaireViewModel model = GetCommentaires()

            return View();
        }

        public IActionResult Supprimer()
        {
            return View();
        }

    }
}
