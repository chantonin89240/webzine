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
                    IdStyle = 4,
                    Libelle =  "Rock",
                },
                new Style(){
                    IdStyle = 5,
                    Libelle =  "Dance",
                },
                new Style(){
                    IdStyle = 6,
                    Libelle =  "R&B",
                },
                new Style(){
                    IdStyle = 7,
                    Libelle =  "Alternative",
                },
                new Style(){
                    IdStyle = 8,
                    Libelle =  "Electro",
                },
                new Style(){
                    IdStyle = 9,
                    Libelle =  "Folk",
                },
                new Style(){
                    IdStyle = 10,
                    Libelle =  "Reggae",
                },
                new Style(){
                    IdStyle = 11,
                    Libelle =  "Jazz",
                },
                new Style(){
                    IdStyle = 12,
                    Libelle =  "Chanson française",
                },
                new Style(){
                    IdStyle = 13,
                    Libelle =  "Country",
                },
                new Style(){
                    IdStyle = 14,
                    Libelle =  "Classique",
                },
                new Style(){
                    IdStyle = 15,
                    Libelle =  "Films/Jeux vidéo",
                },
                new Style(){
                    IdStyle = 16,
                    Libelle =  "Metal",
                },
                new Style(){
                    IdStyle = 17,
                    Libelle =  "Soul & Funk",
                },
                new Style(){
                    IdStyle = 18,
                    Libelle =  "Blues",
                },
                new Style(){
                    IdStyle = 19,
                    Libelle =  "Jeunesse",
                },
                new Style(){
                    IdStyle = 20,
                    Libelle =  "Latino",
                },
                new Style(){
                    IdStyle = 21,
                    Libelle =  "Musique africaine",
                },
                new Style(){
                    IdStyle = 22,
                    Libelle =  "Musique arabe",
                },
                new Style(){
                    IdStyle = 23,
                    Libelle =  "Musique asiatique",
                },
                new Style(){
                    IdStyle = 24,
                    Libelle =  "Musique brésilienne",
                },
                new Style(){
                    IdStyle = 25,
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