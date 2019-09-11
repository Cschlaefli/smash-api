﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmashApi.Models;

namespace SmashApi.Migrations
{
    [DbContext(typeof(CharacterContext))]
    [Migration("20190910182934_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SmashApi.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Name");

                    b.HasKey("Id");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("SmashApi.Models.Move", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Advantage");

                    b.Property<string>("BaseDamage");

                    b.Property<int>("CharacterId");

                    b.Property<string>("LandingLag");

                    b.Property<string>("Name");

                    b.Property<string>("Notes");

                    b.Property<string>("ShieldLag");

                    b.Property<string>("ShieldStun");

                    b.Property<string>("Startup");

                    b.Property<string>("TotalFrames");

                    b.Property<string>("Type");

                    b.Property<string>("WhichHitbox");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("Moves");
                });

            modelBuilder.Entity("SmashApi.Models.Move", b =>
                {
                    b.HasOne("SmashApi.Models.Character")
                        .WithMany("Moves")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
