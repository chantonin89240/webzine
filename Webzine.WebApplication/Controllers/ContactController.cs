namespace Webzine.WebApplication.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// 
    /// </summary>
    public class ContactController : Controller
    {
        public IActionResult Contact()
        {
            return this.View();
            
        }
    }
}
