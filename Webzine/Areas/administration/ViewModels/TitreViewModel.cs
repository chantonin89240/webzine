namespace Webzine.WebApplication.Areas.Admin.ViewModels
{
    using Webzine.Entity;
    using Webzine.Entity.Factory;

    public class TitreViewModel
    {
        public List<Titre> Titres { get; set; }
        public Titre Titre { get; set; }
        public List<Style> Styles { get; set; }
        public Style Style { get; set; }
        public List<Artiste> Artistes { get; set; }







        public List<Titre> GetTitres()
        {
            this.Titres = TitreFactory.CreateTitre().ToList();

            return this.Titres;
        }

        public Titre GetTitre(int idTitre)
        {
            this.Titre = TitreFactory.CreateTitre().ToList().FirstOrDefault(titre => titre.IdTitre == idTitre);

            return this.Titre;
        }

        public List<Artiste> GetArtistes()
        {
            this.Artistes = ArtisteFactory.CreateArtiste().ToList();

            return this.Artistes;
        }
    }
}
