using Global_Solution_ADB.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Global_Solution_ADB.Infraestructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<NuclearPlant> NuclearPlants { get; set; }
    public DbSet<Metric> Metrics { get; set; }
    public DbSet<Sensor> Sensors { get; set; }
    public DbSet<SensorType> SensorTypes { get; set; }
    public DbSet<Analysis> Analyzes { get; set; }
    public DbSet<LogAlert> LogAlerts { get; set; }


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

        modelBuilder.Entity<LogAlert>()
            .Property(e => e.IsResolved)
            .HasColumnName("ISRESOLVED")
            .HasColumnType("CHAR(1)")
            .HasConversion(
                v => v ? "1" : "0",
                v => v == "1");

        // Renomeando a coluna "Id" para cada tabela para seguir o padrão "ID_{NomeDaTabela}"
        modelBuilder.Entity<NuclearPlant>()
            .Property(np => np.Id)
            .HasColumnName("ID_NUCLEARPLANT");

        modelBuilder.Entity<Metric>()
            .Property(m => m.Id)
            .HasColumnName("ID_METRIC");

        modelBuilder.Entity<Sensor>()
            .Property(s => s.Id)
            .HasColumnName("ID_SENSOR");

        modelBuilder.Entity<SensorType>()
            .Property(st => st.Id)
            .HasColumnName("ID_SENSORTYPE");

        modelBuilder.Entity<Analysis>()
            .Property(a => a.Id)
            .HasColumnName("ID_ANALYSIS");

        modelBuilder.Entity<LogAlert>()
            .Property(al => al.Id)
            .HasColumnName("ID_ALERT");

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

        // Relacionamento Sensor -> SensorType (1:1)
        modelBuilder.Entity<Sensor>()
            .HasOne(s => s.SensorType)
            .WithOne(st => st.Sensor)
            .HasForeignKey<SensorType>(st => st.SensorId)
            .OnDelete(DeleteBehavior.Cascade);

        // Relacionamento Analysis -> Alert (1:N)
        modelBuilder.Entity<Analysis>()
            .HasMany(a => a.LogAlerts)
            .WithOne(al => al.Analysis)
            .HasForeignKey(al => al.AnalysisId)
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
    }
}
