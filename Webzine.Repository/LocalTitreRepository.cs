namespace Webzine.Repository
{
    using Webzine.Entity;
    using Webzine.Entity.Factory;
    using Webzine.Repository.Contracts;

    public class LocalTitreRepository : ITitreRepository
    {
        private List<Titre> Titres = TitreFactory.CreateTitre().ToList();
        private List<Style> Styles = StyleFactory.CreateStyle().ToList();

        public void Add(Titre titre)
        {
            Titres.Add(titre);
        }
        public int Count() 
        { 
            return Titres.Count;
        }
        public void Delete(Titre titre)
        {
            Titres.Remove(titre);
        }
        public Titre Find(int idTitre)
        {
            return Titres.First(t => t.IdTitre == idTitre);
        }
        public IEnumerable<Titre> FindAll()
        {
            return Titres;
        }
        public IEnumerable<Titre> FindTitres(int offset, int limit)
        {
            return Titres.Skip(limit).Take(offset).ToList();
        }
        public void IncrementNbLectures(Titre titre)
        {
            Titres.First(t => t == titre).NbLectures++;
        }
        public void IncrementNbLikes(Titre titre)
        {
            Titres.First(t => t == titre).NbLikes++; ;
        }
        public IEnumerable<Titre> Search(string mot)
        {
            return Titres.Where(t => t.Libelle.Contains(mot));
        }
        public IEnumerable<Titre> SearchByStyle(string libelle)
        {
            var idStyle = Styles.First(s => s.Libelle.Contains(libelle)).IdStyle;
            return Titres.FindAll(t => t.TitresStyles.Exists(item => item.IdStyle == idStyle));
        }
        public void Update(Titre titre)
        {
            //Titres.Find(t => t == titre).updateDbTitle(................);
        }
    }
}
