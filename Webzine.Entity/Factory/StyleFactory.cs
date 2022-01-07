namespace Webzine.Entity.Factory
{
    public static class StyleFactory
    {
        public static IEnumerable<Style> CreateStyle()
        {
            return new List<Style>()
             {
                new Style()
                {
                    IdStyle = 1,
                    Libelle = "Tous",
                },
                new Style()
                {
                    IdStyle = 999,
                    Libelle = "Pop",
                },
                new Style()
                {
                    IdStyle = 2,
                    Libelle = "Livres audio",
                },
                new Style()
                {
                    IdStyle = 3,
                    Libelle = "Rap/Hip Hop",
                },
                new Style(){
                    IdStyle = 152,
                    Libelle =  "Rock",
                },
                new Style(){
                    IdStyle = 113,
                    Libelle =  "Dance",
                },
                new Style(){
                    IdStyle = 165,
                    Libelle =  "R&B",
                },
                new Style(){
                    IdStyle = 85,
                    Libelle =  "Alternative",
                },
                new Style(){
                    IdStyle = 106,
                    Libelle =  "Electro",
                },
                new Style(){
                    IdStyle = 466,
                    Libelle =  "Folk",
                },
                new Style(){
                    IdStyle = 144,
                    Libelle =  "Reggae",
                },
                new Style(){
                    IdStyle = 129,
                    Libelle =  "Jazz",
                },
                new Style(){
                    IdStyle = 52,
                    Libelle =  "Chanson française",
                },
                new Style(){
                    IdStyle = 84,
                    Libelle =  "Country",
                },
                new Style(){
                    IdStyle = 98,
                    Libelle =  "Classique",
                },
                new Style(){
                    IdStyle = 17,
                    Libelle =  "Films/Jeux vidéo",
                },
                new Style(){
                    IdStyle = 464,
                    Libelle =  "Metal",
                },
                new Style(){
                    IdStyle = 169,
                    Libelle =  "Soul & Funk",
                },
                new Style(){
                    IdStyle = 153,
                    Libelle =  "Blues",
                },
                new Style(){
                    IdStyle = 95,
                    Libelle =  "Jeunesse",
                },
                new Style(){
                    IdStyle = 197,
                    Libelle =  "Latino",
                },
                new Style(){
                    IdStyle = 99,
                    Libelle =  "Musique africaine",
                },
                new Style(){
                    IdStyle = 12,
                    Libelle =  "Musique arabe",
                },
                new Style(){
                    IdStyle = 16,
                    Libelle =  "Musique asiatique",
                },
                new Style(){
                    IdStyle = 75,
                    Libelle =  "Musique brésilienne",
                },
                new Style(){
                    IdStyle = 81,
                    Libelle =  "Musique indienne",
                },
             };
        }

        public static List<Style> GetStyles()
        {

            List<Style> Styles = CreateStyle().ToList();

            return Styles;
        }

        public static List<Style> GetStyle(Titre titre)
        {
            List<Style> styles = CreateStyle().ToList();

            List<Style> stylesTitre = new List<Style>();

            foreach (var item in titre.TitresStyles)
            {
                stylesTitre.Add(styles.First(el => el.IdStyle == item.IdStyle));
            }

            return stylesTitre;
        }
    }
}