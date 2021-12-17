using Microsoft.AspNetCore.Mvc;
using Webzine.Entity;
using Webzine.Entity.Factory;

namespace Webzine.ViewModels
{
    public class CommentairesViewModel : Controller
    {
        public List<Commentaire> Commentaires { get; set; }
        public List<Titre> Titres { get; set; }

        public void Generate()
        {
            Commentaires = CommentaireFactory.CreateCommentaire().ToList();
            Titres = TitreFactory.CreateTitre().ToList();
            //Get all commentaires from DB
        }
    }
}
