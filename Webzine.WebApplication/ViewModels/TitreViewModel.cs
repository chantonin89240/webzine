namespace Webzine.WebApplication.ViewModels
{
    using Webzine.Entity;

    /// <summary>
    /// Modéle utilisé par la vue "Titre".
    /// </summary>
    public class TitreViewModel
    {
        // NEEDS FURTHER REVIEW WITH ANTONIN!


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

        /// <summary>
        /// Formate la durée d'un Titre sous forme "?M:SS".
        /// </summary>
        /// <param name="titre">title to format</param>
        /// <returns>Chaine de charactères sous format "?M:SS".</returns>
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
        /// <param name="titreTotal">Quantité de titres sur une page.</param>
        /// <returns>Quantité de pages qui contiennent des titres.</returns>
        public int PageCount(int titreTotal)
        {
            // var p = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(this.Titres.Count)/titreTotal));

            return (this.Titres.Count() - (1 / titreTotal)) - (((this.Titres.Count() - 1) / titreTotal) % 1);
        }

        /// <summary>
        /// Modifie la taille d'une chaine de charactères sous 160 charactères. Utilisé pour prévoir la chronique d'un titre.
        /// </summary>
        /// <param name="longString">Longue chaine de caractères a raccourcir (si besoin).</param>
        /// <returns>Chaine de caractères égale ou plus petite que 160 caractères.</returns>
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
