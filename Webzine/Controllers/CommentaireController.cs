namespace Webzine.WebApplication.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.Repository;

    public class CommentaireController : Controller
    {
        private LocalCommentaireRepository localCommentaireRepository = new LocalCommentaireRepository();
        private LocalTitreRepository localTitreRepository = new LocalTitreRepository();

        [HttpPost]
        public ActionResult Index(Commentaire model)
        {

            if (this.ModelState.IsValid)
            {
                // Send to Model to save into DB.
                // WARN: IT WON'T HAVE IT'S CommentaireId SET!
                model.DateCreation = DateTime.Now;
                model.Titre = this.localTitreRepository.Find(model.IdTitre);
                this.localCommentaireRepository.Add(model);

            }
            return this.Redirect("Titre/Titre?idTitre=" + model.IdTitre);
        }
    }
}
