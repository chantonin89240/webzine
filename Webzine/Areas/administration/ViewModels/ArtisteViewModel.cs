namespace Webzine.WebApplication.Areas.Admin.ViewModels
{
    using Webzine.Entity;
    using Webzine.Entity.Factory;

    public class ArtisteViewModel 
    {
        public List<Artiste> Artistes { get; set; }

        public Artiste Artiste { get; set; }
    }
}
