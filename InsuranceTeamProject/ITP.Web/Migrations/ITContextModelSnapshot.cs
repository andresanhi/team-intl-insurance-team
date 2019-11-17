﻿// <auto-generated />
using System;
using ITP.WebApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ITP.WebApp.Migrations
{
    [DbContext(typeof(ITContext))]
    partial class ITContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ITP.WebApp.Models.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BornDate")
                        .HasColumnType("Date");

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<int>("DocNumber");

                    b.Property<string>("DocType");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("ITP.WebApp.Models.Insurance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Baseprice");

                    b.Property<string>("City");

                    b.Property<Guid>("IdCustomer");

                    b.Property<Guid>("IdVehicle");

                    b.Property<double>("IncreaseByAge");

                    b.Property<double>("IncreaseByCar");

                    b.Property<double>("IncreaseByCity");

                    b.Property<double>("Total");

                    b.HasKey("Id");

                    b.ToTable("Insurance");
                });

            modelBuilder.Entity("ITP.WebApp.Models.Vehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Brand")
                        .IsRequired();

                    b.Property<Guid>("CustomerId");

                    b.Property<string>("Model")
                        .IsRequired();

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Vehicle");
                });

            modelBuilder.Entity("ITP.WebApp.Models.Vehicle", b =>
                {
                    b.HasOne("ITP.WebApp.Models.Customer")
                        .WithMany("Vehicles")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}