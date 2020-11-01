using Countries.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Countries.Data.EntityConfigurations
{
    public class CountryConfigurations : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Name)
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property(c => c.IsCool)
                .IsRequired();

            builder
                .Property(c => c.Description)
                .HasMaxLength(500)
                .IsRequired();

            builder
                .Property(c => c.BestDayToVisit)
                .HasColumnType("date")
                .IsRequired(true);

            builder
                .Property(c => c.CurrencyId)
                .IsRequired();


        }
    }
}
