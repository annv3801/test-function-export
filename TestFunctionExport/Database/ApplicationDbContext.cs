using Microsoft.EntityFrameworkCore;
using EFCore.NamingConventions;
using TestFunctionExport.Models;

namespace TestFunctionExport.Database;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        base.OnModelCreating(modelBuilder);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql($"Host=localhost;Port=2223;Database=vf_binning_phase_2_backup;Username=postgres;Password=VOIsJ14I563t3dSZqs7c");

        optionsBuilder.UseSnakeCaseNamingConvention();
    }

    public DbSet<CccCodeComparisonEntity> CccCodeComparisons { get; set; }
}