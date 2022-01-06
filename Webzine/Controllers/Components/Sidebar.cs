namespace Webzine.WebApplication.Controllers.Components.Sidebar
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.Repository;
    using Webzine.WebApplication.ViewModels;

    /// <summary>
    /// Description du composant.
    /// </summary>
    public class SidebarViewComponent : ViewComponent
    {
        private List<Style> Styles = new LocalStyleRepository().FindAll().ToList();

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var uri = HttpContext.GetRouteData();
            Console.WriteLine(uri);
            StyleViewModel vm = new StyleViewModel()
            {
                Styles = this.Styles,
            }; 
            return this.View(vm);
        }
    }
}
