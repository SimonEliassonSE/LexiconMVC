﻿// <auto-generated />
using LexiconMVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LexiconMVC.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220901092432_Changed PersonId to SSN")]
    partial class ChangedPersonIdtoSSN
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LexiconMVC.Models.PersonModel", b =>
                {
                    b.Property<string>("SSN")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Phonenumber")
                        .HasColumnType("int");

                    b.HasKey("SSN");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            SSN = "196103058877",
                            City = "Kinna",
                            Name = "Simon Eliasson",
                            Phonenumber = 738450197
                        },
                        new
                        {
                            SSN = "198309067744",
                            City = "Göteborg",
                            Name = "Janne Karlsson",
                            Phonenumber = 709952132
                        },
                        new
                        {
                            SSN = "199901023366",
                            City = "Borås",
                            Name = "Annie Svensson",
                            Phonenumber = 782161234
                        },
                        new
                        {
                            SSN = "200509012541",
                            City = "Malmö",
                            Name = "Kalle Carlsson",
                            Phonenumber = 741237894
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
