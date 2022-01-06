namespace Webzine.WebApplication.ViewModels
{
    using Webzine.Entity;
    using Webzine.Entity.Factory;

    public class HomeViewModel
    {
        public List<Titre> Titres { get;  } = TitreFactory.CreateTitre().ToList();


        public List<Titre> TitresPOP { get; } = TitreFactory.CreateTitre2().ToList();

    }
}
