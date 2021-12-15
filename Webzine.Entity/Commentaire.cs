using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webzine.Entity
{
    public class Commentaire
    {
        public int IdCommentaire { get; set; }
        public string Pseudo { get; set; }
        public string Contenu { get; set; }
        public DateTime DateCreation { get; set; }
    }
}
