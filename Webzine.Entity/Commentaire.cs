namespace Webzine.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    /// <summary>
    /// Entité pour gérer les données d'un commentaire.
    /// </summary>
    [Table("Commentaires")]
    public class Commentaire
    {
        /// <summary>
        /// ID du commentaire.
        /// Unique.
        /// Non Null.
        /// </summary>
        [Key]
        [Column("IdCommentaire")]
        public int IdCommentaire { get; set; }

        /// <summary>
        /// Auteur du commentaire.
        /// Non Null.
        /// </summary>
        [Display(Name = "Nom")]
        [Required(ErrorMessage = "Merci de renseigner un nom.")]
        [MinLength(2, ErrorMessage = "Une seule lettre n'est pas un nom.")]
        [MaxLength(30, ErrorMessage = "Longueur de nom maximum: 30 caractères.")]
        [Column("Auteur")]
        public string? Auteur { get; set; }

        /// <summary>
        /// Contenu du commentaire.
        /// Non Null.
        /// </summary>
        [Display(Name = "Commentaire")]
        [Required(ErrorMessage = "Merci d'écrire votre commentaire.")]
        [MinLength(10, ErrorMessage = "Un commentaire contient au moins 10 caractères.")]
        [MaxLength(1000, ErrorMessage = "Commentaire trop long: maximum 1000 caractères.")]
        [Column("Contenu")]
        public string? Contenu { get; set; }

        /// <summary>
        /// Date de création du commentaire.
        /// Non Null.
        /// </summary>
        [Required]
        [Display(Name = "Date de création")]
        [DataType(DataType.Date)]
        [Column("DateCreation")]
        public DateTime DateCreation { get; set; }

        /// <summary>
        /// ID du titre ou est créé le commentaire.
        /// </summary>
        [Column("IdTitre")]
        public int IdTitre { get; set; }

        /// <summary>
        /// Titre ou est créé le commentaire.
        /// </summary>
        [ForeignKey(nameof(IdTitre))]
        public Titre? Titre { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Commentaire"/> class.
        /// Initialize une nouvelle instance de la classe <see cref="Commentaire"/>.
        /// </summary>
        public Commentaire()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Commentaire"/> class.
        /// Initialize une nouvelle instance de la classe <see cref="Commentaire"/>.
        /// </summary>
        /// <param name="id">Valeur d'Identification du commentaire.</param>
        /// <param name="auteur">Auteur de commentaire.</param>
        /// <param name="contenu">Contenu du commentaire.</param>
        /// <param name="date">Date de création du Commentaire.</param>
        /// <param name="idTitre">ID du titre ou le commentaire a été fait.</param>
        /// <param name="titre">Titre ou le commentaire a été fait.</param>
        public Commentaire(int id, string auteur, string contenu, DateTime date, int idTitre, Titre titre)
        {
            this.IdCommentaire = id;
            this.Auteur = auteur;
            this.Contenu = contenu;
            this.DateCreation = date;
            this.IdTitre = idTitre;
            this.Titre = titre;
        }
    }
}
