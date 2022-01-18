namespace Webzine.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Entité représentant un Artiste.
    /// </summary>
    [Table("Artistes")]
    public class Artiste
    {
        /// <summary>
        /// ID de l'Artiste.
        /// Non nullable.
        /// </summary>
        [Key]
        [Column("IdArtiste")]
        public int IdArtiste { get; set; }

        /// <summary>
        /// Nom de l'artiste.
        /// </summary>
        [Required(ErrorMessage = "le champ nom est vide.")]
        [MinLength(1, ErrorMessage = "Veuillez saisir le nom de l'artiste (de 1 à 50 caractères).")]
        [MaxLength(50, ErrorMessage = "Veuillez saisir le nom de l'artiste (de 1 à 50 caractères).")]
        [Display(Name = "Nom de l'artiste")]
        [Column("Nom")]
        public string? Nom { get; set; }

        /// <summary>
        /// Biographie de l'artiste.
        /// </summary>
        [Column("Biographie")]
        public string? Biographie { get; set; }

        /// <summary>
        /// Liste des Titres créés par l'artiste.
        /// </summary>
        public IEnumerable<Titre> Titres { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Artiste"/> class.
        /// Initialize une instance de la classe <see cref="Artiste"/>.
        /// </summary>
        public Artiste()
        {
            this.Titres = new List<Titre>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Artiste"/> class.
        /// Initialize une instance de la classe <see cref="Artiste"/>.
        /// </summary>
        /// <param name="id">ID de l'artiste.</param>
        /// <param name="nom">Nom de l'artiste.</param>
        /// <param name="biographie">Biographie de l'artiste.</param>
        public Artiste(int id, string nom, string biographie) : this()
        {
            this.IdArtiste = id;
            this.Nom = nom;
            this.Biographie = biographie;
        }
    }
}