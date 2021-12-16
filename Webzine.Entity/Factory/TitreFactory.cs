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
                new Titre{IdTitre = 1, IdArtiste = 1, Artiste = new Artiste(), Libelle = "queen", Chronique = "blabla", UrlJaquette = "", UrlEcoute = "", Lien = "",DateCreation = new DateTime(2021-12-10), DateSortie =  new DateTime(2021-12-11), Duree = 180, NbLectures = 20, NbLikes = 7, Commentaires = new List<Commentaire>(), TitresStyles = new List<TitreStyle>()}
            };
        }
    }
}
