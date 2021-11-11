﻿// <auto-generated />
using System;
using Gestion_Prod_Catalogue.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Gestion_Prod_Catalogue.Migrations
{
    [DbContext(typeof(CatalogueDbContext))]
    [Migration("20211111160333_firstMigration")]
    partial class firstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Gestion_Prod_Catalogue.Models.Catalogue", b =>
                {
                    b.Property<int>("CatalogueID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("NomCatalogue")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("CatalogueID");

                    b.ToTable("Catalogues");
                });

            modelBuilder.Entity("Gestion_Prod_Catalogue.Models.Produit", b =>
                {
                    b.Property<int>("ProduitID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("CatalogueID")
                        .HasColumnType("int");

                    b.Property<int>("CategorieID")
                        .HasColumnType("int");

                    b.Property<string>("Designation")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Prix")
                        .HasColumnType("float");

                    b.Property<int>("Quantite")
                        .HasColumnType("int");

                    b.HasKey("ProduitID");

                    b.HasIndex("CatalogueID");

                    b.ToTable("Produits");
                });

            modelBuilder.Entity("Gestion_Prod_Catalogue.Models.Produit", b =>
                {
                    b.HasOne("Gestion_Prod_Catalogue.Models.Catalogue", "Catalogue")
                        .WithMany("ListeProd")
                        .HasForeignKey("CatalogueID");

                    b.Navigation("Catalogue");
                });

            modelBuilder.Entity("Gestion_Prod_Catalogue.Models.Catalogue", b =>
                {
                    b.Navigation("ListeProd");
                });
#pragma warning restore 612, 618
        }
    }
}
