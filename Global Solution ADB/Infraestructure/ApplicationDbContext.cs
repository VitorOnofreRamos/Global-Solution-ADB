using Global_Solution_ADB.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Global_Solution_ADB.Infraestructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Sensor> Sensors { get; set; }
    public DbSet<Analysis> Analyzes { get; set; }
    public DbSet<Alert> Alerts { get; set; }
    public DbSet<NuclearPlant> NuclearPlants { get; set; }
    public DbSet<Metric> Metrics { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<_BaseEntity>())
        {
            if (entry.State == EntityState.Added)
                entry.Entity.CreatedAt = DateTime.UtcNow;
            else if (entry.State == EntityState.Modified)
                entry.Entity.UpdatedAt = DateTime.UtcNow;
        }
        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuração de relação entre NuclearPlant e Metric (1:N)
        modelBuilder.Entity<Metric>()
            .HasOne(m => m.NuclearPlant)
            .WithMany(np => np.Metrics)
            .HasForeignKey(m => m.NuclearPlantId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configuração de relação entre Sensor e Alert (1:N)
        modelBuilder.Entity<Alert>()
            .HasOne(a => a.Sensor)
            .WithMany(s => s.Alerts)
            .HasForeignKey(a => a.SensorId)
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
    }
}
