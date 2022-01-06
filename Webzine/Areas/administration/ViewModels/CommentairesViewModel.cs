namespace Webzine.ViewModels
{
    using Webzine.Entity;
    using Webzine.Entity.Factory;
    using Webzine.Repository;

    public class CommentairesViewModel
    {

        
        /// <summary>
        /// Renvoie ou modifie la base de commentaires utilisée
        /// </summary>
        public List<Commentaire> commentaires { get; set; }

        /// <summary>
        /// Renvoie ou modifie la base de titres utilisée
        /// </summary>
        public List<Titre> titres { get; set; }

        /// <summary>
        /// Récupère ou modifie le commentaire de la vue
        /// </summary>
        public Commentaire contextCommentaire { get; set; }

        /// <summary>
        /// Récupère ou modifie le titre associé au commentaire
        /// </summary>
        public Titre contextTitre { get; set; }

        public CommentairesViewModel()
        {
            this.commentaires = new List<Commentaire>();
            this.titres = new List<Titre>();
        }

        public CommentairesViewModel(IEnumerable<Commentaire> commentaires,IEnumerable<Titre> titres)
        {
            this.commentaires = commentaires.ToList();
            this.titres = titres.ToList();
        }

        public CommentairesViewModel(IEnumerable<Commentaire> commentaires, IEnumerable<Titre> titres, int idCommentaire)
            : this(commentaires, titres)
        {
            contextCommentaire = this.commentaires.FirstOrDefault( C => C.IdCommentaire == idCommentaire);
            contextTitre = this.titres.FirstOrDefault(T => T.IdTitre == contextCommentaire.IdTitre);
        }
    }
}
