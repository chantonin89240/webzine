using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webzine.Entity.Factory
{
    public class TitreFactory
    {
        public IEnumerable<Titre> CreateTitre()
        {
            return new List<Titre>()
            {
                new Titre{IdTitre = 1, Libelle = "queen", ContenuChronique = "blabla", ImageJacquette = "", Lien = "",
                    DateCreation = new DateTime(2021-12-10), DateSortie =  new DateTime(2021-12-11), Duree = 180, CompteurLecture = 20, CompteurLike = 7 }
            };
        }
    }
}
