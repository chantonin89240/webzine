using Webzine.Entity;
using Webzine.Entity.Factory;

namespace Webzine.WebApplication.ViewModels
{
    public class TitreViewModel
    {
        public Titre GetTitre(int idTitre)
        {
            Titre titre = TitreFactory.CreateTitre().ToList().FirstOrDefault(el => el.IdTitre == idTitre);
            return titre;
        }
    }
}
