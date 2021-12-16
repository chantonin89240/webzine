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
        public int IdArtiste { get; set; }
        public IEnumerable<Artiste> Artiste { get; set; }
        public string Libelle { get; set; }
        public string Chronique { get; set; }
        public string UrlJaquette { get; set; }
        public string UrlEcoute { get; set; }
        public string Lien { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateSortie { get; set; }
        public int Duree { get; set; }
        public int NbLectures { get; set; }
        public int NbLikes { get; set; }
        public IEnumerable<Commentaire> Commentaires { get; set; }
        public IEnumerable<Style> TitresStyles { get; set; }
    }
}
