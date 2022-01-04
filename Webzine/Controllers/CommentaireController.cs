namespace Webzine.WebApplication.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;

    public class CommentaireController : Controller
    {
        [HttpPost]
        public ActionResult Index(Commentaire model)
        {

            if (this.ModelState.IsValid)
            {
                // Send to Model to save into DB.
                // WARN: IT WON'T HAVE IT'S TIME, OR IT'S CommentaireId SET!
            }

            return this.Redirect("Titre/Titre?idTitre=" + model.IdTitre);
        }
    }
}
