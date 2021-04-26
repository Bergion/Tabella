﻿// <auto-generated />
using System;
using Cabinet.API.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cabinet.API.Migrations
{
    [DbContext(typeof(CabinetContext))]
    [Migration("20210425184545_RemovedFolder")]
    partial class RemovedFolder
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cabinet.API.Models.Document", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DocumentTypeID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrganizationID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("DocumentTypeID");

                    b.ToTable("Document");
                });

            modelBuilder.Entity("Cabinet.API.Models.DocumentAccess", b =>
                {
                    b.Property<Guid>("DocumentID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("OrganizationID")
                        .HasColumnType("int");

                    b.HasKey("DocumentID", "OrganizationID");

                    b.ToTable("DocumentsAccesses");
                });

            modelBuilder.Entity("Cabinet.API.Models.DocumentType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UniqueName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("DocumentType");
                });

            modelBuilder.Entity("Cabinet.API.Models.OriginalDescription", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DocumentID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Extension")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ForSign")
                        .HasColumnType("bit");

                    b.Property<string>("Hash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Size")
                        .HasColumnType("bigint");

                    b.Property<string>("StoragePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StorageSource")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UploadDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("DocumentID");

                    b.ToTable("OriginalDescription");
                });

            modelBuilder.Entity("Cabinet.API.Models.Document", b =>
                {
                    b.HasOne("Cabinet.API.Models.DocumentType", "DocumentType")
                        .WithMany("Documents")
                        .HasForeignKey("DocumentTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DocumentType");
                });

            modelBuilder.Entity("Cabinet.API.Models.DocumentAccess", b =>
                {
                    b.HasOne("Cabinet.API.Models.Document", "Document")
                        .WithMany("DocumentAccesses")
                        .HasForeignKey("DocumentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Document");
                });

            modelBuilder.Entity("Cabinet.API.Models.OriginalDescription", b =>
                {
                    b.HasOne("Cabinet.API.Models.Document", "Document")
                        .WithMany("Originals")
                        .HasForeignKey("DocumentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Document");
                });

            modelBuilder.Entity("Cabinet.API.Models.Document", b =>
                {
                    b.Navigation("DocumentAccesses");

                    b.Navigation("Originals");
                });

            modelBuilder.Entity("Cabinet.API.Models.DocumentType", b =>
                {
                    b.Navigation("Documents");
                });
#pragma warning restore 612, 618
        }
    }
}
