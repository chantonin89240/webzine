using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webzine.Entity
{
    public class Commentaire
    {
        [Key]
        public int IdCommentaire { get; set; }
        [Display(Name = "Nom")]
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Auteur { get; set; }
        [Display(Name = "Commentaire")]
        [Required]
        [MinLength(10)]
        [MaxLength(1000)]
        public string Contenu { get; set; }
        [Required]
        [Display(Name = "Date de création")]
        public DateTime DateCreation { get; set; }
        public int IdTitre { get; set; }
        public Titre Titre { get; set; }

        public Commentaire()
        {

        }

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
