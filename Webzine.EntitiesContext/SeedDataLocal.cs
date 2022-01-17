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
        private static IEnumerable<Style> Styles;
        private static IEnumerable<Artiste> Artistes;
        private static IEnumerable<Titre> Titres;
        private static IEnumerable<Commentaire> Commentaires;

        public static void InitialisationDB(WebzineDbContext context)
        {
            int defaultAmount = 20;

            Styles = StyleFactory.GetStyles();
            context.AddRange(Styles.ToList());
            // context.AddRange(Styles.Select(style => new Style { Libelle = style.Libelle }).OrderBy(s => s.Libelle));

            Artistes = ArtisteFactory.CreateArtiste(defaultAmount);
            context.AddRange(Artistes.ToList());
            // context.AddRange(Artistes.Select(artiste => new Artiste { Nom = artiste.Nom, Biographie = artiste.Biographie }));

            Titres = TitreFactory.CreateTitre(defaultAmount, Artistes, Styles);
            context.AddRange(Titres.ToList());
            // context.AddRange(Titres.Select(titre => new Titre
            // {
            //     IdArtiste = titre.IdArtiste,
            //     Libelle = titre.Libelle,
            //     Chronique = titre.Chronique,
            //     UrlJaquette = titre.UrlJaquette,
            //     UrlEcoute = titre.UrlEcoute,
            //     DateCreation = titre.DateCreation,
            //     DateSortie = titre.DateSortie,
            //     Duree = titre.Duree,
            //     NbLectures = titre.NbLectures,
            //     NbLikes = titre.NbLikes,
            // }));

            context.SaveChanges();

            Commentaires = CommentaireFactory.CreateCommentaire(defaultAmount, Titres);
            context.AddRange(Commentaires.ToList());
            // context.AddRange(commentaires.Select(comment => new Commentaire
            // {
            //     Auteur = comment.Auteur,
            //     Contenu = comment.Contenu,
            //     DateCreation = comment.DateCreation,
            //     IdTitre = comment.IdTitre,
            // }));

            context.SaveChanges();

            // IEnumerable<TitreStyle> titreStyles = Titres.SelectMany(t =>
            //     t.TitresStyles
            // ).Select(t =>
            //     new TitreStyle()
            //     {
            //         IdStyle = t.IdStyle,
            //         IdTitre = t.IdTitre,
            //     }
            // ).ToList();

            // context.AddRange(titreStyles.ToList());
            // context.SaveChanges();
        }
    }
}
