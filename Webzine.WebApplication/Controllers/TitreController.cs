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
        private TitreViewModel model = new TitreViewModel();

        public TitreController(ITitreRepository titreRepository, IStyleRepository styleRepository)
        {
            this._titreRepository = titreRepository;
            this._styleRepository = styleRepository;
        }

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
            return this.View(model);
        }

        public IActionResult TitresStyle(string nomStyle)
        {
            this.model.LibelleStyle = System.Net.WebUtility.UrlDecode(nomStyle);
            this.model.Titres = this._titreRepository.SearchByStyle(nomStyle).ToList();
            return this.View(model);
        }

        public IActionResult like(int id)
        {
            Titre titre = this._titreRepository.Find(id);
            this._titreRepository.IncrementNbLikes(titre);

            return this.Redirect("../../Titre/Titre?idTitre=" + id);
        }

                /// <summary>
        /// POST : /titre/liker
        /// action de like un titre.
        /// </summary>
        /// <returns></returns>
        // 
        // public IActionResult Liker(TitreViewModel model)
        // {
        //     try
        //     {
        //         this._titreRepository.IncrementNbLikes(model.Titre);
        //     }
        //     catch (DbUpdateException ex )
        //     {
        //         //Log the error (uncomment ex variable name and write a log).
        //         ModelState.AddModelError("", "Unable to save changes. " +
        //         "Try again, and if the problem persists " +
        //         "see your system administrator.");
        //     }
        // }
    }
}