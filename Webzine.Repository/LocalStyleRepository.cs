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
            this.Styles.Add(style);
        }

        public void Delete(Style style)
        {
            this.Styles.Remove(style);
        }

        public Style Find(int id)
        {
            return this.Styles.First(a => a.IdStyle == id);
        }

        public IEnumerable<Style> FindAll()
        {
            return this.Styles;
        }

        public void Update(Style style)
        {
            this.Styles.Find(a => a == style);
        }

    }
}
