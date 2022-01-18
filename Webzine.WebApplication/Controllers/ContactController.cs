namespace Webzine.WebApplication.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Contrôleur pour la page Contact.
    /// </summary>
    public class ContactController : Controller
    {
        /// <summary>
        /// Accesseur à la vue contact.
        /// </summary>
        /// <returns>Vue Contact.</returns>
        public IActionResult Contact()
        {
            return this.View();
        }
    }
}
