using Microsoft.EntityFrameworkCore;
public class HouseDbContext : DbContext
{
    public DbSet<HouseEntity> Houses => Set<HouseEntity>();
    public HouseDbContext(DbContextOptions<HouseDbContext> options) : base(options) { }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        options.UseSqlite($"Data Source={Path.Join(path, "houses.db")}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        SeedData.Seed(modelBuilder);
    }
}