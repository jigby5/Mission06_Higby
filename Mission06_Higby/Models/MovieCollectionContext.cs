using Microsoft.EntityFrameworkCore;

namespace Mission06_Higby.Models;

public class MovieCollectionContext : DbContext //Liaison
{
    public MovieCollectionContext(DbContextOptions<MovieCollectionContext> options) : base(options)
    {
    }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryID = 1, CategoryName = "Action" },
            new Category { CategoryID = 2, CategoryName = "Drama" },
            new Category { CategoryID = 3, CategoryName = "Romance" },
            new Category { CategoryID = 4, CategoryName = "Comedy" }
        );
    }
}