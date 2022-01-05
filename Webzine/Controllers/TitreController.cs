namespace Webzine.WebApplication.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.Repository;
    using Webzine.WebApplication.ViewModels;

    public class TitreController : Controller
    {
        private LocalTitreRepository LocalTitreRepository = new LocalTitreRepository();
 
        public IActionResult Titre(int idTitre)
        {
            TitreViewModel titre = new TitreViewModel();
            titre.GetTitre(idTitre);
            titre.GetStyles(titre.Titre);

            return this.View(titre);
        }

        public IActionResult TitresStyle(int idStyle)
        {
            TitreViewModel model = new TitreViewModel();
            model.GetTitres(idStyle).ToList();
            model.GetLibelle(idStyle);

            return this.View(model);
        }

    }
}
