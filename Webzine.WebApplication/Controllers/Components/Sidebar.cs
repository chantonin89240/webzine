namespace Webzine.WebApplication.Controllers.Components.Sidebar
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Repository.Contracts;
    using Webzine.WebApplication.ViewModels;

    /// <summary>
    /// Description du composant.
    /// </summary>
    public class SidebarViewComponent : ViewComponent
    {
        private IStyleRepository _styleRepository;
        private StyleViewModel model = new StyleViewModel();

        public SidebarViewComponent(IStyleRepository styleRepository)
        {
            this._styleRepository = styleRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            this.model.Styles = this._styleRepository.FindAll().ToList();
            return this.View(this.model);
        }
    }
}
