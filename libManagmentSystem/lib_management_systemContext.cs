using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace libManagmentSystem
{
    public partial class lib_management_systemContext : DbContext
    {
        public lib_management_systemContext()
        {
        }

        public lib_management_systemContext(DbContextOptions<lib_management_systemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<Students> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=lib_management_system;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.BookId).HasColumnName("Book_Id");

                entity.Property(e => e.BookAuthor)
                    .IsRequired()
                    .HasColumnName("Book_Author")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BookName)
                    .IsRequired()
                    .HasColumnName("Book_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Edition)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Publication)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(e => e.SId)
                    .HasName("PK__students__A3DFF08D51BF2E25");

                entity.ToTable("students");

                entity.Property(e => e.SId).HasColumnName("S_Id");

                entity.Property(e => e.BranchName)
                    .IsRequired()
                    .HasColumnName("Branch_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Passwrd)
                    .IsRequired()
                    .HasColumnName("passwrd")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SName)
                    .IsRequired()
                    .HasColumnName("S_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
