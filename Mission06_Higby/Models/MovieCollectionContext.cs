using Microsoft.EntityFrameworkCore;

namespace Mission06_Higby.Models;

public class MovieCollectionContext : DbContext
{
    public MovieCollectionContext(DbContextOptions<MovieCollectionContext> options) : base(options)
    {
    }

    public DbSet<Movie> Movies => Set<Movie>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(m => m.MovieID);
            entity.Property(m => m.Category).IsRequired().HasMaxLength(50);
            entity.Property(m => m.Title).IsRequired().HasMaxLength(150);
            entity.Property(m => m.Director).IsRequired().HasMaxLength(100);
            entity.Property(m => m.Rating).IsRequired().HasMaxLength(5);
            entity.Property(m => m.LentTo).HasMaxLength(100);
            entity.Property(m => m.Notes).HasMaxLength(25);
            entity.ToTable(t => t.HasCheckConstraint("CK_Movies_Rating", "Rating IN ('G','PG','PG-13','R')"));
        });
    }
}
