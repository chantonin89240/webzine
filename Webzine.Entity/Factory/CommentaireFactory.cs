using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webzine.Entity.Factory
{
    public static class CommentaireFactory
    {
        public static IEnumerable<Commentaire> CreateCommentaire()
        {
            return new List<Commentaire>()
            {
                new Commentaire{IdCommentaire = 1, Auteur = "marc", Contenu = "trop bien", DateCreation = new DateTime(2021-12-03), IdTitre=1},
                new Commentaire{IdCommentaire = 2, Auteur = "luke", Contenu = "pas mal", DateCreation = new DateTime(2021-12-04), IdTitre=1},
                new Commentaire{IdCommentaire = 3, Auteur = "chantal", Contenu = "pas ouf", DateCreation = new DateTime(2021-12-11), IdTitre=1},
            };
        }
    }
}
