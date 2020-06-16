using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RegBackEndNew.Models
{
    public partial class RGTContext : DbContext
    {
        public RGTContext()
        {
        }

        public RGTContext(DbContextOptions<RGTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Register> Register { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
   optionsBuilder.UseSqlServer("Server=(local); Database=RGT;Trusted_Connection=True; MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Register>(entity =>
            {
                entity.ToTable("REGISTER");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.RegAge).HasColumnName("REG_AGE");

                entity.Property(e => e.RegCode)
                    .HasColumnName("REG_CODE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RegName)
                    .HasColumnName("REG_NAME")
                    .HasMaxLength(150);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
