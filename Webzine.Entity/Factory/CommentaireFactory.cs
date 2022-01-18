namespace Webzine.Entity.Factory
{
    using System.Collections.Generic;
    using Bogus;

    public static class CommentaireFactory
    {
        public static int idCommentaire = 1;
        public static IEnumerable<Commentaire> CreateCommentaire(int amount, List<Titre> titres)
        {
            
            Random rand = new Random();

            Faker<Commentaire> faker = new Faker<Commentaire>()
                .CustomInstantiator(f => new Commentaire(
                    idCommentaire++,
                    f.Internet.UserName(),
                    f.Rant.Review(),
                    f.Date.Past(),
                    titres[rand.Next(0, titres.Count)].IdTitre)
                );


            return faker.Generate(amount);
        }
    }
}
