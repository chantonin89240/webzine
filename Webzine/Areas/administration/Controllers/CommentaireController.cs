namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.ViewModels;
    using Webzine.Repository;
    using Webzine.Entity;

    [Area("administration")]
    public class CommentaireController : Controller
    {
        private LocalCommentaireRepository _commentaireRepository = new LocalCommentaireRepository();
        private LocalTitreRepository _titreRepository = new LocalTitreRepository();

        public IActionResult Index()
        {
            List<Commentaire> commentaires = _commentaireRepository.FindAll().ToList();
            List<Titre> titres = _titreRepository.FindAll().ToList();

            CommentairesViewModel model = new CommentairesViewModel(commentaires, titres);
            return this.View(model);
        }

        public IActionResult delete(int id)
        {
            List<Commentaire> commentaires = _commentaireRepository.FindAll().ToList();
            List<Titre> titres = _titreRepository.FindAll().ToList();

            CommentairesViewModel model = new CommentairesViewModel(commentaires, titres, id);
            

            return this.View(model);
        }

    }
}
