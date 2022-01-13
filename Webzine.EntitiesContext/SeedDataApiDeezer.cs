namespace Webzine.EntitiesContext
{
    using Webzine.Entity;
    using Newtonsoft.Json;
    using Bogus;
    public static class SeedDataApiDeezer
    {
        public static List<Style> styles = new List<Style>();
        public static List<Artiste> artistes = new List<Artiste>();


        public static string GetDataFromHttpClient(string url)
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetAsync(url).Result;
            return response.Content.ReadAsStringAsync().Result;
        }
        public static void InitializeData(WebzineDbContext context)
        {
            GetStyles();
            context.AddRange(styles);
            context.SaveChanges();
            List<string> ListeArtiste = new List<string>() {"maalouf", "rondo veneziano", "ntm", "queen", "bob marley", "percival schuttenbach"};
            ListeArtiste.ForEach(a => GetData(context, a));
        }
        public static void GetStyles()
        {

            var StylesResult = GetDataFromHttpClient("https://api.deezer.com/genre");
            dynamic dataStyles = JsonConvert.DeserializeObject<dynamic>(StylesResult);

            foreach (var item in dataStyles.data)
            {
                Style style = new Style();
                style.IdStyle = item.id;
                style.Libelle = item.name;
                styles.Add(style);
            }
        }
        public static void GetData(WebzineDbContext context, string nomArtist)
        {

            Dictionary<Artiste, Object> albums = new Dictionary<Artiste, Object>();

            var Json = GetDataFromHttpClient("https://api.deezer.com/search/album?q=" + nomArtist);
            dynamic dynamic = JsonConvert.DeserializeObject<dynamic>(Json);

            var faker = new Faker();

            foreach (var item in dynamic.data)
            {
                if(!artistes.Exists(a => a.IdArtiste == item.artist.id.ToObject<int>()))
                {
                    Artiste artiste = new Artiste()
                    {
                        IdArtiste = item.artist.id,
                        Nom = item.artist.name,
                        Biographie = faker.Lorem.Paragraph(2),
                    };

                    artistes.Add(artiste);

                    context.Add(artiste);
                    context.SaveChanges();

                    albums.Add(artiste, item.id);
                }
            } 
            
            albums.ToList().ForEach(album =>
            {
                var JsonTitle = GetDataFromHttpClient("https://api.deezer.com/album/" + album.Value);
                dynamic dataTitle = JsonConvert.DeserializeObject<dynamic>(JsonTitle);
                List<Titre> titres = new List<Titre>();
                List<dynamic> idStyles = new List<dynamic>();
                List<TitreStyle> titreStyles = new List<TitreStyle>();
                var genrePositif = dataTitle.genre_id.ToObject<int>();     
                if(genrePositif > 0)
                {
                    foreach (var item in dataTitle.tracks.data)
                    {
                        if(item.artist.id == album.Key.IdArtiste)
                        {
                            Titre titre = new Titre()
                            {
                                IdTitre = item.id,
                                Libelle = item.title,
                                Chronique = faker.Lorem.Paragraph(10),
                                UrlJaquette = dataTitle.cover_big,
                                UrlEcoute = "default",
                                Lien = "",
                                Duree = item.duration,
                                IdArtiste = dataTitle.artist.id,
                                DateCreation = DateTime.Now,
                                DateSortie = dataTitle.release_date,
                                NbLikes = faker.Random.Int(0, 1000),
                                NbLectures = faker.Random.Int(0, 1000),
                            };
                            titres.Add(titre);
                        }
                    }

                    context.AddRange(titres);
                    context.SaveChanges();
                    
                    foreach (var item in dataTitle.genres.data)
                    {
                        var type = item.id.ToObject<int>();
                        var stylesType = styles;

                        if(styles.Any(s => s.IdStyle == type))
                        {
                            idStyles.Add(item.id);
                        }
                    }

                    titres.ForEach(titre => idStyles.ForEach(idstyle => {
                        
                            titreStyles.Add(new TitreStyle { IdStyle = idstyle, IdTitre = titre.IdTitre });
                    })); 
                    var toto2 = titreStyles;

                    context.AddRange(titreStyles);
                    context.SaveChanges();
                }
            });
            
        }
    }
}
