using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestFunctionExport.Models;

namespace TestFunctionExport.Database;
public class CccCodeComparisonEntityConfiguration : IEntityTypeConfiguration<CccCodeComparisonEntity>
{
    public void Configure(EntityTypeBuilder<CccCodeComparisonEntity> builder)
    {
        builder.ToTable("CccCodeComparisons", "binning");

    }
}
