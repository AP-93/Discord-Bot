﻿// <auto-generated />
using DiscordBotCore.Storage.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DiscordBotCore.Migrations
{
    [DbContext(typeof(SqliteDbContext))]
    [Migration("20190426131957_AddColumnMatchID")]
    partial class AddColumnMatchID
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("DiscordBotCore.Storage.Database.Players", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<ulong>("DiscordId");

                    b.Property<string>("FortniteID");

                    b.Property<string>("FortniteName");

                    b.Property<int>("kills");

                    b.Property<int>("lastMatchId");

                    b.Property<int>("matchesPlayed");

                    b.Property<int>("wins");

                    b.HasKey("ID");

                    b.ToTable("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
