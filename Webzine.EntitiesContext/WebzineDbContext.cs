using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Webzine.Entity;

namespace Webzine.EntitiesContext
{
    public class WebzineDbContext : DbContext
    {
        // private IConfiguration Configuration;

        public DbSet<Titre>? Titres { get; set; }

        public string DbPath { get; private set; }

        public WebzineDbContext(DbContextOptions options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlite(Configuration.GetConnectionString("WebzineDbContext"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        // Dans appsettings connection string pour sqlserver et sqllite(en premier)
        // "Data Source = Webzine.db"

        // "Server = (localdb)\\mssqllocaldb;Database = WebzineDbContext;Trusted_Connection = True;MultipleActiveResultSets=true"

        // Ajouter l'utilisation d'un dbcontext dans program.cs

        // Ajouter
        // context.Add<Titre>(obj);
        // Modifier
        // context.Update<Titre>(obj);
        // Ou plus simple
        // passer par le suivi des changements
        // Suppr
        // context.Titres.Remove(object);

        // Persistance des données, envoi en bdd
        // context.SaveChanges();

        // Suivi des changements
        // Pour desactiver
        // AsNotracking()
        // context.ChangeTracker.AutoDetectChangesEnabled=false

        // EntityState
        // Attached ou Detattached
    }
}