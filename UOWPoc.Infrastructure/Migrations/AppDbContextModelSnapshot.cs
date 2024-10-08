﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UOWPoc.Infrastructure.Data;

#nullable disable

namespace UOWPoc.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("UOWPoc.Entities.Address", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Apartment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("POBox")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonId")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("lastUpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Address", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "e006c4e9-35e3-4577-a239-10bfa9d331bc",
                            Apartment = "3",
                            City = "Cairo",
                            Country = "Egypt",
                            CreatedAt = new DateTime(2024, 9, 30, 1, 10, 17, 112, DateTimeKind.Local).AddTicks(3302),
                            IsDeleted = false,
                            POBox = "7575",
                            PersonId = "414d02f2-5e14-4eac-9b69-36e384ec5cb9",
                            Street = "test street"
                        },
                        new
                        {
                            Id = "d9c10a3f-ec95-4c2d-977f-a68bfc18501a",
                            Apartment = "54",
                            City = "Riydah",
                            Country = "KSA",
                            CreatedAt = new DateTime(2024, 9, 30, 1, 10, 17, 112, DateTimeKind.Local).AddTicks(3304),
                            IsDeleted = false,
                            POBox = "443543",
                            PersonId = "57de39c7-6e23-49c1-ad13-dcacf79a6629",
                            Street = "Almourabe"
                        });
                });

            modelBuilder.Entity("UOWPoc.Entities.Person", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NationalityId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("lastUpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("NationalityId");

                    b.ToTable("Person", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "414d02f2-5e14-4eac-9b69-36e384ec5cb9",
                            CreatedAt = new DateTime(2024, 9, 30, 1, 10, 17, 112, DateTimeKind.Local).AddTicks(3279),
                            FirstName = "Saher",
                            IsDeleted = false,
                            LastName = "Fahd",
                            NationalityId = 1
                        },
                        new
                        {
                            Id = "57de39c7-6e23-49c1-ad13-dcacf79a6629",
                            CreatedAt = new DateTime(2024, 9, 30, 1, 10, 17, 112, DateTimeKind.Local).AddTicks(3289),
                            FirstName = "Saher",
                            IsDeleted = false,
                            LastName = "Said",
                            NationalityId = 2
                        });
                });

            modelBuilder.Entity("UOwPoc.Core.Entities.Nationality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UniqueName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UniqueName")
                        .IsUnique();

                    b.ToTable("Nationality", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            Name = "Egypt",
                            UniqueName = "Egypt"
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            Name = "KSA",
                            UniqueName = "KSA"
                        });
                });

            modelBuilder.Entity("UOWPoc.Entities.Address", b =>
                {
                    b.HasOne("UOWPoc.Entities.Person", "Person")
                        .WithMany("Addresses")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("UOWPoc.Entities.Person", b =>
                {
                    b.HasOne("UOwPoc.Core.Entities.Nationality", "Nationality")
                        .WithMany("Persons")
                        .HasForeignKey("NationalityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Nationality");
                });

            modelBuilder.Entity("UOWPoc.Entities.Person", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("UOwPoc.Core.Entities.Nationality", b =>
                {
                    b.Navigation("Persons");
                });
#pragma warning restore 612, 618
        }
    }
}
