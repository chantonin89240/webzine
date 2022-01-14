namespace Webzine.WebApplication.ViewModels
{
    using Webzine.Entity;

    /// <summary>
    /// Modéle utilisé par la vue "Titre".
    /// </summary>
    public class TitreViewModel
    {
        public List<Titre> Titres { get; set; }
        public List<Titre> TitresPopulaires { get; set; }

        public string LibelleStyle { get; set; }

        public List<Style> StylesTitre { get; set; }

        public int Page { get; set; }

        public int PageMax { get; set; }


        public Titre Titre { get; set; }

        /// <summary>
        /// Commentaire utilisé pour gérer l'envoi d'un commentaire au serveur.
        /// </summary>
        public Commentaire? Commentaire { get; set; }

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

        /// <summary>
        /// Retourne le nombre de page total.
        /// </summary>
        /// <param name="titreTotal"></param>
        /// <returns></returns>
        public int PageCount(int titreTotal)
        {   
            // var p = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(this.Titres.Count)/titreTotal));

            return (this.Titres.Count() - 1 / titreTotal) - (((this.Titres.Count() - 1) / titreTotal) % 1);
        }

        public string PreviewString(string longString)
        {
            if (longString.Length > 160)
            {
                return longString.Substring(0, 157) + "...";
            }
            return longString;
        }
    }
}
