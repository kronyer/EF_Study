﻿// <auto-generated />
using EF_Study.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EF_Study.DataAccess.Migrations
{
    [DbContext(typeof(EF_StudyDbContext))]
    [Migration("20241210210705_bookToDb")]
    partial class bookToDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EF_Study.Model.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"));

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            ISBN = "9781119449270",
                            Price = 45.0,
                            Title = "Professional C# 7 and .NET Core 2.0"
                        },
                        new
                        {
                            BookId = 2,
                            ISBN = "9781119096603",
                            Price = 45.0,
                            Title = "Professional C# 6 and .NET Core 1.0"
                        },
                        new
                        {
                            BookId = 3,
                            ISBN = "9781593274085",
                            Price = 32.0,
                            Title = "JavaScript for Kids"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}