﻿// <auto-generated />
using System;
using MarucciHotel.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MarucciHotel.Migrations
{
    [DbContext(typeof(MarucciHotelContext))]
    partial class MarucciHotelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MarucciHotel.Models.Camera", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Descrizione")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Disponibilita")
                        .HasColumnType("bit");

                    b.Property<bool>("Doppia")
                        .HasColumnType("bit");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Camera");
                });

            modelBuilder.Entity("MarucciHotel.Models.Clienti", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Cellulare")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Citta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cod_Fisc")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("Cognome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Provincia")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Clienti");
                });

            modelBuilder.Entity("MarucciHotel.Models.Login", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Login");
                });

            modelBuilder.Entity("MarucciHotel.Models.Pensione", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<double?>("Prezzo")
                        .HasColumnType("float");

                    b.Property<string>("Tipologia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Pensione");
                });

            modelBuilder.Entity("MarucciHotel.Models.Prenotazione", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<double>("Acconto")
                        .HasColumnType("float");

                    b.Property<string>("Anno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataFineSoggiorno")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInizioSoggiorno")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataPrenotazione")
                        .HasColumnType("datetime2");

                    b.Property<int>("IDCamera")
                        .HasColumnType("int");

                    b.Property<int>("IDCliente")
                        .HasColumnType("int");

                    b.Property<int>("IDPensione")
                        .HasColumnType("int");

                    b.Property<double>("Prezzo")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("IDCamera");

                    b.HasIndex("IDCliente");

                    b.HasIndex("IDPensione");

                    b.ToTable("Prenotazione");
                });

            modelBuilder.Entity("MarucciHotel.Models.Servizi", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("DataRichiestaServizio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descrizione")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IDPrenotazione")
                        .HasColumnType("int");

                    b.Property<double?>("Prezzo")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("IDPrenotazione");

                    b.ToTable("Servizi");
                });

            modelBuilder.Entity("MarucciHotel.Models.Prenotazione", b =>
                {
                    b.HasOne("MarucciHotel.Models.Camera", "Camera")
                        .WithMany()
                        .HasForeignKey("IDCamera")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MarucciHotel.Models.Clienti", "Cliente")
                        .WithMany()
                        .HasForeignKey("IDCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MarucciHotel.Models.Pensione", "Pensione")
                        .WithMany()
                        .HasForeignKey("IDPensione")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Camera");

                    b.Navigation("Cliente");

                    b.Navigation("Pensione");
                });

            modelBuilder.Entity("MarucciHotel.Models.Servizi", b =>
                {
                    b.HasOne("MarucciHotel.Models.Prenotazione", "Prenotazione")
                        .WithMany()
                        .HasForeignKey("IDPrenotazione")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prenotazione");
                });
#pragma warning restore 612, 618
        }
    }
}