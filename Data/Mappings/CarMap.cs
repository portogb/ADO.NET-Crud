using ConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp.Data.Mappings;

public class CarMap : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.ToTable("Car");

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();
        
        builder.Property(c => c.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasColumnType("VARCHAR")
            .HasMaxLength(30);
        
        builder.Property(c => c.Color)
            .IsRequired()
            .HasColumnName("Color")
            .HasColumnType("VARCHAR")
            .HasMaxLength(14);
        
        builder.Property(c => c.CarKey)
            .IsRequired()
            .HasColumnName("CarKey")
            .HasColumnType("CHAR")
            .HasMaxLength(6);
        
        builder.Property(c => c.FabricationYear)
            .IsRequired()
            .HasColumnName("FabricationYear")
            .HasColumnType("SMALLDATETIME")
            .HasMaxLength(60)
            .HasDefaultValueSql("GETDATE()");
    }
}