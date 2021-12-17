using Webzine.Entity;
using Webzine.Entity.Factory;

namespace Webzine.ViewModels
{
    public class DeleteCommentaireViewModel
    {
        public Commentaire Commentaire { get; set; }
        public Titre Titre { get; set; }
        

        public void Acquire(int ID)
        {
            List<Commentaire> commentaires = CommentaireFactory.CreateCommentaire().ToList();
            List<Titre> titres = TitreFactory.CreateTitre().ToList();

            Commentaire = commentaires.FirstOrDefault(comment => comment.IdCommentaire==ID);
            Titre = titres.FirstOrDefault(title => title.IdTitre==Commentaire.IdTitre);


        }



    }
}
