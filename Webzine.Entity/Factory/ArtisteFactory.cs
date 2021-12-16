using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webzine.Entity.Factory
{
    public class ArtisteFactory
    {
        public IEnumerable<Artiste> CreateArtiste()
        {
            return new List<Artiste>()
            {
                //new Artiste{IdArtiste = 1, Nom = "m", Biographie = "sf"}
            };
        }
    }
}
