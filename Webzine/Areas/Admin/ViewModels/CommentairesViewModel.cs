using Webzine.Entity;
using Webzine.Entity.Factory;

namespace Webzine.ViewModels
{
    public class CommentairesViewModel
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
            //Get all commentaires from DB
        }
    }
}
