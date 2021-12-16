using Microsoft.AspNetCore.Mvc;
using Webzine.Entity;
using Webzine.Entity.Factory;

namespace Webzine.ViewModels
{
    public class CommentairesViewModel : Controller
    {
        public List<Commentaire> commentaires { get; set; }

        public void Generate()
        {
            commentaires = CommentaireFactory.CreateCommentaire().ToList();
            //Get all commentaires from DB
        }
    }
}
