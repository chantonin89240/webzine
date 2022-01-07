namespace Webzine.Entity
{
    /// <summary>
    /// Entité représentant un lien entre un Titre et un Style.
    /// </summary>
    public class TitreStyle
    {
        /// <summary>
        /// ID du Style du lien.
        /// </summary>
        public int IdStyle { get; set; }

        /// <summary>
        /// ID du Titre du lien.
        /// </summary>
        public int IdTitre { get; set; }
    }
}
