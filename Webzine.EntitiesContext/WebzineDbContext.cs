namespace Webzine.EntitiesContext
{
    using Microsoft.EntityFrameworkCore;
    using Webzine.Entity;

    public class WebzineDbContext : DbContext
    {
        public DbSet<Titre>? Titres { get; set; }

        public DbSet<Style>? Styles { get; set; }

        public DbSet<Artiste>? Artistes { get; set; }

        public DbSet<Commentaire>? Commentaires { get; set; }

        public DbSet<TitreStyle>? TitresStyles { get; set; }

        public WebzineDbContext(DbContextOptions<WebzineDbContext> DbContextOptions)
            : base(DbContextOptions)
        {
            // this.Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(NLog.LogManager.GetCurrentClassLogger().Info, Microsoft.Extensions.Logging.LogLevel.Information);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Table TitreStyle init
            modelBuilder.Entity<TitreStyle>(
                ts =>
                {
                    // ts.HasKey(ts => new
                    // {
                    //     ts.IdStyle,
                    //     ts.IdTitre,
                    // });
                    // ts.HasOne(ts => ts.Style).WithMany(s => s.TitresStyles).HasForeignKey(ts => ts.IdStyle);
                    // ts.HasOne(ts => ts.Titre).WithMany(s => s.TitresStyles).HasForeignKey(ts => ts.IdTitre);
                });

            // Table Style init
            modelBuilder.Entity<Style>(
                style =>
                {
                    style.HasMany(s => s.TitresStyles).WithOne(ts => ts.Style).HasForeignKey(s => s.IdStyle);
                });

            // Table Titre init
            modelBuilder.Entity<Titre>(
                titre =>
                {
                    titre.HasOne(t => t.Artiste).WithMany(a => a.Titres).HasForeignKey(t => t.IdArtiste);
                    titre.HasMany(t => t.TitresStyles).WithOne(ts => ts.Titre).HasForeignKey(t => t.IdTitre);
                });

            // Table Commentaire init
            modelBuilder.Entity<Commentaire>(
                comment =>
                {
                    comment.HasOne(c => c.Titre).WithMany(t => t.Commentaires).HasForeignKey(c => c.IdTitre);
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}