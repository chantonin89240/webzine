namespace Webzine.EntitiesContext
{
    using Microsoft.EntityFrameworkCore;
    using Webzine.Entity;

    public class WebzineDbContext : DbContext
    {
        // private IConfiguration Configuration;

        public DbSet<Titre>? Titres { get; set; }

        public DbSet<Style>? Styles { get; set; }

        public DbSet<Artiste>? Artistes { get; set; }

        public DbSet<Commentaire>? Commentaires { get; set; }

        public DbSet<TitreStyle>? TitreStyles { get; set; }

        public WebzineDbContext()
        {
        }

        public WebzineDbContext(DbContextOptions<WebzineDbContext> options)
            : base(options)
        {
            this.Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(NLog.LogManager.GetCurrentClassLogger().Info, Microsoft.Extensions.Logging.LogLevel.Information);
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Server=.;Database=WebzineDb;Trusted_Connection=True;MultipleActiveResultSets=true");
                optionsBuilder.UseSqlite("Data Source=Webzine.db");
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Table Artiste init
            modelBuilder.Entity<Artiste>(
                a =>
                {
                    a.ToTable("Artiste");

                    a.Property("IdArtiste").ValueGeneratedOnAdd();
                    a.Property("Nom");
                    a.Property("Biographie");

                    a.HasKey(a => a.IdArtiste);
                });

            // Table TitreStyle init
            modelBuilder.Entity<TitreStyle>(
                ts =>
                {
                    ts.ToTable("TitreStyle");
                    ts.Property("IdTitre");
                    ts.Property("IdStyle");
                    ts.HasKey(ts => new
                    {
                        ts.IdStyle,
                        ts.IdTitre,
                    });
                });

            // Table Style init
            modelBuilder.Entity<Style>(
                s =>
                {
                    s.ToTable("Style");
                    s.Property("IdStyle").ValueGeneratedOnAdd();
                    s.Property("Libelle");

                    s.HasKey(s => s.IdStyle);
                    s.HasMany(s => s.TitresStyles).WithOne(ts => ts.Style).HasForeignKey("IdStyle");
                });

            // Table Titre init
            modelBuilder.Entity<Titre>(
                t =>
                {
                    t.ToTable("Titre");

                    t.Property("IdTitre").ValueGeneratedOnAdd();
                    t.Property("Libelle");
                    t.Property("Chronique");
                    t.Property("UrlJaquette");
                    t.Property("UrlEcoute");
                    t.Property("DateCreation").HasColumnType("datetime");
                    t.Property("DateSortie").HasColumnType("date");
                    t.Property("Duree");
                    t.Property("NbLectures");
                    t.Property("NbLikes");

                    t.HasKey(t => t.IdTitre);
                    t.HasOne(t => t.Artiste).WithMany(a => a.Titres).HasForeignKey("IdArtiste");
                    t.HasMany(t => t.TitresStyles).WithOne(ts => ts.Titre).HasForeignKey("IdTitre");
                });

            // Table Commentaire init
            modelBuilder.Entity<Commentaire>(
                c =>
                {
                    c.ToTable("Commentaire");

                    c.Property("IdCommentaire").ValueGeneratedOnAdd();
                    c.Property("Auteur");
                    c.Property("Contenu");
                    c.Property("DateCreation").HasColumnType("datetime");

                    c.HasKey(c => c.IdCommentaire);
                    c.HasOne(c => c.Titre).WithMany(t => t.Commentaires).HasForeignKey("IdTitre");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}