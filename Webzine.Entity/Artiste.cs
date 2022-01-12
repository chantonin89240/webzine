namespace Webzine.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Entité représentant un Artiste.
    /// </summary>
    // [Table("Artiste")]
    public class Artiste
    {
        /// <summary>
        /// ID de l'Artiste.
        /// Non nullable.
        /// </summary>
        [Key]
        public int IdArtiste { get; set; }

        /// <summary>
        /// Nom de l'artiste.
        /// </summary>
        [MinLength(1)]
        [MaxLength(50)]
        [Display(Name = "Nom de l'artiste")]
        public string? Nom { get; set; }

        /// <summary>
        /// Biographie de l'artiste.
        /// </summary>
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