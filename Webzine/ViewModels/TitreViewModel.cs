namespace Webzine.WebApplication.ViewModels
{
    using Webzine.Entity;
    using Webzine.Entity.Factory;
    using Webzine.Repository;
    /// <summary>
    /// Modéle utilisé par la vue "Titre".
    /// </summary>
    public class TitreViewModel
    {
        public List<Titre> Titres { get; set; }

        public string LibelleStyle { get; set; }

        public List<Style> stylesTitre { get; set; }

        public Titre Titre { get; set; }

        /// <summary>
        /// Commentaire utilisé pour gérer l'envoi d'un commentaire au serveur.
        /// </summary>
        public Commentaire commentaire { get; set; }

        public Titre DisplayTitre(Titre titre)
        {
            return titre;
        }

        public List<Style> GetStyles(Titre titre)
        {
            List<Style> styles = StyleFactory.CreateStyle().ToList();
            stylesTitre = new List<Style>();

            foreach (var item in titre.TitresStyles)
            {
               stylesTitre.Add(styles.First(el => el.IdStyle == item.IdStyle));
            }

            return stylesTitre;
        }

        public IEnumerable<Titre> GetTitres(int idStyle)
        {
            Titres = TitreFactory.CreateTitre2().ToList().FindAll(titre => titre.TitresStyles.Exists(ts => ts.IdStyle == idStyle));
            return Titres;
        }

        public string GetLibelle(int idStyle)
        {
            LibelleStyle = StyleFactory.CreateStyle().First(el => el.IdStyle == idStyle).Libelle;
            return LibelleStyle;
        }

        /// <summary>
        /// Génère les données du commentaire après que le modèle soit préparé.
        /// </summary>
        public void PrepareCommentaire()
        {
            commentaire = new Commentaire();
            commentaire.Titre = Titre;
            commentaire.IdTitre = Titre.IdTitre;
        }
    }
}
