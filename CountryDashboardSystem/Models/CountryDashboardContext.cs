using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CountryDashboardSystem.Models
{
    public partial class CountryDashboardContext : DbContext
    {
        
        public CountryDashboardContext(DbContextOptions<CountryDashboardContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Country> Countries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-R812OIIJ;Initial Catalog=CountryDashboard;User ID=sa;Password=me.close;Trusted_Connection=True;");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.CountryId)
                    .HasColumnName("CountryID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CountryName).HasMaxLength(255);

                entity.Property(e => e.IsoCode)
                    .HasMaxLength(50)
                    .HasColumnName("ISO_Code");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
