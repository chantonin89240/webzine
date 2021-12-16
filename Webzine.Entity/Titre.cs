using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webzine.Entity
{
    public class Titre
    {
        public int IdTitre { get; set; }
        public string Libelle { get; set; }
        public string ContenuChronique { get; set; }
        public string ImageJacquette { get; set; }
        public string Lien { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateSortie { get; set; }
        public int Duree { get; set; }
        public int CompteurLecture { get; set; }
        public int CompteurLike { get; set; }
        public Commentaire Commentaire { get; set; }
        public Style Style { get; set; }
    }
}
