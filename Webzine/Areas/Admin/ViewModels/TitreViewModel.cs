namespace Webzine.WebApplication.Areas.Admin.ViewModels
{
    using Webzine.Entity;
    using Webzine.Entity.Factory;

    public class TitreViewModel
    {
        public List<Titre> Titres { get; set; }
        public Titre Titre { get; set; }
        public List<Style> Styles { get; set; }
        public List<Style> stylesTitre { get; set; }
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

        public List<Style> GetStyles()
        {
            this.Styles = StyleFactory.CreateStyle().ToList();

            return this.Styles;
        }

        public List<Artiste> GetArtistes()
        {
            this.Artistes = ArtisteFactory.CreateArtiste().ToList();

            return this.Artistes;
        }

        public List<Style> GetStyle(Titre titre)
        {
            List<Style> styles = StyleFactory.CreateStyle().ToList();
            this.stylesTitre = new List<Style>();

            foreach (var item in titre.TitresStyles)
            {
                this.stylesTitre.Add(styles.First(el => el.IdStyle == item.IdStyle));
            }

            return this.stylesTitre;
        }


    }
}
