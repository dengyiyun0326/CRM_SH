using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApi_OfficeServer_SH.Models
{
    public partial class OfficeDBContext : DbContext
    {
        public virtual DbSet<CaseQueue> CaseQueue { get; set; }
        public virtual DbSet<CaseWellness> CaseWellness { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=tcp:officedb.database.windows.net,1433;Database=OfficeDB;Persist Security Info=False;User ID=tingyabruce;Password=QQiloveyou437542894;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CaseQueue>(entity =>
            {
                entity.HasKey(e => e.CaseId);

                entity.Property(e => e.CaseId)
                    .HasColumnName("caseID")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.BelongQueue).HasColumnName("belongQueue");

                entity.Property(e => e.CallingCountry)
                    .IsRequired()
                    .HasColumnName("callingCountry");

                entity.Property(e => e.CustomerTitle).HasColumnName("customerTitle");

                entity.Property(e => e.EndTimeSla)
                    .IsRequired()
                    .HasColumnName("endTimeSLA");

                entity.Property(e => e.IfAssign)
                    .HasColumnName("ifAssign")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IfBypass)
                    .HasColumnName("ifBypass")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InternalTitle).HasColumnName("internalTitle");

                entity.Property(e => e.Severity)
                    .IsRequired()
                    .HasColumnName("severity");

                entity.Property(e => e.SupportTopic).HasColumnName("supportTopic");
            });

            modelBuilder.Entity<CaseWellness>(entity =>
            {
                entity.HasKey(e => e.CaseId);

                entity.Property(e => e.CaseId)
                    .HasColumnName("CaseID")
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.IdleDays).HasMaxLength(50);

                entity.Property(e => e.Labor)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.OpenDays).HasMaxLength(50);

                entity.Property(e => e.OwnerAlias).IsRequired();
            });
        }
    }
}
