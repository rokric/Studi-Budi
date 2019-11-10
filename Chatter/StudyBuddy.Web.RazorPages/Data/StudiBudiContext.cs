using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using StudyBuddy.Web.RazorPages.Models;

namespace StudyBuddy.Web.RazorPages.Data
{
    public partial class StudiBudiContext : DbContext, IStudiBudiContext
    {
        public StudiBudiContext()
        {
        }

        public StudiBudiContext(DbContextOptions<StudiBudiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<Teaching> Teaching { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer();
            }*/
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subject>(entity =>
            {
                entity.Property(e => e.Subjectid).HasColumnName("subjectid");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Teaching>(entity =>
            {
                entity.HasKey(e => new { e.Userid, e.Subjectid })
                    .HasName("PK__tmp_ms_x__516FA6603C8B3913");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.Subjectid).HasColumnName("subjectid");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.Nick)
                    .IsRequired()
                    .HasColumnName("nick")
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50);

                entity.Property(e => e.Profession)
                    .IsRequired()
                    .HasColumnName("profession")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Teaching>().ToTable("Teaching");
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
