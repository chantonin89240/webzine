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

        public string FormatLength(Titre titre)
        {
            string output = ((titre.Duree - (titre.Duree % 60)) / 60) + ":";
            if (titre.Duree % 60 < 10)
            {
                output += "0";
            }

            output += (titre.Duree % 60).ToString();
            return output;
        }
    }
}
