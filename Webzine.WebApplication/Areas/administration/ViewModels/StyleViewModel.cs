namespace Webzine.WebApplication.Areas.administration.ViewModels
{
    using Webzine.Entity;

    /// <summary>
    /// Modèle utilisé par les vue d'administration des Styles.
    /// </summary>
    public class StyleViewModel
    {
        /// <summary>
        /// Liste d'<see cref="Entity.Style"/>s utilisé par la vue index.
        /// </summary>
        public List<Style>? Styles { get; set; }

        /// <summary>
        /// <see cref="Entity.Style"/>s utilisé pour l'ajout, la modification et la suppression.
        /// </summary>
        public Style Style { get; set; }
    }
}
