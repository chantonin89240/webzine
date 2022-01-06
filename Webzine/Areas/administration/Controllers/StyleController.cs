namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Repository;
    using Webzine.WebApplication.Areas.administration.ViewModels;

    [Area("administration")]
    public class StyleController : Controller
    {
        LocalStyleRepository localStyleRepository = new LocalStyleRepository();

        public IActionResult Index()
        {
            var style = this.localStyleRepository.FindAll().ToList();

            var model = new StyleViewModel()
            {
                Styles = style,
            };
            return this.View(model);
        }

        public IActionResult Creation()
        {
            return this.View();
        }

        public IActionResult Edit(int idStyle)
        {
            var style = this.localStyleRepository.Find(idStyle);

            var model = new StyleViewModel()
            {
                Style = style,
            };
            return this.View(model);
        }

        public IActionResult Suppression(int idStyle)
        {
            var style = this.localStyleRepository.Find(idStyle);

            var model = new StyleViewModel()
            {
                Style = style,
            };
            return this.View(model);
        }
    }
}
