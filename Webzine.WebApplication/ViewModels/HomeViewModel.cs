namespace Webzine.WebApplication.ViewModels
{
    using Webzine.Entity;
    using Webzine.Entity.Factory;

    public class HomeViewModel
    {
        public List<Titre> Titres { get; set; } = TitreFactory.CreateTitre2().ToList();
        public List<Titre> TitresPOP { get; set; } = TitreFactory.CreateTitre2().ToList();
        public int Page { get; set; }
        public int titreTotal { get; set; } = 3;

        /// <summary>
        /// retourne ne nombre de page total
        /// </summary>
        /// <param name="titreTotal"></param>
        /// <returns></returns>
        public int pageCount(int titreTotal)
        {
            return Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(this.Titres.Count-1)/titreTotal));
        }

        /// <summary>
        /// retourne la liste des titres par page
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public List<Titre> titrePourPage(int page)
        {
            int countPage = this.pageCount(this.titreTotal);
            if (countPage < page)
            {
                page = countPage;
            }

            List<Titre> output = this.Titres.OrderByDescending(t => t.DateCreation).Chunk(this.titreTotal).ElementAt(page).ToList();

            return output;
        }

    }
}
