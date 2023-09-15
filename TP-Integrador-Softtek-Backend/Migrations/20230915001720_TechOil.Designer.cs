﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TP_Integrador_Softtek_Backend.DataAccess;

#nullable disable

namespace TP_Integrador_Softtek_Backend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230915001720_TechOil")]
    partial class TechOil
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TP_Integrador_Softtek_Backend.Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("codProyecto");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("direccion");

                    b.Property<DateTime?>("DischargeDate")
                        .HasColumnType("DATE")
                        .HasColumnName("fechaBaja");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("nombre");

                    b.Property<byte>("State")
                        .HasColumnType("TINYINT")
                        .HasColumnName("estado");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("TP_Integrador_Softtek_Backend.Entities.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("codServicio");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("descr");

                    b.Property<decimal>("HourValue")
                        .HasColumnType("NUMERIC(8,2)")
                        .HasColumnName("valorHora");

                    b.Property<bool>("State")
                        .HasColumnType("BIT")
                        .HasColumnName("estado");

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("TP_Integrador_Softtek_Backend.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("codUsuario");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("DischargeDate")
                        .HasColumnType("DATE")
                        .HasColumnName("fechaBaja");

                    b.Property<int>("Dni")
                        .HasColumnType("INT")
                        .HasColumnName("dni");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("nombre");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("contrasenia");

                    b.Property<byte>("Type")
                        .HasColumnType("TINYINT")
                        .HasColumnName("tipo");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1010,
                            Dni = 11222333,
                            Name = "Juan Perez",
                            Password = "1234",
                            Type = (byte)1
                        },
                        new
                        {
                            Id = 2020,
                            Dni = 22111555,
                            Name = "Maria Lopez",
                            Password = "2222",
                            Type = (byte)2
                        });
                });

            modelBuilder.Entity("TP_Integrador_Softtek_Backend.Entities.Work", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("codTrabajo");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Cost")
                        .HasColumnType("NUMERIC(10,2)")
                        .HasColumnName("costo");

                    b.Property<DateTime>("Date")
                        .HasColumnType("DATE")
                        .HasColumnName("fecha");

                    b.Property<DateTime?>("DischargeDate")
                        .HasColumnType("DATE")
                        .HasColumnName("fechaBaja");

                    b.Property<decimal>("HourValue")
                        .HasColumnType("NUMERIC(8,2)")
                        .HasColumnName("valorHora");

                    b.Property<int>("NumberOfHours")
                        .HasColumnType("INT")
                        .HasColumnName("cantHoras");

                    b.Property<int>("ProjectId")
                        .HasColumnType("INT")
                        .HasColumnName("codProyecto");

                    b.Property<int>("ServiceId")
                        .HasColumnType("INT")
                        .HasColumnName("codServicio");

                    b.HasKey("Id");

                    b.ToTable("Works");
                });
#pragma warning restore 612, 618
        }
    }
}
