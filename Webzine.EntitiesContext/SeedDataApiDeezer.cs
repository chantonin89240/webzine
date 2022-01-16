namespace Webzine.EntitiesContext
{
    using Webzine.Entity;
    using Newtonsoft.Json;
    using Bogus;
    public static class SeedDataApiDeezer
    {
        private static List<Style> styles = new List<Style>();
        private static List<Artiste> artistes = new List<Artiste>();
        private static Dictionary<Artiste, Object> albums = new Dictionary<Artiste, Object>();

        /// <summary>
        /// Connection à une serveur HTTP.
        /// </summary>
        /// <param name="url"></param>
        /// <returns>Réponse du serveur</returns>
        public static string GetDataFromHttpClient(string url)
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetAsync(url).Result;
            return response.Content.ReadAsStringAsync().Result;
        }

        /// <summary>
        /// Méthode d'initialisation des données en base de données à partir de l'API Deezer
        /// La récupération des données se fait en fnction de la liste des mot clés de la liste ListeMotCles.
        /// ListeMotCles peut être alimenter de nom d'artiste ou de style de musique.
        /// </summary>
        /// <param name="context"></param>
        public static void InitializeData(WebzineDbContext context, List<string> ListeMotCles)
        {
            GetStyles(context);         
            ListeMotCles.ForEach(a => GetData(context, a));
            GetTitres(context);
        }

        /// <summary>
        /// Méthode d'enregistrement en BDD des styles de musique de l'API (Excepté le style "Tous").
        /// </summary>
        public static void GetStyles(WebzineDbContext context)
        {
            var StylesResult = GetDataFromHttpClient("https://api.deezer.com/genre");
            dynamic dataStyles = JsonConvert.DeserializeObject<dynamic>(StylesResult);

            #region ----- Enregistrement des styles ------
            foreach (var item in dataStyles.data)
            {
                if(item.name != "Tous")
                {
                    Style style = new Style();
                    style.IdStyle = item.id;
                    style.Libelle = item.name;
                    styles.Add(style);
                }
            }
            context.AddRange(styles);
            context.SaveChanges(); 
            #endregion
        }
        /// <summary>
        /// Méthode d'enregistrement en BDD des artistes répondant à la recherche par mot clé de l'API 
        /// Soit le mot clé se trouve dans le nom de l'artiste soit dans le nom de l'album.
        /// 1er temps : enregistrement des artistes ans la table Artistes.
        /// 2eme temps : enregistrement dans la table Titres des titres des albums corespondant à la recherche précédente
        /// 3ème temps : enregistrement dans la table TitresStyles des styles de l'album pour chaque titres
        /// </summary>
        /// <param name="context"></param>
        /// <param name="nomArtist"></param>
        public static void GetData(WebzineDbContext context, string nomArtist)
        {
            #region ----- Enregistrement des artistes ------

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
                    albums.Add(artiste, item.id);

                    context.Add(artiste);
                }
            }
            
            context.SaveChanges();
            #endregion  
        }

        public static void GetTitres(WebzineDbContext context)
        {
            var faker = new Faker();
            
            // Pour chaque album associé à un artiste dans le dictionnaire "albums"
            albums.ToList().ForEach(album =>
            {
                List<Titre> titres = new List<Titre>();
                List<TitreStyle> titreStyles = new List<TitreStyle>();
                // Demande d'un album par son ID
                var JsonTitle = GetDataFromHttpClient("https://api.deezer.com/album/" + album.Value);
                dynamic dataTitle = JsonConvert.DeserializeObject<dynamic>(JsonTitle);

                List<dynamic> idStyles = new List<dynamic>();
                
                var genrePositif = dataTitle.genre_id.ToObject<int>();  

                // L'enregistrement se fait si le genre est positif car il existe des titres ayant l'ID "-1"
                // et si l'url de l'image "cover_big" est différent de null
                if(genrePositif > 0 && dataTitle.cover_big != null)
                {
                    #region ----- Enregistrement des titres ------
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
                                UrlEcoute = "https://www.youtube.com/embed/ow00U-slPYk",
                                Duree = item.duration,
                                IdArtiste = item.artist.id,
                                DateCreation = DateTime.Now,
                                DateSortie = dataTitle.release_date,
                                NbLikes = faker.Random.Int(0, 1000),
                                NbLectures = faker.Random.Int(0, 1000),
                            };
                            titres.Add(titre);
                            context.Add(titre);
                        }
                    }
                    context.SaveChanges();
                    #endregion

                    #region ----- Enregistrement des styles associés à chaque titres ------
                    foreach (var item in dataTitle.genres.data)
                    {
                        var type = item.id.ToObject<int>();
                        // Certains albums possèdent plusieurs style et 
                        // certains ID de style n'existent pas dans la liste des genre importé précédement
                        if(styles.Any(s => s.IdStyle == type))
                        {
                            idStyles.Add(item.id);
                        }
                    }

                    titres.ForEach(titre => idStyles.ForEach(idstyle => {
                        
                            titreStyles.Add(new TitreStyle { IdStyle = idstyle, IdTitre = titre.IdTitre });
                    })); 

                    context.AddRange(titreStyles);
                    context.SaveChanges();
                    #endregion
                }
            }); 
            context.SaveChanges();
        }
    }
}
