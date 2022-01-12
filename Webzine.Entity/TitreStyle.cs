namespace Webzine.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Entité représentant un lien entre un Titre et un Style.
    /// </summary>
    // [Table("TitreStyle")]
    public class TitreStyle
    {
        /// <summary>
        /// ID du Style du lien.
        /// </summary>
        // [Key]
        public int IdStyle { get; set; }

        /// <summary>
        /// ID du Titre du lien.
        /// </summary>
        // [Key]
        public int IdTitre { get; set; }

        /// <summary>
        /// Objet Titre.
        /// </summary>
        // [ForeignKey(nameof(IdTitre))]
        public Titre Titre { get; set; }

        /// <summary>
        /// Objet Style.
        /// </summary>
        // [ForeignKey(nameof(IdStyle))]
        public Style Style { get; set; }

        public TitreStyle(){
            Titre = new Titre();
            Style = new Style();
        }

        public TitreStyle(int idStyle, int idTitre) : this()
        {
            this.IdStyle = idStyle;
            this.IdTitre = idTitre;
        }

    }
}
