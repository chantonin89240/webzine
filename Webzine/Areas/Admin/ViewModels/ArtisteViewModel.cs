namespace Webzine.WebApplication.Areas.Admin.ViewModels
{
    using Webzine.Entity;
    using Webzine.Entity.Factory;

    public class ArtisteViewModel 
    {
        public List<Artiste> Artistes { get; set; }
        public Artiste Artiste { get; set; }

        public List<Artiste> GetArtistes()
        {
            this.Artistes = ArtisteFactory.CreateArtiste().ToList();

            return this.Artistes;
        }

        public Artiste GetArtiste(int idArtiste)
        {
            this.Artiste = ArtisteFactory.CreateArtiste().ToList().FirstOrDefault(artiste => artiste.IdArtiste == idArtiste);

            return this.Artiste;
        }
    }
}
