﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TermProject.Models;

#nullable disable

namespace TermProject.Migrations
{
    [DbContext(typeof(PizzaContext))]
    [Migration("20231212180456_MenuCreate")]
    partial class MenuCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TermProject.Models.Loyalty", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("City")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("MenuId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ID");

                    b.HasIndex("MenuId");

                    b.ToTable("Loyalties");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            City = "Seattle",
                            Email = "jjohnson@gmail.com",
                            FirstName = "John",
                            LastName = "Johnson",
                            MenuId = 1,
                            PhoneNumber = "5559874563",
                            State = "Washington"
                        },
                        new
                        {
                            ID = 2,
                            City = "Olympia",
                            Email = "rrobertson@gmail.com",
                            FirstName = "Robert",
                            LastName = "Robertson",
                            MenuId = 3,
                            PhoneNumber = "5559875823",
                            State = "Washington"
                        },
                        new
                        {
                            ID = 3,
                            City = "Portland",
                            Email = "richierich@gmail.com",
                            FirstName = "Richard",
                            LastName = "Richardson",
                            MenuId = 2,
                            PhoneNumber = "5552584596",
                            State = "Oregon"
                        });
                });

            modelBuilder.Entity("TermProject.Models.Menu", b =>
                {
                    b.Property<int>("MenuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MenuId"), 1L, 1);

                    b.Property<string>("LoyaltyTier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MenuId");

                    b.ToTable("Menu");

                    b.HasData(
                        new
                        {
                            MenuId = 1,
                            LoyaltyTier = "Newbie",
                            Name = "Breadstix"
                        },
                        new
                        {
                            MenuId = 2,
                            LoyaltyTier = "Novice",
                            Name = "Wings"
                        },
                        new
                        {
                            MenuId = 3,
                            LoyaltyTier = "Veteran",
                            Name = "Pizza"
                        });
                });

            modelBuilder.Entity("TermProject.Models.Loyalty", b =>
                {
                    b.HasOne("TermProject.Models.Menu", "Menu")
                        .WithMany()
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");
                });
#pragma warning restore 612, 618
        }
    }
}