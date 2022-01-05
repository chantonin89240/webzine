namespace Webzine.WebApplication.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.Repository;
    using Webzine.WebApplication.ViewModels;

    public class TitreController : Controller
    {
        LocalTitreRepository LocalTitreRepository = new LocalTitreRepository();
        LocalStyleRepository LocalStyleRepository = new LocalStyleRepository();

        public IActionResult Titre(int idTitre)
        {
            Titre titre = this.LocalTitreRepository.Find(idTitre);
            TitreViewModel model = new TitreViewModel()
            {
                Titre = titre,
                stylesTitre = new List<Style>(),
                commentaire = new Commentaire()
                {
                    IdTitre = titre.IdTitre,
                    Titre = titre,
                },
            };
            titre.TitresStyles.ForEach(ts => model.stylesTitre.Add(this.LocalStyleRepository.Find(ts.IdStyle)));
            //model.PrepareCommentaire();

            return this.View(model);
        }

        public IActionResult TitresStyle(int idStyle)
        {
            TitreViewModel model = new TitreViewModel();
            model.Titres = this.LocalTitreRepository.
            model.GetLibelle(idStyle);
            List<Style> styles = new List<Style>();
            Style style = this.LocalStyleRepository.

            return this.View(model);
        }

    }
}
