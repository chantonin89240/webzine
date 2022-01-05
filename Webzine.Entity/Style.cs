﻿namespace Webzine.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Entité représentant un Style.
    /// </summary>
    public class Style
    {
        /// <summary>
        /// ID du Style.
        /// Unique.
        /// </summary>
        [Key]
        public int IdStyle { get; set; }

        /// <summary>
        /// Libellé / Nom du style.
        /// </summary>
        [Display(Name = "Libellé")]
        [Required(ErrorMessage = "Libellé requis.")]
        [MinLength(2, ErrorMessage ="Taille mini : 2 caractères")]
        [MaxLength(50, ErrorMessage = "Taille maxi : 50 caractères")]
        public string Libelle { get; set; }

        /// <summary>
        /// Liste de liens aux Titres ayant ce Style.
        /// </summary>
        public List<TitreStyle> TitresStyles { get; set; }

        /// <summary>
        /// Initialize une instance de la classe <see cref="Style"/>.
        /// </summary>
        public Style()
        {
            this.TitresStyles = new List<TitreStyle>();
        }

        /// <summary>
        /// Initialize une instance de la classe <see cref="Style"/>.
        /// </summary>
        /// <param name="idStyle">ID du Style.</param>
        /// <param name="libelle">Nom/Libellé du Style.</param>
        public Style(int idStyle, string libelle) : this()
        {
            IdStyle = idStyle;
            Libelle = libelle;
        }
    }
}
