﻿namespace Webzine.WebApplication.Controllers.Components.Sidebar
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.WebApplication.ViewModels;

    /// <summary>
    /// Description du composant.
    /// </summary>
    public class SidebarViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {

            // du code ici, on peut faire comme dans un controller
            // à savoir, récupérer un model et le passer à la vue
            var model = LayoutViewModel.Styles;

            // attention : si cela peut ressembler à un contrôleur, cela n'en
            // est pas un. Le view component ne répond pas à une requête HTTP
            return this.View(model);

            // ou par exemple nomDeMaVue (au lieu de Default.cshtml)
            // return this.View('nomDeMaVue', vm);
        }
    }
}
