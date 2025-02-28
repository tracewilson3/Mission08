using Microsoft.EntityFrameworkCore;

public class FTFDbContext : DbContext
{
    public FTFDbContext(DbContextOptions<FTFDbContext> options) : base(options) { }

    // Define DbSets for your tables
    public DbSet<Task> Tasks { get; set; }
    public DbSet<Quadrant> Quadrants { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Task -> Quadrant (One-to-Many)
        modelBuilder.Entity<Task>()
            .HasOne(t => t.Quadrant)
            .WithMany(q => q.Tasks)
            .HasForeignKey(t => t.QuadrantId)
            .OnDelete(DeleteBehavior.Cascade);

        // Task -> Category (One-to-Many)
        modelBuilder.Entity<Task>()
            .HasOne(t => t.Category)
            .WithMany(c => c.Tasks)
            .HasForeignKey(t => t.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}