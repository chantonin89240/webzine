namespace Webzine.EntitiesContext
{
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

            Artistes = ArtisteFactory.CreateArtiste(defaultAmount);
            context.AddRange(Artistes.ToList());

            Titres = TitreFactory.CreateTitre(defaultAmount, Artistes, Styles);
            context.AddRange(Titres.ToList());

            context.SaveChanges();

            Commentaires = CommentaireFactory.CreateCommentaire(defaultAmount, Titres.ToList());
            context.AddRange(Commentaires.ToList());

            context.SaveChanges();
        }
    }
}
