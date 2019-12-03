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
    [Migration("20191129211002_added_ban_table")]
    partial class added_ban_table
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

                    b.ToTable("Ban");
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
#pragma warning restore 612, 618
        }
    }
}
