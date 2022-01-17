namespace Webzine.ViewModels
{
    using Webzine.Entity;
    using Webzine.Entity.Factory;
    using Webzine.Repository;

    /// <summary>
    /// Modèle utilisé par les vue d'administration des commentaires.
    /// <para>See also: <seealso cref="Webzine.WebApplication.Areas.Admin.Controllers.CommentaireController"/>.</para>
    /// </summary>
    public class CommentairesViewModel
    {
        /// <summary>
        /// Renvoie ou modifie la base de <see cref="Commentaire"/> utilisée dans la page index.
        /// </summary>
        public List<Commentaire> Commentaires { get; set; } = new List<Commentaire>();

        /// <summary>
        /// Renvoie ou modifie la base de titres utilisée.
        /// </summary>
        public List<Titre> Titres { get; set; } = new List<Titre>();

        /// <summary>
        /// Récupère ou modifie le <see cref="Commentaire"/> de la vue de vérification du suppression.
        /// </summary>
        public Commentaire ContextCommentaire { get; set; } = new Commentaire();

        /// <summary>
        /// Récupère ou modifie le titre associé au commentaire.
        /// </summary>
        public Titre ContextTitre { get; set; } = new Titre();
    }
}
