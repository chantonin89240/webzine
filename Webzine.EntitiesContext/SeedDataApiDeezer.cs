namespace Webzine.EntitiesContext
{
    using Webzine.Entity;
    using Newtonsoft.Json;
    public class SeedDataApiDeezer
    {
        //http://www.diogonunes.com/blog/webclient-vs-httpclient-vs-httpwebrequest/
        public static string GetDataFromHttpClient(string url)
        {
            HttpClient httpClient = new HttpClient();

            var response = httpClient.GetAsync(url).Result;
            return response.Content.ReadAsStringAsync().Result;

            //throw new NotImplementedException();
        }

        public static void GetData()

        {
            //  "https://api.deezer.com/search?q=artist:"nomArtiste"

            var TitreResult = GetDataFromHttpClient("https://api.deezer.com/search?q=artist:");
            dynamic dataTitres = JsonConvert.DeserializeObject<dynamic>(TitreResult);

            List<Titre> titres = new List<Titre>();

            foreach (var item in dataTitres["data"])
            {
                Titre titre = new Titre();
                titre.IdTitre = item["id"];
                titre.Libelle = item["title"];
                titre.UrlJaquette = item["cover"];
                titre.IdArtiste = item["artist"]["id"];
                titres.Add(titre);

            }
        }

        public static List<Style> GetTStyle()
        {
            //  "https://api.deezer.com/genre

            var StylesResult = GetDataFromHttpClient("https://api.deezer.com/genre");
            dynamic dataStyles = JsonConvert.DeserializeObject<dynamic>(StylesResult);

            List<Style> styles = new List<Style>();
            foreach (var item in dataStyles["data"])
            {
                Style style = new Style();
                style.IdStyle = item["id"];
                style.Libelle = item["name"];
                styles.Add(style);
                // Titre.Styles.Add(Style);
            }

            return styles;

        }
    }
}