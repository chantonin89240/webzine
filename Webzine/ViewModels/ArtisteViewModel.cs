namespace Webzine.ViewModels
{
    using Webzine.Entity;
    using Webzine.Entity.Factory;
    using Webzine.Repository;

    public class ArtisteViewModel
    {
        public Artiste Artiste { get; set; }

        LocalArtisteRepository LocalArtisteRepository = new LocalArtisteRepository();

        public Artiste GetArtiste(int idArtiste)
        {
           return this.Artiste = LocalArtisteRepository.Find(idArtiste);
                // ArtisteFactory.CreateArtiste().ToList().FirstOrDefault(artiste => artiste.IdArtiste == idArtiste);
        }
    }
}
