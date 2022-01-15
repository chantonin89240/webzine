namespace Webzine.Entity.Factory
{
    using System;
    using System.Collections.Generic;
    using Bogus;

    public static class CommentaireFactory
    {
        public static IEnumerable<Commentaire> CreateCommentaire(int amount, IEnumerable<Titre> titres)
        {
            int idCommentaire = 1;
            Faker<Commentaire> faker = new Faker<Commentaire>()
                .CustomInstantiator(f => new Commentaire(
                    idCommentaire++,
                    f.Internet.UserName(),
                    f.Rant.Review(),
                    f.Date.Past(),
                    f.Random.Number(1, amount),
                    new Titre()))
                .FinishWith((f, c) => {
                    c.Titre = f.PickRandom(titres);
                    c.IdTitre = c.Titre.IdTitre;
                });


            return faker.Generate(amount);
        }
    }
}
