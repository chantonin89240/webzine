namespace Webzine.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Entité pour gérer les données d'un commentaire.
    /// </summary>
    public class Commentaire
    {
        /// <summary>
        /// ID du commentaire.
        /// Unique.
        /// Non Null.
        /// </summary>
        [Key]
        public int IdCommentaire { get; set; }

        /// <summary>
        /// Auteur du commentaire.
        /// Non Null.
        /// </summary>
        [Display(Name = "Nom")]
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Auteur { get; set; }

        /// <summary>
        /// Contenu du commentaire.
        /// Non Null.
        /// </summary>
        [Display(Name = "Commentaire")]
        [Required]
        [MinLength(10)]
        [MaxLength(1000)]
        public string Contenu { get; set; }

        /// <summary>
        /// Date de création du commentaire.
        /// Non Null.
        /// </summary>
        [Required]
        [Display(Name = "Date de création")]
        public DateTime DateCreation { get; set; }

        /// <summary>
        /// ID du titre ou est créé le commentaire.
        /// </summary>
        public int IdTitre { get; set; }

        /// <summary>
        /// Titre ou est créé le commentaire.
        /// </summary>
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
