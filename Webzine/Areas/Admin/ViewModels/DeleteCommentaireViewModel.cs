namespace Webzine.ViewModels
{
    using Webzine.Entity;
    using Webzine.Entity.Factory;

    /// <summary>
    /// Modèle correspondant à la vue d'effacement d'un commentaire.
    /// </summary>
    public class DeleteCommentaireViewModel
    {
        /// <summary>
        /// Récupère ou modifie le commentaire de la vue
        /// </summary>
        public Commentaire Commentaire { get; set; }

        /// <summary>
        /// Récupère ou modifie le titre associé au commentaire
        /// </summary>
        public Titre Titre { get; set; }
        
        /// <summary>
        /// Récupère un commentaire et son titre correspondant
        /// </summary>
        /// <param name="id"> ID du commentaire </param>
        public void Acquire(int id)
        {
            List<Commentaire> commentaires = CommentaireFactory.CreateCommentaire().ToList();
            List<Titre> titres = TitreFactory.CreateTitre().ToList();

            Commentaire = commentaires.FirstOrDefault(comment => comment.IdCommentaire==id);
            Titre = titres.FirstOrDefault(title => title.IdTitre==Commentaire.IdTitre);


        }



    }
}
