namespace Webzine.WebApplication.ViewModels
{
    using Webzine.Entity;
    using Webzine.Entity.Factory;

    public class TitreViewModel
    {
        public List<Titre> Titres { get; set; }

        public string LibelleStyle { get; set; }

        public List<Style> stylesTitre { get; set; }

        public Titre Titre { get; set; }

        public Commentaire commentaire { get; set; }

        public Titre GetTitre(int idTitre)
        {

            this.Titre = TitreFactory.CreateTitre().ToList().FirstOrDefault(titre => titre.IdTitre == idTitre);

            return Titre;
        }

        public List<Style> GetStyles(Titre titre)
        {
            List<Style> styles = StyleFactory.CreateStyle().ToList();
            this.stylesTitre = new List<Style>();

            foreach (var item in titre.TitresStyles)
            {
                this.stylesTitre.Add(styles.First(el => el.IdStyle == item.IdStyle));
            }

            return this.stylesTitre;
        }

        public IEnumerable<Titre> GetTitres(int idStyle)
        {
            this.Titres = TitreFactory.CreateTitre2().ToList().FindAll(titre => titre.TitresStyles.Exists(ts => ts.IdStyle == idStyle));
            return Titres;
        }

        public string GetLibelle(int idStyle)
        {
            this.LibelleStyle = StyleFactory.CreateStyle().First(el => el.IdStyle == idStyle).Libelle;
            return this.LibelleStyle;
        }

        public void PrepareCommentaire()
        {
            this.commentaire = new Commentaire();
            this.commentaire.Titre = this.Titre;
            this.commentaire.IdTitre = this.Titre.IdTitre;
        }
    }
}
