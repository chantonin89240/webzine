namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.Repository;
    using Webzine.ViewModels;

    /// <summary>
    /// Contrôleur des vues en rapport aux <see cref="Commentaire"/>s.
    /// </summary>
    [Area("administration")]
    public class CommentaireController : Controller
    {
        private LocalCommentaireRepository commentaireRepository = new LocalCommentaireRepository();
        private LocalTitreRepository titreRepository = new LocalTitreRepository();

        /// <summary>
        /// Génère la page listant tous les <see cref="Commentaire"/>s dans la partie Administrateur.
        /// </summary>
        /// <returns>Page de tous les <see cref="Commentaire"/>s.</returns>
        public IActionResult Index()
        {
            List<Commentaire> commentaires = this.commentaireRepository.FindAll().ToList();
            List<Titre> titres = this.titreRepository.FindAll().ToList();

            CommentairesViewModel model = new CommentairesViewModel(commentaires, titres);
            return this.View(model);
        }

        /// <summary>
        /// Génère la vue de vérification de l'effacement d'un <see cref="Commentaire"/>.
        /// </summary>
        /// <param name="id">id du <see cref="Commentaire"/> qui sera effacé.</param>
        /// <returns>Page web de vérification.</returns>
        [ActionName("suppression")]
        public IActionResult Suppression(int id)
        {
            List<Commentaire> commentaires = this.commentaireRepository.FindAll().ToList();
            List<Titre> titres = this.titreRepository.FindAll().ToList();

            Commentaire? contextComment = commentaires.FirstOrDefault(comm => comm.IdCommentaire == id);

            CommentairesViewModel model = new CommentairesViewModel()
            {
                Commentaires = commentaires,
                Titres = titres,
                ContextCommentaire = contextComment,
                ContextTitre = titres.FirstOrDefault(title => title.Commentaires.Contains(contextComment)),
            };

            return this.View(model);
        }

    }
}
