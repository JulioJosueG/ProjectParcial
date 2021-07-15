using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DataAccess
{
    public partial class NewsProjectDBContext : DbContext
    {
        public NewsProjectDBContext()
        {
        }

        public NewsProjectDBContext(DbContextOptions<NewsProjectDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Source> Sources { get; set; }
        public virtual DbSet<State> States { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-151NMHQA; Database=NewsProjectDB; Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Article>(entity =>
            {
                entity.Property(e => e.ArticleId).ValueGeneratedNever();

                entity.Property(e => e.Content)
                    .IsUnicode(false)
                    .HasColumnName("content");

                entity.Property(e => e.CountryCode)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.IdAuthor).HasColumnName("idAuthor");

                entity.Property(e => e.IdState).HasColumnName("idState");

                entity.Property(e => e.ImageAt)
                    .IsUnicode(false)
                    .HasColumnName("imageAt");

                entity.Property(e => e.PublishedAt).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Articles__Catego__3A81B327");

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.CountryCode)
                    .HasConstraintName("FK__Articles__Countr__398D8EEE");

                entity.HasOne(d => d.IdAuthorNavigation)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.IdAuthor)
                    .HasConstraintName("FK__Articles__idAuth__38996AB5");

                entity.HasOne(d => d.IdSourceNavigation)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.IdSource)
                    .HasConstraintName("FK__Articles__IdSour__3B75D760");

                entity.HasOne(d => d.IdStateNavigation)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.IdState)
                    .HasConstraintName("FK__Articles__idStat__3C69FB99");
            });

            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(e => e.IdAuthor)
                    .HasName("PK__authors__5EE9536D5C26EE8E");

                entity.ToTable("authors");

                entity.Property(e => e.IdAuthor)
                    .ValueGeneratedNever()
                    .HasColumnName("idAuthor");

                entity.Property(e => e.IdCountry)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idCountry");

                entity.Property(e => e.IdState).HasColumnName("idState");

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCountryNavigation)
                    .WithMany(p => p.Authors)
                    .HasForeignKey(d => d.IdCountry)
                    .HasConstraintName("FK__authors__idCount__34C8D9D1");

                entity.HasOne(d => d.IdStateNavigation)
                    .WithMany(p => p.Authors)
                    .HasForeignKey(d => d.IdState)
                    .HasConstraintName("FK__authors__idState__35BCFE0A");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.IdCategory)
                    .HasName("PK__Categori__79D361B60159404D");

                entity.Property(e => e.IdCategory)
                    .ValueGeneratedNever()
                    .HasColumnName("idCategory");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IdState).HasColumnName("idState");

                entity.HasOne(d => d.IdStateNavigation)
                    .WithMany(p => p.Categories)
                    .HasForeignKey(d => d.IdState)
                    .HasConstraintName("FK__Categorie__idSta__29572725");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK__Countrie__357D4CF894576E0F");

                entity.Property(e => e.Code)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("code");

                entity.Property(e => e.CountryName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("countryName");

                entity.Property(e => e.IdState).HasColumnName("idState");

                entity.HasOne(d => d.IdStateNavigation)
                    .WithMany(p => p.Countries)
                    .HasForeignKey(d => d.IdState)
                    .HasConstraintName("FK__Countries__idSta__267ABA7A");
            });

            modelBuilder.Entity<Source>(entity =>
            {
                entity.HasKey(e => e.IdSource)
                    .HasName("PK__Sources__574D7FE3754ACF30");

                entity.Property(e => e.IdSource)
                    .ValueGeneratedNever()
                    .HasColumnName("idSource");

                entity.Property(e => e.IdState).HasColumnName("idState");

                entity.Property(e => e.SourceName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdStateNavigation)
                    .WithMany(p => p.Sources)
                    .HasForeignKey(d => d.IdState)
                    .HasConstraintName("FK__Sources__idState__2C3393D0");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.HasKey(e => e.IdState)
                    .HasName("PK__State__98CB3723932A7BE7");

                entity.ToTable("State");

                entity.Property(e => e.IdState)
                    .ValueGeneratedNever()
                    .HasColumnName("idState");

                entity.Property(e => e.StateName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
