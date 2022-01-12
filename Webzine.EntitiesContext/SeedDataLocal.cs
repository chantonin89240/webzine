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

        public static void InitialisationDB(WebzineDbContext context)
        {

            int defaultAmount = 10;

            IEnumerable<Style> Styles = StyleFactory.GetStyles();
            context.AddRange(Styles.Select(style => new Style { Libelle = style.Libelle }).OrderBy(s => s.Libelle));

            IEnumerable<Artiste> Artistes = ArtisteFactory.CreateArtiste(defaultAmount);
            context.AddRange(Artistes.Select(artiste => new Artiste { Nom = artiste.Nom, Biographie = artiste.Biographie }));

            IEnumerable<Titre> Titres = TitreFactory.CreateTitre(defaultAmount, Artistes, Styles);
            context.AddRange(Titres.Select(titre => new Titre
            {
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
            }));

            context.SaveChanges();

            IEnumerable<Commentaire> commentaires = CommentaireFactory.CreateCommentaire(defaultAmount, Titres);
            context.AddRange(commentaires.Select(comment => new Commentaire
            {
                Auteur = comment.Auteur,
                Contenu = comment.Contenu,
                DateCreation = comment.DateCreation,
                IdTitre = comment.IdTitre,
            }));

            context.SaveChanges();

            IEnumerable<TitreStyle> titreStyles = Titres.SelectMany(t =>
                t.TitresStyles
            ).Select(t =>
                new TitreStyle()
                {
                    IdStyle = t.IdStyle,
                    IdTitre = t.IdTitre,
                }
            ).ToList();
            context.AddRange(titreStyles);



            context.SaveChanges();
        }
    }
}
