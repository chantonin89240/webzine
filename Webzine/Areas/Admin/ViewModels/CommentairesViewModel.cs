using Microsoft.AspNetCore.Mvc;
using Webzine.Entity;
using Webzine.Entity.Factory;

namespace Webzine.ViewModels
{
    public class CommentairesViewModel : Controller
    {
        /// <summary>
        /// Renvoie ou modifie la base de commentaires utilisée
        /// </summary>
        public List<Commentaire> Commentaires { get; set; }

        /// <summary>
        /// Renvoie ou modifie la base de titres utilisée
        /// </summary>
        public List<Titre> Titres { get; set; }

        /// <summary>
        /// Remplit toute la base du viewModel avec les données des Factory correspondant.
        /// Mettre à jour dés que la BDD est en place!!!
        /// </summary>
        public void Generate()
        {
            Commentaires = CommentaireFactory.CreateCommentaire().ToList();
            Titres = TitreFactory.CreateTitre().ToList();

            // Get all commentaires from DB HERE
        }
        /// <summary>
        /// Récupère ou modifie le commentaire de la vue
        /// </summary>
        public Commentaire ContextCommentaire { get; set; }

        /// <summary>
        /// Récupère ou modifie le titre associé au commentaire
        /// </summary>
        public Titre ContextTitre { get; set; }

        /// <summary>
        /// Récupère un commentaire et son titre correspondant
        /// </summary>
        /// <param name="id"> ID du commentaire </param>
        public void Acquire(int id)
        {
            List<Commentaire> commentaires = CommentaireFactory.CreateCommentaire().ToList();
            List<Titre> titres = TitreFactory.CreateTitre().ToList();

            ContextCommentaire = commentaires.FirstOrDefault(comment => comment.IdCommentaire == id);
            ContextTitre = titres.FirstOrDefault(title => title.IdTitre == ContextCommentaire.IdTitre);

        }
    }
}
