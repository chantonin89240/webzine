using Webzine.Entity;
using Webzine.Entity.Factory;

namespace Webzine.WebApplication.ViewModels
{
    public class HomeViewModel
    {
        public List<Titre> Titres { get;  } = TitreFactory.CreateTitre().ToList();


        public List<Titre> TitresPOP { get; } = TitreFactory.CreateTitre2().ToList();

    }
}
