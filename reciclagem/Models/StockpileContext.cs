using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace reciclagem.Models
{
    public partial class StockpileContext : DbContext
    {
        public StockpileContext()
        {
        }

        public StockpileContext(DbContextOptions<StockpileContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Materials> Materials { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=BREU_NAVE_MAE\SQLEXPRESS;Database=Stockpile;
Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Materials>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BuyPrice).HasColumnName("buyPrice");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SellPrice).HasColumnName("sellPrice");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
