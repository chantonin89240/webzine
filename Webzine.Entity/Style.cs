using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webzine.Entity
{
    public class Style
    {
        [Key]
        public int IdStyle { get; set; }

        [Display(Name = "Libellé")]
        [Required(ErrorMessage = "Libellé requis.")]
        [MinLength(2, ErrorMessage ="Taille mini : 2 caractères")]
        [MaxLength(50, ErrorMessage = "Taille maxi : 50 caractères")]
        public string Libelle { get; set; }


        public List<TitreStyle> TitresStyles { get; set; }

        public Style()
        {
            this.TitresStyles = new List<TitreStyle>();
        }

        public Style(int idStyle, string libelle) : this()
        {
            IdStyle = idStyle;
            Libelle = libelle;
        }
    }
}
