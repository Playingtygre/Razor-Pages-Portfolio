﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using RazorPage.Data;
using System;

namespace RazorPage.Migrations
{
    [DbContext(typeof(RestaurantDbContext))]
    partial class RestaurantDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RazorPage.Models.Restaurant", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<byte[]>("Image");

                    b.Property<string>("ImageContentType");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("MenuItems");

                    b.Property<string>("Name");

                    b.Property<int>("StarRating");

                    b.HasKey("ID");

                    b.ToTable("Restaurant");
                });
#pragma warning restore 612, 618
        }
    }
}