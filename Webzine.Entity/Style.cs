namespace Webzine.Entity
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Entité représentant un Style.
    /// </summary>
    [Table("Styles")]
    public class Style
    {
        /// <summary>
        /// ID du Style.
        /// Unique.
        /// </summary>
        [Key]
        [Column("IdStyle")]
        public int IdStyle { get; set; }

        /// <summary>
        /// Libellé / Nom du style.
        /// </summary>
        [Required(ErrorMessage = "Libellé requis.")]
        [MinLength(2, ErrorMessage = "Veuillez saisir un libellé pour votre titre (de 2 à 50 caractères).")]
        [MaxLength(50, ErrorMessage = "Veuillez saisir un libellé pour votre titre (de 2 à 50 caractères).")]
        [Column("Libelle")]
        public string Libelle { get; set; }

        /// <summary>
        /// Liste de liens aux Titres ayant ce Style.
        /// </summary>
        public IEnumerable<TitreStyle> TitresStyles { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Style"/> class.
        /// Initialize une instance de la classe <see cref="Style"/>.
        /// </summary>
        public Style()
        {
            this.TitresStyles = new List<TitreStyle>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Style"/> class.
        /// Initialize une instance de la classe <see cref="Style"/>.
        /// </summary>
        /// <param name="idStyle">ID du Style.</param>
        /// <param name="libelle">Nom/Libellé du Style.</param>
        public Style(int idStyle, string libelle)
            : this()
        {
            this.IdStyle = idStyle;
            this.Libelle = libelle;
        }
    }
}
