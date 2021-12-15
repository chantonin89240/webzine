namespace Webzine.Entity
{
    public class Artiste
    {
        public int IdArtiste { get; set; }
        public string Nom { get; set; }
        public string Biographie { get; set; }
        public List<Titre> Titres  { get; set; }
    }
}