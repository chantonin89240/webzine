namespace Webzine.WebApplication.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.Repository.Contracts;
    using Webzine.WebApplication.ViewModels;

    public class TitreController : Controller
    {
        private ITitreRepository _titreRepository;
        private IStyleRepository _styleRepository;
        private ICommentaireRepository _commentaireRepository;
        private TitreViewModel model = new TitreViewModel();

        public TitreController(ICommentaireRepository commentaireRepository, ITitreRepository titreRepository, IStyleRepository styleRepository)
        {
            this._commentaireRepository = commentaireRepository;
            this._titreRepository = titreRepository;
            this._styleRepository = styleRepository;
        }

        // public IActionResult Titre(int idTitre, string artisteNom, string titreNom)

        [ActionName("titre")]
        public IActionResult Titre(int idTitre)
        {
            Titre titre = this._titreRepository.Find(idTitre);
            this.model.Titre = titre;
            this._titreRepository.IncrementNbLectures(titre);
            this.model.StylesTitre = new List<Style>();
            this.model.Commentaire = new Commentaire()
            {
                IdTitre = titre.IdTitre,
                Titre = titre,
            };
            this.model.Titre.TitresStyles.ToList().ForEach(ts => model.StylesTitre.Add(this._styleRepository.Find(ts.IdStyle)));
            return this.View(this.model);
        }

        public IActionResult TitresStyle(string nomStyle)
        {
            this.model.LibelleStyle = System.Net.WebUtility.UrlDecode(nomStyle);
            this.model.Titres = this._titreRepository.SearchByStyle(nomStyle).ToList();
            return this.View(this.model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("liker")]
        public IActionResult Liker(TitreViewModel model)
        {
            Titre titre = this._titreRepository.Find(model.Titre.IdTitre);
            this._titreRepository.IncrementNbLikes(titre);

            return this.RedirectToAction("Titre", new {idTitre = model.Titre.IdTitre});
        }

        /// <summary>
        /// Méthode pour envoyer un commentaire.
        /// </summary>
        /// <param name="comment"><see cref="Commentaire"/> envoyé.</param>
        /// <returns>Renvoie sur la page titre.</returns>
        [HttpPost]
        [ActionName("commenter")]
        public ActionResult Comment(Commentaire comment)
        {
            if (this.ModelState.IsValid)
            {
                // Send to Model to save into DB.
                // WARN: IT WON'T HAVE IT'S CommentaireId SET!
                comment.DateCreation = DateTime.Now;
                comment.Titre = this._titreRepository.Find(comment.IdTitre);
                this._commentaireRepository.Add(comment);
                return this.RedirectToAction("Titre", new { idTitre = comment.IdTitre });
            }

            Titre titre = this._titreRepository.Find(comment.IdTitre);
            this.model.Titre = titre;
            this._titreRepository.IncrementNbLectures(titre);
            this.model.StylesTitre = new List<Style>();
            this.model.Titre.TitresStyles.ToList().ForEach(ts => model.StylesTitre.Add(this._styleRepository.Find(ts.IdStyle)));
            this.model.Commentaire = comment;
            return this.View("Titre", this.model);
        }
    }
}