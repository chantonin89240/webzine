using System.ComponentModel.DataAnnotations;

namespace Webzine.Entity
{
    public class Artiste
    {
        [Key]
        public int IdArtiste { get; set; }
        [MinLength(1)]
        [MaxLength(50)]
        [Display(Name = "Nom de l'artiste")]
        public string Nom { get; set; }
        public string Biographie { get; set; }
        public List<Titre> Titres  { get; set; }

        public Artiste()
        {
            this.Titres = new List<Titre>();
        }

        public Artiste(int id, string nom, string biographie) : this()
        {
            this.IdArtiste = id;
            this.Nom = nom;
            this.Biographie = biographie;
        }
    }
}