namespace Webzine.WebApplication.ViewModels
{
    using Webzine.Entity;

    /// <summary>
    /// Modéle utilisé par la vue "Titre".
    /// </summary>
    public class TitreViewModel
    {
        public List<Titre> Titres { get; set; }

        public string LibelleStyle { get; set; }

        public List<Style> StylesTitre { get; set; }

        public Titre Titre { get; set; }

        /// <summary>
        /// Commentaire utilisé pour gérer l'envoi d'un commentaire au serveur.
        /// </summary>
        public Commentaire Commentaire { get; set; }
    }
}
