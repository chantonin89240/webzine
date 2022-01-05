namespace Webzine.WebApplication.Areas.Admin.ViewModels
{
    using Webzine.Entity;

    public class TitreViewModel
    {
        public List<Titre> Titres { get; set; }

        public Titre Titre { get; set; }

        public List<Style> Styles { get; set; }

        public Style Style { get; set; }

        public List<Artiste> Artistes { get; set; }
    }
}
