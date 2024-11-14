using Global_Solution_ADB.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Global_Solution_ADB.Infraestructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<NuclearPlant> NuclearPlants { get; set; }
    public DbSet<Metric> Metrics { get; set; }
    public DbSet<Sensor> Sensors { get; set; }
    public DbSet<Analysis> Analyzes { get; set; }
    public DbSet<Alert> Alerts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuração de conversão de bool para CHAR(1) '1'/'0' no banco de dados Oracle
        modelBuilder.Entity<Sensor>()
            .Property(e => e.Status)
            .HasColumnName("STATUS")
            .HasColumnType("CHAR(1)")
            .HasConversion(
                v => v ? "1" : "0",
                v => v == "1");

        modelBuilder.Entity<Alert>()
            .Property(e => e.IsResolved)
            .HasColumnName("ISRESOLVED")
            .HasColumnType("CHAR(1)")
            .HasConversion(
                v => v ? "1" : "0",
                v => v == "1");

        // Relacionamento NuclearPlant -> Metrics (1:N)
        modelBuilder.Entity<NuclearPlant>()
            .HasMany(np => np.Metrics)
            .WithOne(m => m.NuclearPlant)
            .HasForeignKey(m => m.NuclearPlantId)
            .OnDelete(DeleteBehavior.Cascade);

        // Relacionamento NuclearPlant -> Sensors (1:N)
        modelBuilder.Entity<NuclearPlant>()
            .HasMany(np => np.Sensors)
            .WithOne(s => s.NuclearPlant)
            .HasForeignKey(s => s.NuclearPlantId)
            .OnDelete(DeleteBehavior.Cascade);

        // Relacionamento Sensor -> Analysis (1:N)
        modelBuilder.Entity<Sensor>()
            .HasMany(s => s.Analyses)
            .WithOne(a => a.Sensor)
            .HasForeignKey(a => a.SensorId)
            .OnDelete(DeleteBehavior.Cascade);

        // Relacionamento Analysis -> Alert (1:N)
        modelBuilder.Entity<Analysis>()
            .HasMany(a => a.Alerts)
            .WithOne(al => al.Analysis)
            .HasForeignKey(al => al.AnalysisId)
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
    }
}
