namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.Repository.Contracts;
    using Webzine.ViewModels;

    /// <summary>
    /// Contrôleur des vues en rapport aux <see cref="Commentaire"/>s.
    /// </summary>
    [Area("administration")]
    public class CommentaireController : Controller 
    {
        private ICommentaireRepository commentaireRepository;
        private ITitreRepository titreRepository;
        private CommentairesViewModel model;

        // contructeur de CommentaireController
        public CommentaireController(ICommentaireRepository commentaireRepository, ITitreRepository titreRepository)
        {
            this.commentaireRepository = commentaireRepository;
            this.titreRepository = titreRepository;
            this.model = new CommentairesViewModel();
        }

        /// <summary>
        /// Génère la page listant tous les <see cref="Commentaire"/>s dans la partie Administrateur.
        /// </summary>
        /// <returns>Page de tous les <see cref="Commentaire"/>s.</returns>
        public IActionResult Index()
        {
            this.model.Commentaires = this.commentaireRepository.FindAll().ToList();
            this.model.Titres = this.titreRepository.FindAll().ToList();
            return this.View(this.model);
        }

        /// <summary>
        /// Génère la vue de vérification de l'effacement d'un <see cref="Commentaire"/>.
        /// </summary>
        /// <param name="id">id du <see cref="Commentaire"/> qui sera effacé.</param>
        /// <returns>Page web de vérification.</returns>
        [ActionName("delete")]
        public IActionResult Delete(int id)
        {
            this.model.ContextCommentaire = this.commentaireRepository.Find(id);
            this.model.ContextTitre = this.titreRepository.Find(this.model.ContextCommentaire.IdTitre);

            return this.View(this.model);
        }

        /// <summary>
        /// Supprime un Commentaire dans la base de donnée.
        /// </summary>
        /// <param name="id">ID du commentaire à effacer.</param>
        /// <returns>Vue Index.</returns>
        [HttpPost]
        [ActionName("delete")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmedDelete(int id)
        {
            this.commentaireRepository.Delete(id);
            return this.RedirectToAction("Index");
        }
    }
}
