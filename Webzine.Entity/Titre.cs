namespace Webzine.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Titre
    {
        public int IdTitre { get; set; }

        public int IdArtiste { get; set; }

        public Artiste Artiste { get; set; }
        [Display(Name = "Titre")]
        [Required]
        [MinLength(1)]
        [MaxLength(200)]
        public string Libelle { get; set; }
        [Required]
        [MinLength(10)]
        [MaxLength(4000)]
        public string Chronique { get; set; }
        [Required]
        [Display(Name = "Jaquette de l'album")]
        [MaxLength(250)]
        public string UrlJaquette { get; set; }
        [Display(Name = "URL d'écoute")]
        [MinLength(13)]
        [MaxLength(250)]
        public string UrlEcoute { get; set; }
        public string Lien { get; set; }
        [Required]
        [Display(Name = "Date de création")]
        public DateTime DateCreation { get; set; }
        [Required]
        [Display(Name = "Date de sortie")]
        public DateTime DateSortie { get; set; }
        [Display(Name = "Durée en secondes")]
        public int Duree { get; set; }
        [Display(Name = "Nombre de lectures")]
        [Required]
        public int NbLectures { get; set; }
        [Display(Name = "Nombre de likes")]
        [Required]
        public int NbLikes { get; set; }
        public List<Commentaire> Commentaires { get; set; }
        public List<TitreStyle> TitresStyles { get; set; }

        public Titre()
        {
            this.Commentaires = new List<Commentaire>();
            this.TitresStyles = new List<TitreStyle>();
        }

        public Titre(int idTitre, int idArtiste, Artiste artiste, string libelle, string chronique, string urlJaquette, string urlEcoute, string lien, DateTime dateCreation , DateTime dateSortie, int duree, int nbLecture, int nbLike) : this()
        {
            this.IdTitre = idTitre;
            this.IdArtiste = idArtiste;
            this.Artiste = artiste;
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
