// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TruckRegister.Repository;

namespace TruckRegister.Repository.Migrations
{
    [DbContext(typeof(TruckContext))]
    [Migration("20210621030521_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TruckRegister.Entities.Model", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ModelDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("YearOfModel")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Model");
                });

            modelBuilder.Entity("TruckRegister.Entities.Truck", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdModel")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("YearOfManufacture")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdModel");

                    b.ToTable("Truck");
                });

            modelBuilder.Entity("TruckRegister.Entities.Truck", b =>
                {
                    b.HasOne("TruckRegister.Entities.Model", "ModelTruck")
                        .WithMany("Trucks")
                        .HasForeignKey("IdModel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ModelTruck");
                });

            modelBuilder.Entity("TruckRegister.Entities.Model", b =>
                {
                    b.Navigation("Trucks");
                });
#pragma warning restore 612, 618
        }
    }
}
