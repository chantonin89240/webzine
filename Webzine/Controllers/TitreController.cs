namespace Webzine.WebApplication.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.Repository;
    using Webzine.WebApplication.ViewModels;

    public class TitreController : Controller
    {
        LocalTitreRepository LocalTitreRepository = new LocalTitreRepository();
        LocalStyleRepository LocalStyleRepository = new LocalStyleRepository();

        [ActionName("titre")]
        public IActionResult Titre(int idTitre)
        {
            Titre titre = this.LocalTitreRepository.Find(idTitre);
            TitreViewModel model = new TitreViewModel()
            {
                Titre = titre,
                StylesTitre = new List<Style>(),
                Commentaire = new Commentaire()
                {
                    IdTitre = titre.IdTitre,
                    Titre = titre,
                },
            };
            titre.TitresStyles.ForEach(ts => model.StylesTitre.Add(this.LocalStyleRepository.Find(ts.IdStyle)));
            return this.View(model);
        }

        public IActionResult TitresStyle(int idStyle)
        {
            TitreViewModel model = new TitreViewModel()
            {
                LibelleStyle = this.LocalStyleRepository.Find(idStyle).Libelle,
            };
            model.Titres = this.LocalTitreRepository.SearchByStyle(model.LibelleStyle).ToList();
            return this.View(model);
        }

        public IActionResult like(int id)
        {
            Titre titre = this.LocalTitreRepository.Find(id);
            this.LocalTitreRepository.IncrementNbLikes(titre);

            return this.Redirect("../../Titre/Titre?idTitre=" + id);
        }
    }
}