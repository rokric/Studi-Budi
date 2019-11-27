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
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<SubjectRequest> SubjectRequest { get; set; }
        public virtual DbSet<Report> Report { get; set; }

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

            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.QuestionID).HasColumnName("questionid");

                entity.Property(e => e.StudentName)
                    .IsRequired()
                    .HasColumnName("studentname")
                    .HasMaxLength(50);

                entity.Property(e => e.TeacherName)
                    .IsRequired()
                    .HasColumnName("teachername")
                    .HasMaxLength(50);

                entity.Property(e => e.SubjectTitle)
                    .IsRequired()
                    .HasColumnName("subjectitle")
                    .HasMaxLength(50);

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasColumnName("message")
                    .HasMaxLength(500);

                entity.Property(e => e.Answer)
                    .IsRequired(false)
                    .HasColumnName("answer")
                    .HasMaxLength(500);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status");
            });


            modelBuilder.Entity<Report>(entity =>
            {
                entity.Property(e => e.ID).HasColumnName("id");

                entity.Property(e => e.UserID)
                    .IsRequired()
                    .HasColumnName("userid");

                entity.Property(e => e.Message)
                 .IsRequired()
                 .HasColumnName("message")
                 .HasMaxLength(500);

                entity.Property(e => e.Until)
                    .HasColumnName("until");

            });

            modelBuilder.Entity<SubjectRequest>(entity =>
            {
                entity.Property(e => e.ID).HasColumnName("id");

                entity.Property(e => e.UserID)
                    .IsRequired()
                    .HasColumnName("userid");

                entity.Property(e => e.Title)
                 .IsRequired()
                 .HasColumnName("title")
                 .HasMaxLength(50);

            });

            modelBuilder.Entity<Teaching>().ToTable("Teaching");
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
