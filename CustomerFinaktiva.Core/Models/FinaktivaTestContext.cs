using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CustomerFinaktiva.Core.Models
{
    public partial class FinaktivaTestContext : DbContext
    {
        public FinaktivaTestContext()
        {
        }

        public FinaktivaTestContext(DbContextOptions<FinaktivaTestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ClientProvider> ClientProviders { get; set; }
        public virtual DbSet<DocumentType> DocumentTypes { get; set; }
        public virtual DbSet<Provider> Providers { get; set; }
        public virtual DbSet<VwClient> VwClients { get; set; }
        public virtual DbSet<VwClientProvider> VwClientProviders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=FinaktivaTest;Persist Security Info=True;User ID=sa;Password=Willis2021;MultipleActiveResultSets=True;Application Name=EntityFramework");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.IdClient)
                    .HasName("PK__client__A6A610D496D04A38");

                entity.ToTable("client");

                entity.Property(e => e.IdClient).HasColumnName("idClient");

                entity.Property(e => e.BusinessName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("businessName");

                entity.Property(e => e.DocumentNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("documentNumber");

                entity.Property(e => e.IdDocumentType).HasColumnName("idDocumentType");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Names)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("names");

                entity.Property(e => e.SalesLastYear)
                    .HasColumnType("money")
                    .HasColumnName("salesLastYear");

                entity.Property(e => e.Surnames)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("surnames");
            });

            modelBuilder.Entity<ClientProvider>(entity =>
            {
                entity.HasKey(e => e.IdClientProvider)
                    .HasName("PK__clientPr__0682EA33ED2C98AD");

                entity.ToTable("clientProvider");

                entity.Property(e => e.IdClientProvider).HasColumnName("idClientProvider");

                entity.Property(e => e.IdClient).HasColumnName("idClient");

                entity.Property(e => e.IdProvider).HasColumnName("idProvider");

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.ClientProviders)
                    .HasForeignKey(d => d.IdClient)
                    .HasConstraintName("FK_ClientProvider_Client");

                entity.HasOne(d => d.IdProviderNavigation)
                    .WithMany(p => p.ClientProviders)
                    .HasForeignKey(d => d.IdProvider)
                    .HasConstraintName("FK_ClientProvider_Provider");
            });

            modelBuilder.Entity<DocumentType>(entity =>
            {
                entity.HasKey(e => e.IdDocumentType)
                    .HasName("PK__document__9F1F4F685E4F3500");

                entity.ToTable("documentType");

                entity.Property(e => e.IdDocumentType).HasColumnName("idDocumentType");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Name)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.HasKey(e => e.IdProvider)
                    .HasName("PK__provider__CFAFC10FD535AA10");

                entity.ToTable("provider");

                entity.Property(e => e.IdProvider).HasColumnName("idProvider");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<VwClient>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwClients");

                entity.Property(e => e.BusinessName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("businessName");

                entity.Property(e => e.DocumentNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("documentNumber");

                entity.Property(e => e.IdClient)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idClient");

                entity.Property(e => e.IdDocumentType).HasColumnName("idDocumentType");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Names)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("names");

                entity.Property(e => e.Providers).HasColumnName("providers");

                entity.Property(e => e.SalesLastYear)
                    .HasColumnType("money")
                    .HasColumnName("salesLastYear");

                entity.Property(e => e.Surnames)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("surnames");
            });

            modelBuilder.Entity<VwClientProvider>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwClientProviders");

                entity.Property(e => e.IdClient).HasColumnName("idClient");

                entity.Property(e => e.IdClientProvider).HasColumnName("idClientProvider");

                entity.Property(e => e.IdProvider).HasColumnName("idProvider");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
