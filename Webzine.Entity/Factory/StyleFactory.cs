using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webzine.Entity.Factory
{
    public class StyleFactory
    {
        public IEnumerable<Style> CreateStyle()
        {
            return new List<Style>()
            {
                //new Style{IdStyle = 1, Libelle = "pop"},
                //new Style{IdStyle = 2, Libelle = "jazz"},
                //new Style{IdStyle = 3, Libelle = "rock"}
            };
        }
    }
}
