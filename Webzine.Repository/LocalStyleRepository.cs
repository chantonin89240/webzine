namespace Webzine.Repository
{
    using Webzine.Entity;
    using Webzine.Entity.Factory;
    using Webzine.Repository.Contracts;

    public class LocalStyleRepository : IStyleRepository
    {
        public List<Style> Styles = StyleFactory.CreateStyle().ToList();

        public void Add(Style style)
        {
            Styles.Add(style);
        }

        public void Delete(Style style)
        {
            Styles.Remove(style);
        }

        public Style Find(int id)
        {
            return Styles.First(a => a.IdStyle == id);
        }

        public IEnumerable<Style> FindAll()
        {
            return Styles;
        }

        public void Update(Style style)
        {
            Styles.Find(a => a == style);
        }

    }
}
