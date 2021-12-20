namespace Webzine.ViewModels
{
    using Webzine.Entity;
    using Webzine.Entity.Factory;

    public class ArtisteViewModel
    {
        public Artiste Artiste { get; set; }

        public Artiste GetArtiste(int idArtiste)
        {

            this.Artiste = ArtisteFactory.CreateArtiste().ToList().FirstOrDefault(artiste => artiste.IdArtiste == idArtiste);

            return Artiste;
        }
    }
}
