namespace Webzine.WebApplication.Areas.Admin.ViewModels
{
    using Webzine.Entity;

    /// <summary>
    /// Représente le modèle utilisée par les vues d'administration d'<see cref="Artiste"/>s.
    /// </summary>
    public class ArtisteViewModel
    {
        /// <summary>
        /// Liste d'<see cref="Entity.Artiste"/>s utilisé par la vue index.
        /// </summary>
        public List<Artiste> Artistes { get; set; } = new List<Artiste>();

        /// <summary>
        /// <see cref="Entity.Artiste"/> utilisé par le contexte (suppression, modif, création).
        /// </summary>
        public Artiste Artiste { get; set; } = new Artiste();
    }
}
