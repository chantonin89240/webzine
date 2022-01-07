namespace Webzine.EntitiesContext
{
    using Newtonsoft.Json;
    using Webzine.Entity.Factory;
    using Webzine.Entity;

    /// <summary>
    /// Service d'importation des données de Factory dans la BDD.
    /// </summary>
    public static class SeedDataLocal
    {
        const string DatasFile = "Data/ArtistRock.json";


        /// <summary>
        /// Méthode de désérialisation.
        /// </summary>
        /// <typeparam name="T">Type d'objets à préciser à l'appel de la méthode</typeparam>
        /// <param name="dataFile">Chemin du fichier sous forme de string.</param>
        /// <returns>Liste d'objets.</returns>
        /// <exception cref="Exception">Si la liste est vide.</exception>
        public static IEnumerable<T> LoadDatas<T>(string dataFile)
        {
            string json = File.ReadAllText(dataFile);
            return JsonConvert.DeserializeObject<List<T>>(json)
                ?? throw new Exception("La liste ne doit pas être vide.");
        }

        // addrange builder.services. create service provider

        public static void InitialisationDB(WebzineDbContext context)
        {
            var Styles = StyleFactory.GetStyles().Select(style => new Style { Libelle = style.Libelle });
            context.AddRange(Styles);

            var Artistes = ArtisteFactory.CreateArtiste().Select(artiste => new Artiste { Nom =artiste.Nom, Biographie = artiste.Biographie });
            context.AddRange(Artistes);

            var Titres = TitreFactory.CreateTitre().Select(titre => new Titre { 
                IdArtiste = titre.IdArtiste, 
                Libelle = titre.Libelle,
                Chronique = titre.Chronique,
                UrlJaquette = titre.UrlJaquette,
                UrlEcoute = titre.UrlEcoute,
                DateCreation = titre.DateCreation,
                DateSortie = titre.DateSortie,
                Duree = titre.Duree,
                NbLectures = titre.NbLectures,
                NbLikes = titre.NbLikes,
            });
            context.AddRange(Titres);

            context.SaveChanges();

            var Commentaires = CommentaireFactory.CreateCommentaire().Select(commentaire => new Commentaire {
                Auteur = commentaire.Auteur,
                Contenu = commentaire.Contenu,
                DateCreation = commentaire.DateCreation,
                IdTitre = commentaire.IdTitre,
            });
            context.AddRange(Commentaires);

            var TitresStyles = TitreFactory.CreateTitre().SelectMany(t => t.TitresStyles).Select(ts => new TitreStyle {
                IdTitre = ts.IdTitre,
                IdStyle = ts.IdStyle,
            }).ToList();
            context.AddRange(TitresStyles);

            context.SaveChanges();
        }
    }
}
