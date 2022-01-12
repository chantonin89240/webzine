namespace Webzine.Entity.Factory
{
    using System.Collections.Generic;
    using Bogus;

    public static class ArtisteFactory
    {
        public static IEnumerable<Artiste> CreateArtiste(int amount)
        {
            int artisteId = 1;
            Faker<Artiste> faker = new Faker<Artiste>()
                .CustomInstantiator(f => new Artiste(
                    artisteId++,
                    f.Name.FullName(),
                    f.Lorem.Sentences()));

            return faker.Generate(amount);
        }

    
    }
}
