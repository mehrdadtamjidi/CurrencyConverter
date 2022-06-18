using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CurrencyConverter.DataLayer.Entities
{
    public partial class CurrencyConverterDbContext : DbContext
    {
        public CurrencyConverterDbContext()
        {
        }

        public CurrencyConverterDbContext(DbContextOptions<CurrencyConverterDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ConversionRate> ConversionRates { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<VwConversionRateList> VwConversionRateLists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=157.90.206.103,2019;Initial Catalog=CurrencyConverter;User ID=CurrencyConverterDB;Password=8qfDY3XXSd");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Persian_100_CI_AI");

            modelBuilder.Entity<ConversionRate>(entity =>
            {
                entity.ToTable("ConversionRate");

                entity.Property(e => e.Rate).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.FromCurrencyNavigation)
                    .WithMany(p => p.ConversionRateFromCurrencyNavigations)
                    .HasForeignKey(d => d.FromCurrency)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConversionRates_Currencies_FromCurrency");

                entity.HasOne(d => d.ToCurrencyNavigation)
                    .WithMany(p => p.ConversionRateToCurrencyNavigations)
                    .HasForeignKey(d => d.ToCurrency)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConversionRates_Currencies_ToCurrency");
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.ToTable("Currency");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(3);
            });

            modelBuilder.Entity<VwConversionRateList>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VW_ConversionRateList");

                entity.Property(e => e.ConversionRate).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.FromCurrency)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.ToCurrency)
                    .IsRequired()
                    .HasMaxLength(3);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
