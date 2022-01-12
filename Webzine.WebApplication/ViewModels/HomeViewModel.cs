namespace Webzine.WebApplication.ViewModels
{
    using Webzine.Entity;
    using Webzine.Entity.Factory;

    public class HomeViewModel
    {
        public List<Titre> Titres { get; set; } = TitreFactory.CreateTitre().ToList();


        public List<Titre> TitresPOP { get; set; } = TitreFactory.CreateTitre2().ToList();


        public int pageCount(int titreTotal)
        {
            return (Titres.Count() / titreTotal) - ((Titres.Count() / titreTotal) % 1) +1;
        }

        public List<Titre> titrePourPage(int titreTotal, int page)
        {
            List<Titre> output = (List<Titre>)this.Titres.Chunk(titreTotal).ElementAt(page).ToList().OrderBy(t => t.DateCreation);

            return output;
        }

    }
}
