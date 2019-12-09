﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudyBuddy.Web.RazorPages.Data;

namespace StudyBuddy.Web.RazorPages.Migrations
{
    [DbContext(typeof(StudiBudiContext))]
    [Migration("20191209174145_fk_updated")]
    partial class fk_updated
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StudyBuddy.Web.RazorPages.Models.Ban", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Until")
                        .HasColumnName("until")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserID")
                        .HasColumnName("userid")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Ban");
                });

            modelBuilder.Entity("StudyBuddy.Web.RazorPages.Models.FAQ", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnName("answer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Answered")
                        .HasColumnName("answered")
                        .HasColumnType("int");

                    b.Property<int>("Points")
                        .HasColumnName("points")
                        .HasColumnType("int");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnName("question")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubjectID")
                        .HasColumnName("subjectID")
                        .HasColumnType("int");

                    b.Property<int>("TeacherID")
                        .HasColumnName("teacherID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SubjectID");

                    b.HasIndex("TeacherID");

                    b.ToTable("FAQ");
                });

            modelBuilder.Entity("StudyBuddy.Web.RazorPages.Models.Question", b =>
                {
                    b.Property<int>("QuestionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("questionid")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Answer")
                        .HasColumnName("answer")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnName("message")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnName("status")
                        .HasColumnType("int");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasColumnName("studentname")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("SubjectTitle")
                        .IsRequired()
                        .HasColumnName("subjectitle")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("TeacherName")
                        .IsRequired()
                        .HasColumnName("teachername")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("QuestionID");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("StudyBuddy.Web.RazorPages.Models.Report", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnName("message")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<int>("UserID")
                        .HasColumnName("userid")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Report");
                });

            modelBuilder.Entity("StudyBuddy.Web.RazorPages.Models.Subject", b =>
                {
                    b.Property<int>("Subjectid")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("subjectid")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("title")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Subjectid");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("StudyBuddy.Web.RazorPages.Models.SubjectRequest", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("title")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("UserID")
                        .HasColumnName("userid")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("SubjectRequest");
                });

            modelBuilder.Entity("StudyBuddy.Web.RazorPages.Models.Teaching", b =>
                {
                    b.Property<int>("Userid")
                        .HasColumnName("userid")
                        .HasColumnType("int");

                    b.Property<int>("Subjectid")
                        .HasColumnName("subjectid")
                        .HasColumnType("int");

                    b.HasKey("Userid", "Subjectid")
                        .HasName("PK__tmp_ms_x__516FA6603C8B3913");

                    b.HasIndex("Subjectid");

                    b.ToTable("Teaching");
                });

            modelBuilder.Entity("StudyBuddy.Web.RazorPages.Models.User", b =>
                {
                    b.Property<int>("Userid")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("userid")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nick")
                        .IsRequired()
                        .HasColumnName("nick")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("password")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Profession")
                        .IsRequired()
                        .HasColumnName("profession")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Userid");

                    b.ToTable("User");
                });

            modelBuilder.Entity("StudyBuddy.Web.RazorPages.Models.Ban", b =>
                {
                    b.HasOne("StudyBuddy.Web.RazorPages.Models.User", "User")
                        .WithMany("Bans")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StudyBuddy.Web.RazorPages.Models.FAQ", b =>
                {
                    b.HasOne("StudyBuddy.Web.RazorPages.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudyBuddy.Web.RazorPages.Models.User", "User")
                        .WithMany("FAQs")
                        .HasForeignKey("TeacherID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StudyBuddy.Web.RazorPages.Models.Report", b =>
                {
                    b.HasOne("StudyBuddy.Web.RazorPages.Models.User", "User")
                        .WithMany("Reports")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StudyBuddy.Web.RazorPages.Models.SubjectRequest", b =>
                {
                    b.HasOne("StudyBuddy.Web.RazorPages.Models.User", "User")
                        .WithMany("SubjectRequests")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StudyBuddy.Web.RazorPages.Models.Teaching", b =>
                {
                    b.HasOne("StudyBuddy.Web.RazorPages.Models.Subject", "Subject")
                        .WithMany("Teachings")
                        .HasForeignKey("Subjectid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudyBuddy.Web.RazorPages.Models.User", "User")
                        .WithMany("Teachings")
                        .HasForeignKey("Userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
