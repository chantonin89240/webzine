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

        /// <summary>
        /// Objet Titre.
        /// </summary>
        public Titre? Titre { get; set; }

        /// <summary>
        /// Objet Style.
        /// </summary>
        public Style? Style { get; set; }

        public TitreStyle(){
            
        }
        public TitreStyle(int idStyle, int idTitre)
        {
            this.IdStyle = idStyle;
            this.IdTitre = idTitre;
        }

    }
}
