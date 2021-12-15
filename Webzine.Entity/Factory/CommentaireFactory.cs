﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webzine.Entity.Factory
{
    public class CommentaireFactory
    {
        public IEnumerable<Commentaire> CreateCommentaire()
        {
            return new List<Commentaire>()
            {
                new Commentaire{IdCommentaire = 1, Pseudo = "marc", Contenu = "trop bien", DateCreation = new DateTime(2021-12-03)},
                new Commentaire{IdCommentaire = 2, Pseudo = "luke", Contenu = "pas mal", DateCreation = new DateTime(2021-12-04)},
                new Commentaire{IdCommentaire = 3, Pseudo = "chantal", Contenu = "pas ouf", DateCreation = new DateTime(2021-12-11)}
            };
        }
    }
}
