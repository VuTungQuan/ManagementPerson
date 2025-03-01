﻿// <auto-generated />
using ManagementPerson;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ManagementPerson.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20240805091435_Tbl")]
    partial class Tbl
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ManagementPerson.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.ToTable("addresses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Hà Nội",
                            Number = "30",
                            PersonId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Hải Dương",
                            Number = "34",
                            PersonId = 2
                        },
                        new
                        {
                            Id = 3,
                            Name = "Hải Phòng",
                            Number = "15",
                            PersonId = 3
                        },
                        new
                        {
                            Id = 4,
                            Name = "Hưng Yên",
                            Number = "89",
                            PersonId = 4
                        },
                        new
                        {
                            Id = 5,
                            Name = "Hải Dương",
                            Number = "34",
                            PersonId = 5
                        },
                        new
                        {
                            Id = 6,
                            Name = "Hải Phòng",
                            Number = "15",
                            PersonId = 6
                        });
                });

            modelBuilder.Entity("ManagementPerson.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonId"), 1L, 1);

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonId");

                    b.ToTable("Person", (string)null);
                });

            modelBuilder.Entity("ManagementPerson.Models.Professor", b =>
                {
                    b.HasBaseType("ManagementPerson.Models.Person");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.ToTable("Professor", (string)null);

                    b.HasData(
                        new
                        {
                            PersonId = 4,
                            EmailAddress = "person4@example.com",
                            Name = "Vu Minh Duc",
                            PhoneNumber = "1234567894",
                            Salary = 50000m
                        },
                        new
                        {
                            PersonId = 5,
                            EmailAddress = "person5@example.com",
                            Name = "Nguyen Huong Duyen",
                            PhoneNumber = "1234567895",
                            Salary = 60000m
                        },
                        new
                        {
                            PersonId = 6,
                            EmailAddress = "person6@example.com",
                            Name = "Hoang Thi Lan",
                            PhoneNumber = "1234567896",
                            Salary = 70000m
                        });
                });

            modelBuilder.Entity("ManagementPerson.Models.Student", b =>
                {
                    b.HasBaseType("ManagementPerson.Models.Person");

                    b.Property<double>("AverageMark")
                        .HasColumnType("float");

                    b.Property<string>("StudentNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Student", (string)null);

                    b.HasData(
                        new
                        {
                            PersonId = 1,
                            EmailAddress = "person1@example.com",
                            Name = "Vu Tung Quan",
                            PhoneNumber = "1234567891",
                            AverageMark = 9.5,
                            StudentNumber = "000001"
                        },
                        new
                        {
                            PersonId = 2,
                            EmailAddress = "person2@example.com",
                            Name = "Nguyen Ai Dan",
                            PhoneNumber = "1234567892",
                            AverageMark = 9.0,
                            StudentNumber = "000002"
                        },
                        new
                        {
                            PersonId = 3,
                            EmailAddress = "person3@example.com",
                            Name = "Duc Minh Hoang",
                            PhoneNumber = "1234567893",
                            AverageMark = 8.5,
                            StudentNumber = "000003"
                        });
                });

            modelBuilder.Entity("ManagementPerson.Models.Address", b =>
                {
                    b.HasOne("ManagementPerson.Models.Person", "Person")
                        .WithOne("Address")
                        .HasForeignKey("ManagementPerson.Models.Address", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("ManagementPerson.Models.Professor", b =>
                {
                    b.HasOne("ManagementPerson.Models.Person", null)
                        .WithOne()
                        .HasForeignKey("ManagementPerson.Models.Professor", "PersonId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ManagementPerson.Models.Student", b =>
                {
                    b.HasOne("ManagementPerson.Models.Person", null)
                        .WithOne()
                        .HasForeignKey("ManagementPerson.Models.Student", "PersonId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ManagementPerson.Models.Person", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
