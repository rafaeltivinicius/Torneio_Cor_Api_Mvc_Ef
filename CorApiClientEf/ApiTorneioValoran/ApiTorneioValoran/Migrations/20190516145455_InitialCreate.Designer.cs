﻿// <auto-generated />
using System;
using ApiTorneioValoran.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ApiTorneioValoran.Migrations
{
    [DbContext(typeof(StoreDataContext))]
    [Migration("20190516145455_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApiTorneioValoran.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Fase");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(1024)")
                        .HasMaxLength(1024);

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("ApiTorneioValoran.Models.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<int>("IdGrupo");

                    b.Property<int>("IdRsultTeamChampion");

                    b.HasKey("Id");

                    b.HasIndex("IdGrupo")
                        .IsUnique();

                    b.HasIndex("IdRsultTeamChampion")
                        .IsUnique();

                    b.ToTable("Matchs");
                });

            modelBuilder.Entity("ApiTorneioValoran.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GroupId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(1024)")
                        .HasMaxLength(1024);

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("ApiTorneioValoran.Models.Match", b =>
                {
                    b.HasOne("ApiTorneioValoran.Models.Group", "Group")
                        .WithOne("Match")
                        .HasForeignKey("ApiTorneioValoran.Models.Match", "IdGrupo")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ApiTorneioValoran.Models.Team", "RsultTeamChampion")
                        .WithOne("Match")
                        .HasForeignKey("ApiTorneioValoran.Models.Match", "IdRsultTeamChampion")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApiTorneioValoran.Models.Team", b =>
                {
                    b.HasOne("ApiTorneioValoran.Models.Group", "Group")
                        .WithMany("Teams")
                        .HasForeignKey("GroupId");
                });
#pragma warning restore 612, 618
        }
    }
}