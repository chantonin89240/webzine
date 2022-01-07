namespace Webzine.WebApplication.ViewModels
{
    using Webzine.Entity;
    using Webzine.Entity.Factory;

    public class HomeViewModel
    {
        public List<Titre> Titres { get;  } = TitreFactory.CreateTitre().Take(3).ToList();


        public List<Titre> TitresPOP { get; } = TitreFactory.CreateTitre2().ToList();

    }
}
