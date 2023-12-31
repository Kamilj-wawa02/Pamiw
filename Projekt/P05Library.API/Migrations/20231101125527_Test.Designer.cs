﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using P05Library.API.Models;

#nullable disable

namespace P05_2Library.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231101125527_Test")]
    partial class Test
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("P06Library.Shared.Library.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(8,2)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Jeramy Rohan",
                            Barcode = "4",
                            Description = "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality",
                            Price = 623.194472255976m,
                            ReleaseDate = new DateTime(2023, 8, 18, 2, 52, 34, 55, DateTimeKind.Local).AddTicks(3022),
                            Title = "Fantastic Rubber Bacon"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Grayson Kuhn",
                            Barcode = "1",
                            Description = "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality",
                            Price = 7.73332853075381m,
                            ReleaseDate = new DateTime(2022, 12, 3, 12, 36, 53, 337, DateTimeKind.Local).AddTicks(5847),
                            Title = "Handcrafted Plastic Ball"
                        },
                        new
                        {
                            Id = 3,
                            Author = "Braden Smith",
                            Barcode = "5",
                            Description = "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive",
                            Price = 955.709538937144m,
                            ReleaseDate = new DateTime(2023, 7, 30, 15, 48, 9, 457, DateTimeKind.Local).AddTicks(4553),
                            Title = "Gorgeous Soft Chips"
                        },
                        new
                        {
                            Id = 4,
                            Author = "Ara Collins",
                            Barcode = "9",
                            Description = "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016",
                            Price = 549.316120477835m,
                            ReleaseDate = new DateTime(2023, 4, 19, 18, 22, 15, 823, DateTimeKind.Local).AddTicks(9194),
                            Title = "Rustic Cotton Sausages"
                        },
                        new
                        {
                            Id = 5,
                            Author = "Lane Kris",
                            Barcode = "3",
                            Description = "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart",
                            Price = 454.711343110546m,
                            ReleaseDate = new DateTime(2023, 4, 18, 2, 15, 27, 363, DateTimeKind.Local).AddTicks(6132),
                            Title = "Refined Rubber Salad"
                        },
                        new
                        {
                            Id = 6,
                            Author = "Camila Brakus",
                            Barcode = "5",
                            Description = "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality",
                            Price = 976.907570571144m,
                            ReleaseDate = new DateTime(2023, 6, 28, 4, 24, 43, 212, DateTimeKind.Local).AddTicks(9067),
                            Title = "Fantastic Soft Chicken"
                        },
                        new
                        {
                            Id = 7,
                            Author = "Theresia Wiegand",
                            Barcode = "3",
                            Description = "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles",
                            Price = 688.388556309006m,
                            ReleaseDate = new DateTime(2022, 11, 18, 21, 46, 17, 74, DateTimeKind.Local).AddTicks(466),
                            Title = "Small Soft Bike"
                        },
                        new
                        {
                            Id = 8,
                            Author = "Fritz Wilderman",
                            Barcode = "1",
                            Description = "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design",
                            Price = 719.870070907503m,
                            ReleaseDate = new DateTime(2023, 6, 6, 5, 50, 30, 114, DateTimeKind.Local).AddTicks(5060),
                            Title = "Ergonomic Fresh Sausages"
                        },
                        new
                        {
                            Id = 9,
                            Author = "Guy Lind",
                            Barcode = "3",
                            Description = "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart",
                            Price = 908.192430632838m,
                            ReleaseDate = new DateTime(2023, 10, 10, 4, 16, 9, 753, DateTimeKind.Local).AddTicks(5733),
                            Title = "Tasty Wooden Soap"
                        },
                        new
                        {
                            Id = 10,
                            Author = "Solon Wiza",
                            Barcode = "3",
                            Description = "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients",
                            Price = 757.961488455906m,
                            ReleaseDate = new DateTime(2023, 2, 21, 15, 51, 50, 125, DateTimeKind.Local).AddTicks(9725),
                            Title = "Practical Soft Keyboard"
                        },
                        new
                        {
                            Id = 11,
                            Author = "Susan Deckow",
                            Barcode = "7",
                            Description = "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality",
                            Price = 142.775606268679m,
                            ReleaseDate = new DateTime(2023, 6, 26, 2, 52, 0, 92, DateTimeKind.Local).AddTicks(2087),
                            Title = "Handmade Cotton Chair"
                        },
                        new
                        {
                            Id = 12,
                            Author = "Morgan Legros",
                            Barcode = "4",
                            Description = "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support",
                            Price = 215.198147634631m,
                            ReleaseDate = new DateTime(2023, 1, 15, 10, 11, 49, 955, DateTimeKind.Local).AddTicks(3534),
                            Title = "Awesome Plastic Gloves"
                        },
                        new
                        {
                            Id = 13,
                            Author = "Marc Green",
                            Barcode = "4",
                            Description = "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design",
                            Price = 365.040097065933m,
                            ReleaseDate = new DateTime(2023, 7, 4, 23, 25, 20, 980, DateTimeKind.Local).AddTicks(1405),
                            Title = "Gorgeous Granite Gloves"
                        },
                        new
                        {
                            Id = 14,
                            Author = "Hope Ledner",
                            Barcode = "1",
                            Description = "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support",
                            Price = 455.090221482029m,
                            ReleaseDate = new DateTime(2023, 8, 16, 8, 26, 13, 417, DateTimeKind.Local).AddTicks(2110),
                            Title = "Awesome Soft Table"
                        },
                        new
                        {
                            Id = 15,
                            Author = "Lessie Rice",
                            Barcode = "9",
                            Description = "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive",
                            Price = 797.962521155086m,
                            ReleaseDate = new DateTime(2023, 10, 19, 14, 52, 7, 449, DateTimeKind.Local).AddTicks(881),
                            Title = "Gorgeous Granite Keyboard"
                        },
                        new
                        {
                            Id = 16,
                            Author = "Tyreek Nitzsche",
                            Barcode = "8",
                            Description = "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals",
                            Price = 396.98708045998m,
                            ReleaseDate = new DateTime(2023, 10, 9, 23, 45, 37, 139, DateTimeKind.Local).AddTicks(930),
                            Title = "Licensed Plastic Salad"
                        },
                        new
                        {
                            Id = 17,
                            Author = "Roslyn Hirthe",
                            Barcode = "0",
                            Description = "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit",
                            Price = 665.167680339616m,
                            ReleaseDate = new DateTime(2023, 5, 10, 6, 5, 38, 313, DateTimeKind.Local).AddTicks(2688),
                            Title = "Sleek Wooden Shirt"
                        },
                        new
                        {
                            Id = 18,
                            Author = "Kaitlyn Ferry",
                            Barcode = "9",
                            Description = "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support",
                            Price = 840.533164726331m,
                            ReleaseDate = new DateTime(2023, 5, 5, 5, 15, 33, 819, DateTimeKind.Local).AddTicks(4038),
                            Title = "Rustic Soft Hat"
                        },
                        new
                        {
                            Id = 19,
                            Author = "Bonita Schinner",
                            Barcode = "5",
                            Description = "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles",
                            Price = 802.534907814746m,
                            ReleaseDate = new DateTime(2022, 12, 23, 22, 43, 43, 553, DateTimeKind.Local).AddTicks(3942),
                            Title = "Licensed Soft Shirt"
                        },
                        new
                        {
                            Id = 20,
                            Author = "Tyrel Lind",
                            Barcode = "5",
                            Description = "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive",
                            Price = 765.075126062654m,
                            ReleaseDate = new DateTime(2023, 8, 9, 22, 33, 3, 805, DateTimeKind.Local).AddTicks(5150),
                            Title = "Unbranded Frozen Fish"
                        },
                        new
                        {
                            Id = 21,
                            Author = "Daphne Gulgowski",
                            Barcode = "5",
                            Description = "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design",
                            Price = 282.811282221706m,
                            ReleaseDate = new DateTime(2023, 9, 26, 0, 32, 26, 679, DateTimeKind.Local).AddTicks(5443),
                            Title = "Small Fresh Soap"
                        },
                        new
                        {
                            Id = 22,
                            Author = "Trystan Hackett",
                            Barcode = "3",
                            Description = "The Football Is Good For Training And Recreational Purposes",
                            Price = 888.649468609283m,
                            ReleaseDate = new DateTime(2023, 8, 22, 19, 35, 23, 701, DateTimeKind.Local).AddTicks(3301),
                            Title = "Generic Steel Keyboard"
                        },
                        new
                        {
                            Id = 23,
                            Author = "Wendy DuBuque",
                            Barcode = "0",
                            Description = "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive",
                            Price = 488.220469822891m,
                            ReleaseDate = new DateTime(2022, 12, 29, 23, 28, 9, 452, DateTimeKind.Local).AddTicks(1448),
                            Title = "Fantastic Fresh Shoes"
                        },
                        new
                        {
                            Id = 24,
                            Author = "Patricia O'Reilly",
                            Barcode = "0",
                            Description = "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016",
                            Price = 569.450769692497m,
                            ReleaseDate = new DateTime(2023, 1, 19, 8, 46, 32, 59, DateTimeKind.Local).AddTicks(3651),
                            Title = "Unbranded Fresh Mouse"
                        },
                        new
                        {
                            Id = 25,
                            Author = "Donavon Howe",
                            Barcode = "3",
                            Description = "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles",
                            Price = 543.899993259356m,
                            ReleaseDate = new DateTime(2023, 5, 29, 1, 6, 48, 339, DateTimeKind.Local).AddTicks(9958),
                            Title = "Rustic Frozen Gloves"
                        },
                        new
                        {
                            Id = 26,
                            Author = "Tristian Kunde",
                            Barcode = "3",
                            Description = "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles",
                            Price = 579.55350085461m,
                            ReleaseDate = new DateTime(2023, 10, 23, 18, 9, 58, 277, DateTimeKind.Local).AddTicks(5852),
                            Title = "Licensed Metal Salad"
                        },
                        new
                        {
                            Id = 27,
                            Author = "Deshawn Prosacco",
                            Barcode = "8",
                            Description = "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016",
                            Price = 632.067368846005m,
                            ReleaseDate = new DateTime(2023, 2, 8, 12, 51, 37, 702, DateTimeKind.Local).AddTicks(4839),
                            Title = "Tasty Steel Chips"
                        },
                        new
                        {
                            Id = 28,
                            Author = "Mariana Ernser",
                            Barcode = "7",
                            Description = "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J",
                            Price = 547.047220525215m,
                            ReleaseDate = new DateTime(2023, 1, 23, 22, 20, 29, 194, DateTimeKind.Local).AddTicks(5782),
                            Title = "Refined Steel Bike"
                        },
                        new
                        {
                            Id = 29,
                            Author = "Rebekah Becker",
                            Barcode = "9",
                            Description = "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016",
                            Price = 900.997820894014m,
                            ReleaseDate = new DateTime(2023, 4, 22, 20, 2, 12, 958, DateTimeKind.Local).AddTicks(3084),
                            Title = "Intelligent Rubber Table"
                        },
                        new
                        {
                            Id = 30,
                            Author = "Ruth Jast",
                            Barcode = "5",
                            Description = "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit",
                            Price = 826.511995187668m,
                            ReleaseDate = new DateTime(2023, 10, 20, 21, 20, 40, 439, DateTimeKind.Local).AddTicks(3785),
                            Title = "Unbranded Metal Fish"
                        },
                        new
                        {
                            Id = 31,
                            Author = "Waino D'Amore",
                            Barcode = "8",
                            Description = "The Football Is Good For Training And Recreational Purposes",
                            Price = 978.831964206182m,
                            ReleaseDate = new DateTime(2023, 5, 11, 5, 48, 13, 697, DateTimeKind.Local).AddTicks(5906),
                            Title = "Tasty Wooden Table"
                        },
                        new
                        {
                            Id = 32,
                            Author = "Mable Jakubowski",
                            Barcode = "1",
                            Description = "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design",
                            Price = 125.059140629201m,
                            ReleaseDate = new DateTime(2023, 2, 27, 16, 0, 28, 56, DateTimeKind.Local).AddTicks(2764),
                            Title = "Tasty Soft Chair"
                        },
                        new
                        {
                            Id = 33,
                            Author = "Christopher Orn",
                            Barcode = "0",
                            Description = "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality",
                            Price = 273.235762937297m,
                            ReleaseDate = new DateTime(2022, 12, 6, 7, 48, 0, 191, DateTimeKind.Local).AddTicks(4745),
                            Title = "Handcrafted Rubber Shirt"
                        },
                        new
                        {
                            Id = 34,
                            Author = "Aniya Kling",
                            Barcode = "2",
                            Description = "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support",
                            Price = 336.326750282121m,
                            ReleaseDate = new DateTime(2023, 9, 18, 22, 9, 29, 479, DateTimeKind.Local).AddTicks(8629),
                            Title = "Handmade Concrete Mouse"
                        },
                        new
                        {
                            Id = 35,
                            Author = "Wallace Rippin",
                            Barcode = "7",
                            Description = "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients",
                            Price = 122.237311441406m,
                            ReleaseDate = new DateTime(2023, 10, 2, 2, 53, 15, 130, DateTimeKind.Local).AddTicks(7199),
                            Title = "Ergonomic Plastic Chair"
                        },
                        new
                        {
                            Id = 36,
                            Author = "Carley Bruen",
                            Barcode = "8",
                            Description = "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive",
                            Price = 500.189340646013m,
                            ReleaseDate = new DateTime(2023, 2, 18, 13, 4, 17, 332, DateTimeKind.Local).AddTicks(4586),
                            Title = "Rustic Granite Chair"
                        },
                        new
                        {
                            Id = 37,
                            Author = "Hayden Emmerich",
                            Barcode = "2",
                            Description = "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles",
                            Price = 674.312620116099m,
                            ReleaseDate = new DateTime(2023, 1, 12, 15, 32, 0, 742, DateTimeKind.Local).AddTicks(7530),
                            Title = "Awesome Metal Chicken"
                        },
                        new
                        {
                            Id = 38,
                            Author = "Pat Bernhard",
                            Barcode = "9",
                            Description = "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals",
                            Price = 562.843133290168m,
                            ReleaseDate = new DateTime(2023, 5, 7, 3, 11, 3, 70, DateTimeKind.Local).AddTicks(7413),
                            Title = "Unbranded Plastic Pizza"
                        },
                        new
                        {
                            Id = 39,
                            Author = "Easton Orn",
                            Barcode = "5",
                            Description = "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles",
                            Price = 27.8777851619072m,
                            ReleaseDate = new DateTime(2023, 9, 9, 8, 5, 27, 709, DateTimeKind.Local).AddTicks(5061),
                            Title = "Tasty Fresh Gloves"
                        },
                        new
                        {
                            Id = 40,
                            Author = "Carmelo Weber",
                            Barcode = "2",
                            Description = "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design",
                            Price = 956.498126618644m,
                            ReleaseDate = new DateTime(2023, 1, 16, 2, 22, 38, 996, DateTimeKind.Local).AddTicks(147),
                            Title = "Awesome Wooden Soap"
                        },
                        new
                        {
                            Id = 41,
                            Author = "Cathy Schroeder",
                            Barcode = "7",
                            Description = "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016",
                            Price = 220.147074059332m,
                            ReleaseDate = new DateTime(2023, 10, 27, 5, 39, 36, 355, DateTimeKind.Local).AddTicks(7105),
                            Title = "Tasty Wooden Keyboard"
                        },
                        new
                        {
                            Id = 42,
                            Author = "Jacinthe Metz",
                            Barcode = "6",
                            Description = "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients",
                            Price = 154.149030736779m,
                            ReleaseDate = new DateTime(2022, 11, 26, 6, 5, 16, 971, DateTimeKind.Local).AddTicks(3801),
                            Title = "Rustic Frozen Chair"
                        },
                        new
                        {
                            Id = 43,
                            Author = "Newell Dooley",
                            Barcode = "1",
                            Description = "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016",
                            Price = 401.095486825941m,
                            ReleaseDate = new DateTime(2023, 1, 23, 20, 45, 54, 507, DateTimeKind.Local).AddTicks(9235),
                            Title = "Sleek Frozen Mouse"
                        },
                        new
                        {
                            Id = 44,
                            Author = "Lourdes McKenzie",
                            Barcode = "3",
                            Description = "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals",
                            Price = 827.724565997729m,
                            ReleaseDate = new DateTime(2023, 1, 13, 20, 45, 29, 859, DateTimeKind.Local).AddTicks(2660),
                            Title = "Rustic Cotton Shirt"
                        },
                        new
                        {
                            Id = 45,
                            Author = "Edgardo Considine",
                            Barcode = "8",
                            Description = "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals",
                            Price = 382.40657297713m,
                            ReleaseDate = new DateTime(2023, 4, 24, 0, 9, 10, 436, DateTimeKind.Local).AddTicks(528),
                            Title = "Sleek Cotton Computer"
                        },
                        new
                        {
                            Id = 46,
                            Author = "Mathilde Deckow",
                            Barcode = "2",
                            Description = "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design",
                            Price = 210.464538701752m,
                            ReleaseDate = new DateTime(2023, 1, 28, 0, 14, 52, 46, DateTimeKind.Local).AddTicks(1095),
                            Title = "Tasty Granite Keyboard"
                        },
                        new
                        {
                            Id = 47,
                            Author = "Arvilla Hermiston",
                            Barcode = "9",
                            Description = "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design",
                            Price = 381.489476618558m,
                            ReleaseDate = new DateTime(2023, 8, 29, 17, 45, 3, 305, DateTimeKind.Local).AddTicks(3239),
                            Title = "Awesome Frozen Chair"
                        },
                        new
                        {
                            Id = 48,
                            Author = "Pat Jacobson",
                            Barcode = "3",
                            Description = "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design",
                            Price = 782.485941637059m,
                            ReleaseDate = new DateTime(2023, 1, 20, 2, 2, 28, 107, DateTimeKind.Local).AddTicks(7314),
                            Title = "Unbranded Concrete Bacon"
                        },
                        new
                        {
                            Id = 49,
                            Author = "Kyra Watsica",
                            Barcode = "6",
                            Description = "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles",
                            Price = 776.513499768605m,
                            ReleaseDate = new DateTime(2023, 1, 15, 17, 39, 49, 52, DateTimeKind.Local).AddTicks(791),
                            Title = "Intelligent Metal Tuna"
                        },
                        new
                        {
                            Id = 50,
                            Author = "Madge Lubowitz",
                            Barcode = "8",
                            Description = "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles",
                            Price = 372.063000160198m,
                            ReleaseDate = new DateTime(2023, 8, 7, 13, 57, 54, 556, DateTimeKind.Local).AddTicks(1110),
                            Title = "Handcrafted Metal Towels"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
