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
    [Migration("20220905095913_CityID can be null")]
    partial class CityIDcanbenull
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LanguagePersonModel", b =>
                {
                    b.Property<string>("LanguagesListLanguageName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PeopleListSSN")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LanguagesListLanguageName", "PeopleListSSN");

                    b.HasIndex("PeopleListSSN");

                    b.ToTable("LanguagePersonModel");

                    b.HasData(
                        new
                        {
                            LanguagesListLanguageName = "Mexican",
                            PeopleListSSN = "2001-11-31-8952"
                        },
                        new
                        {
                            LanguagesListLanguageName = "Japanese",
                            PeopleListSSN = "2001-11-31-8952"
                        },
                        new
                        {
                            LanguagesListLanguageName = "Swedish",
                            PeopleListSSN = "1995-03-07-9898"
                        });
                });

            modelBuilder.Entity("LexiconMVC.Models.City", b =>
                {
                    b.Property<string>("CityPostalCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CityPostalCode");

                    b.HasIndex("CountryID");

                    b.ToTable("cities");

                    b.HasData(
                        new
                        {
                            CityPostalCode = "41672",
                            CityName = "Gothenburg",
                            CountryID = "+46"
                        },
                        new
                        {
                            CityPostalCode = "50632",
                            CityName = "Borås",
                            CountryID = "+46"
                        },
                        new
                        {
                            CityPostalCode = "0010",
                            CityName = "Oslo",
                            CountryID = "+47"
                        },
                        new
                        {
                            CityPostalCode = "78613",
                            CityName = "Austin",
                            CountryID = "+1"
                        },
                        new
                        {
                            CityPostalCode = "22000",
                            CityName = "Tijuana",
                            CountryID = "+52"
                        },
                        new
                        {
                            CityPostalCode = "100",
                            CityName = "Tokyo",
                            CountryID = "+82"
                        },
                        new
                        {
                            CityPostalCode = "3000",
                            CityName = "Melbourne",
                            CountryID = "+61"
                        },
                        new
                        {
                            CityPostalCode = "60601",
                            CityName = "Chicago",
                            CountryID = "+1"
                        },
                        new
                        {
                            CityPostalCode = "602",
                            CityName = "Kyoto",
                            CountryID = "+82"
                        },
                        new
                        {
                            CityPostalCode = "5005",
                            CityName = "Bergen",
                            CountryID = "+47"
                        });
                });

            modelBuilder.Entity("LexiconMVC.Models.Country", b =>
                {
                    b.Property<string>("CountryCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Continent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryCode");

                    b.ToTable("countries");

                    b.HasData(
                        new
                        {
                            CountryCode = "+46",
                            Continent = "Europe",
                            CountryName = "Sweden"
                        },
                        new
                        {
                            CountryCode = "+47",
                            Continent = "Europe",
                            CountryName = "Norway"
                        },
                        new
                        {
                            CountryCode = "+1",
                            Continent = "North America",
                            CountryName = "USA"
                        },
                        new
                        {
                            CountryCode = "+52",
                            Continent = "South America",
                            CountryName = "Mexico"
                        },
                        new
                        {
                            CountryCode = "+82",
                            Continent = "Asia",
                            CountryName = "Japan"
                        },
                        new
                        {
                            CountryCode = "+61",
                            Continent = "Australia",
                            CountryName = "Australia"
                        });
                });

            modelBuilder.Entity("LexiconMVC.Models.Language", b =>
                {
                    b.Property<string>("LanguageName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LanguageShortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LanguageName");

                    b.ToTable("Languages");

                    b.HasData(
                        new
                        {
                            LanguageName = "Swedish",
                            LanguageShortName = "SWE"
                        },
                        new
                        {
                            LanguageName = "Japanese",
                            LanguageShortName = "JAP"
                        },
                        new
                        {
                            LanguageName = "Norwegian",
                            LanguageShortName = "NOR"
                        },
                        new
                        {
                            LanguageName = "Australian",
                            LanguageShortName = "AUS"
                        },
                        new
                        {
                            LanguageName = "Mexican",
                            LanguageShortName = "MEX"
                        },
                        new
                        {
                            LanguageName = "English",
                            LanguageShortName = "USA"
                        });
                });

            modelBuilder.Entity("LexiconMVC.Models.PersonModel", b =>
                {
                    b.Property<string>("SSN")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CityID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Phonenumber")
                        .HasColumnType("int");

                    b.HasKey("SSN");

                    b.HasIndex("CityID");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            SSN = "196103058877",
                            CityID = "41672",
                            Name = "Simon Eliasson",
                            Phonenumber = 738450197
                        },
                        new
                        {
                            SSN = "198309067744",
                            CityID = "50632",
                            Name = "Janne Karlsson",
                            Phonenumber = 709952132
                        },
                        new
                        {
                            SSN = "199901023366",
                            CityID = "50632",
                            Name = "Annie Svensson",
                            Phonenumber = 782161234
                        },
                        new
                        {
                            SSN = "200509012541",
                            CityID = "100",
                            Name = "Kalle Carlsson",
                            Phonenumber = 741237894
                        },
                        new
                        {
                            SSN = "2001-11-31-8952",
                            CityID = "3000",
                            Name = "Andy Hjert",
                            Phonenumber = 738660102
                        },
                        new
                        {
                            SSN = "1978-01-01-3578",
                            CityID = "100",
                            Name = "Björn Bergman",
                            Phonenumber = 759982251
                        },
                        new
                        {
                            SSN = "1995-03-07-9898",
                            CityID = "60601",
                            Name = "Sara Strand",
                            Phonenumber = 761496378
                        },
                        new
                        {
                            SSN = "1969-08-01-7487",
                            CityID = "602",
                            Name = "Frida Svensson",
                            Phonenumber = 778852211
                        });
                });

            modelBuilder.Entity("LanguagePersonModel", b =>
                {
                    b.HasOne("LexiconMVC.Models.Language", null)
                        .WithMany()
                        .HasForeignKey("LanguagesListLanguageName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LexiconMVC.Models.PersonModel", null)
                        .WithMany()
                        .HasForeignKey("PeopleListSSN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LexiconMVC.Models.City", b =>
                {
                    b.HasOne("LexiconMVC.Models.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("LexiconMVC.Models.PersonModel", b =>
                {
                    b.HasOne("LexiconMVC.Models.City", "City")
                        .WithMany("People")
                        .HasForeignKey("CityID");

                    b.Navigation("City");
                });

            modelBuilder.Entity("LexiconMVC.Models.City", b =>
                {
                    b.Navigation("People");
                });

            modelBuilder.Entity("LexiconMVC.Models.Country", b =>
                {
                    b.Navigation("Cities");
                });
#pragma warning restore 612, 618
        }
    }
}