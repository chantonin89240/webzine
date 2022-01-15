namespace Webzine.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    /// <summary>
    /// Entité représentant un Titre.
    /// </summary>
    [Table("Titres")]
    public class Titre
    {
        /// <summary>
        /// ID du Titre.
        /// </summary>
        [Key]
        [Column("IdTitre")]
        public int IdTitre { get; set; }

        /// <summary>
        /// ID de l'artiste créateur du Titre.
        /// </summary>
        [Column("IdArtiste")]
        public int IdArtiste { get; set; }

        /// <summary>
        /// Artiste ayant créé le Titre.
        /// </summary>
        [ForeignKey(nameof(IdArtiste))]
        public Artiste? Artiste { get; set; }

        /// <summary>
        /// Libellé/Nom du Titre.
        /// </summary>
        [Display(Name = "Titre")]
        [Required]
        [MinLength(1)]
        [MaxLength(200)]
        [Column("Libelle")]
        public string? Libelle { get; set; }

        /// <summary>
        /// Chronique liée au Titre.
        /// </summary>
        [Required]
        [MinLength(10)]
        [MaxLength(4000)]
        [Column("Chronique")]
        public string? Chronique { get; set; }

        /// <summary>
        /// URL de la Jaquette de l'Album lié au Titre.
        /// </summary>
        [Required]
        [Display(Name = "jaquette de l'album")]
        [MaxLength(250)]
        [Column("UrlJaquette")]
        public string? UrlJaquette { get; set; }

        /// <summary>
        /// Lien pour écouter au Titre.
        /// </summary>
        [Display(Name = "url d'écoute")]
        [MinLength(13)]
        [MaxLength(250)]
        [Column("UrlEcoute")]
        public string? UrlEcoute { get; set; }

        /// <summary>
        /// WARN:TBD.
        /// </summary>
        [Column("Lien")]
        public string? Lien { get; set; }

        /// <summary>
        /// Date de création de la chronique du Titre.
        /// </summary>
        [Required]
        [Display(Name = "date de création")]
        [DataType(DataType.Date)]
        [Column("DateCreation")]
        public DateTime DateCreation { get; set; }

        /// <summary>
        /// Date de la sortie du Titre.
        /// </summary>
        [Required]
        [Display(Name = "date de sortie")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Column("DateSortie")]
        public DateTime DateSortie { get; set; }

        /// <summary>
        /// Durée du titre. En Secondes.
        /// </summary>
        [Display(Name = "durée en secondes")]
        [Column("Duree")]
        public int Duree { get; set; }

        /// <summary>
        /// Nombre de Lectures de la chronique du Titre.
        /// </summary>
        [Required]
        [Display(Name = "nombre de lectures")]
        [Column("NbLectures")]
        public int NbLectures { get; set; }

        /// <summary>
        /// Nombre de Likes du titre.
        /// </summary>
        [Required]
        [Display(Name = "nombre de likes")]
        [Column("NbLikes")]
        public int NbLikes { get; set; }

        /// <summary>
        /// Liste de commentaires lié au Titre.
        /// </summary>
        public IEnumerable<Commentaire> Commentaires { get; set; }

        /// <summary>
        /// Liste de liens aux Styles du titre.
        /// </summary>
        public IEnumerable<TitreStyle> TitresStyles { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Titre"/> class.
        /// </summary>
        public Titre()
        {
            this.Commentaires = new List<Commentaire>();
            this.TitresStyles = new List<TitreStyle>();
            this.Artiste = new Artiste();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Titre"/> class.
        /// </summary>
        /// <param name="idTitre">ID du Titre.</param>
        /// <param name="idArtiste">ID de l'Artiste créateur du Titre.</param>
        /// <param name="artiste">Instance d'<see cref="Webzine.Entity.Artiste"/> créateur du Titre.</param>
        /// <param name="libelle">Nom/Libellé du Titre.</param>
        /// <param name="chronique">Chronique liée au Titre.</param>
        /// <param name="urlJaquette">URL sur la Jaquette de l'album du Titre.</param>
        /// <param name="urlEcoute">URL D'écoute du Titre.</param>
        /// <param name="lien">WARN: TBD</param>
        /// <param name="dateCreation">Date de la création de la chronique du Titre.</param>
        /// <param name="dateSortie">Date de sortie du Titre.</param>
        /// <param name="duree">Durée du Titre en Secondes.</param>
        /// <param name="nbLecture">Nombre de lectures de la chronique.</param>
        /// <param name="nbLike">Nombre de Likes du Titre.</param>
        public Titre(int idTitre, int idArtiste, string libelle, string chronique, string urlJaquette, string urlEcoute, string lien, DateTime dateCreation, DateTime dateSortie, int duree, int nbLecture, int nbLike)
            : this()
        {
            this.IdTitre = idTitre;
            this.IdArtiste = idArtiste;
            this.Libelle = libelle;
            this.Chronique = chronique;
            this.UrlJaquette = urlJaquette;
            this.UrlEcoute = urlEcoute;
            this.Lien = lien;
            this.DateCreation = dateCreation;
            this.DateSortie = dateSortie;
            this.Duree = duree;
            this.NbLectures = nbLecture;
            this.NbLikes = nbLike;
        }
    }
}
