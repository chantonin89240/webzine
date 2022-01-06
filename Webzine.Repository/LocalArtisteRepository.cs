
namespace Webzine.Repository 
{
    using Webzine.Entity;
    using Webzine.Entity.Factory;
    using Webzine.Repository.Contracts;

    public  class LocalArtisteRepository : IArtisteRepository
    {
        public List<Artiste> Artiste = ArtisteFactory.CreateArtiste().ToList();

        public void Add(Artiste artiste)
        {
            throw new NotImplementedException();
           //Artiste.Add(artiste);
        }
        public void Delete(Artiste artiste)
        {
            throw new NotImplementedException();

            //Artiste.Remove(artiste);

        }
        public Artiste Find(int id)
        {
            return Artiste.First(a => a.IdArtiste == id);
            
        }
        public  IEnumerable<Artiste> FindAll()
        {
            return Artiste;
                //.FindAll(a => a.IdArtiste != null).ToList();
           

        }
        public void Update(Artiste artiste)
        {
            throw new NotImplementedException();

        }
    }
}