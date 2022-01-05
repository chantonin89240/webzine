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

            return this.View(titre);
        }

        //public IActionResult TitresStyle(int idStyle)
        //{
        //    TitreViewModel model = new TitreViewModel();
        //    model.GetTitres(idStyle).ToList();
        //    model.GetLibelle(idStyle);
        //    List<Style> styles = new List<Style>();
        //    Style style = this.LocalStyleRepository.

        //    return this.View(model);
        //}

    }
}
