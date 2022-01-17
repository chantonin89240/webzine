namespace Webzine.WebApplication.ViewModels
{
    using Webzine.Entity;

    /// <summary>
    /// Représente les données utilisées par la sidebar.
    /// </summary>
    public class StyleViewModel
    {
        public List<Style> Styles { get; set; }

        public Style Style { get; set; }
    }
}
