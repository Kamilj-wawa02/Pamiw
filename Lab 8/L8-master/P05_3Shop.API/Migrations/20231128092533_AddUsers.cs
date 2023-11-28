using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P05_2Library.API.Migrations
{
    /// <inheritdoc />
    public partial class AddUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Freida Simonis", "8", "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 679.119312429856m, new DateTime(2023, 10, 30, 0, 46, 29, 266, DateTimeKind.Local).AddTicks(9622), "Gorgeous Wooden Chair" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Author", "Barcode", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Serenity Botsford", "6", 419.395071499234m, new DateTime(2023, 4, 3, 14, 31, 41, 246, DateTimeKind.Local).AddTicks(7658), "Sleek Wooden Chicken" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Amalia Herman", "7", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 276.019507477535m, new DateTime(2023, 5, 29, 9, 18, 24, 427, DateTimeKind.Local).AddTicks(2956), "Rustic Soft Car" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Zachariah Johns", "7", "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 526.029559857226m, new DateTime(2023, 11, 23, 2, 48, 5, 391, DateTimeKind.Local).AddTicks(9416), "Fantastic Concrete Chicken" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Garrett Braun", "0", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 633.873313080926m, new DateTime(2023, 1, 17, 19, 48, 33, 97, DateTimeKind.Local).AddTicks(4913), "Generic Rubber Chips" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Harold Cruickshank", "0", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 887.110725245024m, new DateTime(2023, 6, 30, 4, 7, 16, 912, DateTimeKind.Local).AddTicks(8321), "Generic Concrete Bike" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Kaylie Wehner", "4", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 212.662704598933m, new DateTime(2023, 1, 15, 19, 20, 18, 756, DateTimeKind.Local).AddTicks(166), "Ergonomic Plastic Computer" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Florence O'Hara", "3", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 476.020144769466m, new DateTime(2023, 5, 2, 21, 46, 10, 220, DateTimeKind.Local).AddTicks(5666), "Licensed Concrete Bike" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Wiley Gulgowski", "1", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 905.322284099796m, new DateTime(2023, 11, 1, 6, 45, 10, 688, DateTimeKind.Local).AddTicks(7426), "Gorgeous Fresh Shirt" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Gabrielle Casper", "7", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 60.7177984624718m, new DateTime(2023, 4, 24, 1, 18, 52, 178, DateTimeKind.Local).AddTicks(400), "Generic Steel Ball" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Author", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Kianna Tromp", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 854.154395135192m, new DateTime(2023, 8, 4, 10, 36, 57, 735, DateTimeKind.Local).AddTicks(3589), "Small Frozen Car" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Roel Crona", "6", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 471.610621951339m, new DateTime(2022, 12, 13, 1, 47, 45, 856, DateTimeKind.Local).AddTicks(5969), "Intelligent Steel Car" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Unique Shanahan", "9", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 415.80337236114m, new DateTime(2023, 11, 13, 15, 53, 30, 203, DateTimeKind.Local).AddTicks(5941), "Fantastic Metal Keyboard" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Virgil Waters", "0", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 14.48730095778m, new DateTime(2023, 9, 25, 16, 31, 50, 656, DateTimeKind.Local).AddTicks(1391), "Generic Wooden Cheese" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Abelardo Hermann", "8", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 16.8119918926675m, new DateTime(2023, 6, 16, 7, 18, 51, 241, DateTimeKind.Local).AddTicks(3278), "Tasty Fresh Cheese" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Imogene Cassin", "0", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 612.278680905364m, new DateTime(2023, 2, 27, 21, 58, 16, 513, DateTimeKind.Local).AddTicks(5141), "Fantastic Cotton Gloves" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Freddy Kuvalis", "5", "The Football Is Good For Training And Recreational Purposes", 878.871765064016m, new DateTime(2022, 11, 29, 21, 33, 23, 666, DateTimeKind.Local).AddTicks(4557), "Unbranded Metal Hat" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Camren Toy", "5", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 940.814879371698m, new DateTime(2023, 5, 4, 12, 50, 57, 507, DateTimeKind.Local).AddTicks(785), "Unbranded Frozen Mouse" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Ally Brekke", "4", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 475.131881632904m, new DateTime(2023, 5, 25, 22, 18, 36, 519, DateTimeKind.Local).AddTicks(2228), "Handcrafted Wooden Sausages" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Alvis Waelchi", "1", "The Football Is Good For Training And Recreational Purposes", 43.6775831215445m, new DateTime(2023, 6, 7, 10, 23, 23, 590, DateTimeKind.Local).AddTicks(5932), "Ergonomic Metal Fish" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Toby Feil", "9", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 122.155600068698m, new DateTime(2023, 5, 7, 6, 38, 24, 39, DateTimeKind.Local).AddTicks(6740), "Incredible Fresh Soap" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Emery Reichert", "8", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 810.480351352356m, new DateTime(2023, 9, 26, 0, 46, 43, 35, DateTimeKind.Local).AddTicks(8788), "Gorgeous Soft Tuna" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Hershel Torphy", "8", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 208.202475922742m, new DateTime(2023, 5, 26, 7, 25, 36, 824, DateTimeKind.Local).AddTicks(405), "Gorgeous Wooden Table" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Flo Paucek", "4", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 430.155933462156m, new DateTime(2023, 6, 6, 16, 51, 36, 996, DateTimeKind.Local).AddTicks(8498), "Small Metal Tuna" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Zion Reichert", "7", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 743.837137221749m, new DateTime(2023, 11, 26, 15, 16, 35, 795, DateTimeKind.Local).AddTicks(1861), "Generic Soft Cheese" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Author", "Barcode", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Judy Hartmann", "0", 635.754752597657m, new DateTime(2022, 12, 25, 0, 50, 44, 859, DateTimeKind.Local).AddTicks(7713), "Ergonomic Rubber Chicken" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Author", "Barcode", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Liana Ferry", "4", 663.536718269594m, new DateTime(2022, 12, 8, 3, 8, 40, 516, DateTimeKind.Local).AddTicks(9238), "Awesome Plastic Chicken" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Author", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Maymie Kuhn", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 289.121948837359m, new DateTime(2023, 10, 7, 21, 22, 17, 984, DateTimeKind.Local).AddTicks(9884), "Handcrafted Concrete Tuna" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Katarina Larson", "8", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 129.940595376278m, new DateTime(2023, 9, 25, 23, 52, 9, 875, DateTimeKind.Local).AddTicks(2311), "Handmade Plastic Bike" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Yasmin Wisozk", "7", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 185.643613699658m, new DateTime(2023, 3, 31, 18, 34, 38, 883, DateTimeKind.Local).AddTicks(4486), "Gorgeous Wooden Pants" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Lempi Moen", "2", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 579.21628712314m, new DateTime(2023, 2, 11, 10, 19, 51, 751, DateTimeKind.Local).AddTicks(8065), "Awesome Granite Hat" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Nikolas Quitzon", "3", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 383.278243241961m, new DateTime(2022, 12, 17, 21, 49, 22, 116, DateTimeKind.Local).AddTicks(5321), "Unbranded Fresh Table" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Raoul Kerluke", "5", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 896.730729824272m, new DateTime(2023, 7, 13, 17, 10, 44, 649, DateTimeKind.Local).AddTicks(9332), "Refined Wooden Computer" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Manuela Torp", "3", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 324.517499184477m, new DateTime(2023, 5, 16, 15, 47, 6, 30, DateTimeKind.Local).AddTicks(4484), "Incredible Cotton Gloves" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Reese Lang", "8", "The Football Is Good For Training And Recreational Purposes", 929.139840084659m, new DateTime(2023, 1, 28, 1, 58, 49, 25, DateTimeKind.Local).AddTicks(4368), "Rustic Fresh Bacon" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "Author", "Barcode", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Kiel Mills", "2", 158.364214679396m, new DateTime(2023, 7, 17, 8, 32, 25, 168, DateTimeKind.Local).AddTicks(5297), "Small Rubber Pants" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "Author", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Laila Harber", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 218.78718086229m, new DateTime(2023, 7, 17, 14, 22, 41, 726, DateTimeKind.Local).AddTicks(6473), "Awesome Soft Fish" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Ramona Willms", "2", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 245.410820124396m, new DateTime(2023, 6, 27, 8, 7, 16, 654, DateTimeKind.Local).AddTicks(2900), "Generic Wooden Sausages" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Ahmad Waelchi", "7", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 628.755980696416m, new DateTime(2022, 12, 11, 2, 6, 23, 608, DateTimeKind.Local).AddTicks(220), "Handmade Steel Salad" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Ottilie Larson", "7", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 890.001594146714m, new DateTime(2023, 7, 25, 14, 37, 15, 934, DateTimeKind.Local).AddTicks(3135), "Licensed Frozen Car" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "Author", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Christiana Hagenes", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 501.19964468535m, new DateTime(2023, 9, 15, 17, 34, 50, 561, DateTimeKind.Local).AddTicks(5450), "Handcrafted Cotton Tuna" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Leanna Swift", "2", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 474.158561197649m, new DateTime(2023, 1, 4, 9, 45, 24, 824, DateTimeKind.Local).AddTicks(2665), "Awesome Granite Fish" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "Author", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Gerard Satterfield", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 309.665064914462m, new DateTime(2023, 9, 19, 11, 6, 36, 530, DateTimeKind.Local).AddTicks(8601), "Handmade Rubber Gloves" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Maybell Orn", "2", "The Football Is Good For Training And Recreational Purposes", 823.62140813592m, new DateTime(2023, 11, 8, 0, 21, 28, 236, DateTimeKind.Local).AddTicks(6783), "Incredible Granite Gloves" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Erwin Koelpin", "6", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 717.609017980569m, new DateTime(2023, 9, 17, 2, 46, 54, 600, DateTimeKind.Local).AddTicks(4993), "Practical Rubber Gloves" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Stewart Harber", "3", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 242.468765747952m, new DateTime(2023, 4, 11, 20, 12, 3, 885, DateTimeKind.Local).AddTicks(1404), "Unbranded Soft Fish" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Skye Metz", "7", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 3.31604853054325m, new DateTime(2023, 1, 18, 0, 30, 11, 367, DateTimeKind.Local).AddTicks(9547), "Rustic Granite Pants" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Malachi Collins", "6", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 306.351716509718m, new DateTime(2023, 10, 21, 17, 21, 38, 575, DateTimeKind.Local).AddTicks(6504), "Awesome Metal Keyboard" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "Author", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Waino Christiansen", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 756.842380142232m, new DateTime(2023, 8, 17, 6, 36, 28, 104, DateTimeKind.Local).AddTicks(601), "Ergonomic Wooden Bacon" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Carroll Daniel", "5", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 533.598870003875m, new DateTime(2023, 3, 6, 3, 1, 2, 136, DateTimeKind.Local).AddTicks(2701), "Rustic Wooden Bacon" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Jeramy Rohan", "4", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 623.194472255976m, new DateTime(2023, 8, 18, 2, 52, 34, 55, DateTimeKind.Local).AddTicks(3022), "Fantastic Rubber Bacon" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Author", "Barcode", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Grayson Kuhn", "1", 7.73332853075381m, new DateTime(2022, 12, 3, 12, 36, 53, 337, DateTimeKind.Local).AddTicks(5847), "Handcrafted Plastic Ball" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Braden Smith", "5", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 955.709538937144m, new DateTime(2023, 7, 30, 15, 48, 9, 457, DateTimeKind.Local).AddTicks(4553), "Gorgeous Soft Chips" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Ara Collins", "9", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 549.316120477835m, new DateTime(2023, 4, 19, 18, 22, 15, 823, DateTimeKind.Local).AddTicks(9194), "Rustic Cotton Sausages" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Lane Kris", "3", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 454.711343110546m, new DateTime(2023, 4, 18, 2, 15, 27, 363, DateTimeKind.Local).AddTicks(6132), "Refined Rubber Salad" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Camila Brakus", "5", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 976.907570571144m, new DateTime(2023, 6, 28, 4, 24, 43, 212, DateTimeKind.Local).AddTicks(9067), "Fantastic Soft Chicken" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Theresia Wiegand", "3", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 688.388556309006m, new DateTime(2022, 11, 18, 21, 46, 17, 74, DateTimeKind.Local).AddTicks(466), "Small Soft Bike" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Fritz Wilderman", "1", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 719.870070907503m, new DateTime(2023, 6, 6, 5, 50, 30, 114, DateTimeKind.Local).AddTicks(5060), "Ergonomic Fresh Sausages" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Guy Lind", "3", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 908.192430632838m, new DateTime(2023, 10, 10, 4, 16, 9, 753, DateTimeKind.Local).AddTicks(5733), "Tasty Wooden Soap" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Solon Wiza", "3", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 757.961488455906m, new DateTime(2023, 2, 21, 15, 51, 50, 125, DateTimeKind.Local).AddTicks(9725), "Practical Soft Keyboard" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Author", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Susan Deckow", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 142.775606268679m, new DateTime(2023, 6, 26, 2, 52, 0, 92, DateTimeKind.Local).AddTicks(2087), "Handmade Cotton Chair" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Morgan Legros", "4", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 215.198147634631m, new DateTime(2023, 1, 15, 10, 11, 49, 955, DateTimeKind.Local).AddTicks(3534), "Awesome Plastic Gloves" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Marc Green", "4", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 365.040097065933m, new DateTime(2023, 7, 4, 23, 25, 20, 980, DateTimeKind.Local).AddTicks(1405), "Gorgeous Granite Gloves" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Hope Ledner", "1", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 455.090221482029m, new DateTime(2023, 8, 16, 8, 26, 13, 417, DateTimeKind.Local).AddTicks(2110), "Awesome Soft Table" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Lessie Rice", "9", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 797.962521155086m, new DateTime(2023, 10, 19, 14, 52, 7, 449, DateTimeKind.Local).AddTicks(881), "Gorgeous Granite Keyboard" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Tyreek Nitzsche", "8", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 396.98708045998m, new DateTime(2023, 10, 9, 23, 45, 37, 139, DateTimeKind.Local).AddTicks(930), "Licensed Plastic Salad" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Roslyn Hirthe", "0", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 665.167680339616m, new DateTime(2023, 5, 10, 6, 5, 38, 313, DateTimeKind.Local).AddTicks(2688), "Sleek Wooden Shirt" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Kaitlyn Ferry", "9", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 840.533164726331m, new DateTime(2023, 5, 5, 5, 15, 33, 819, DateTimeKind.Local).AddTicks(4038), "Rustic Soft Hat" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Bonita Schinner", "5", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 802.534907814746m, new DateTime(2022, 12, 23, 22, 43, 43, 553, DateTimeKind.Local).AddTicks(3942), "Licensed Soft Shirt" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Tyrel Lind", "5", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 765.075126062654m, new DateTime(2023, 8, 9, 22, 33, 3, 805, DateTimeKind.Local).AddTicks(5150), "Unbranded Frozen Fish" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Daphne Gulgowski", "5", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 282.811282221706m, new DateTime(2023, 9, 26, 0, 32, 26, 679, DateTimeKind.Local).AddTicks(5443), "Small Fresh Soap" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Trystan Hackett", "3", "The Football Is Good For Training And Recreational Purposes", 888.649468609283m, new DateTime(2023, 8, 22, 19, 35, 23, 701, DateTimeKind.Local).AddTicks(3301), "Generic Steel Keyboard" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Wendy DuBuque", "0", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 488.220469822891m, new DateTime(2022, 12, 29, 23, 28, 9, 452, DateTimeKind.Local).AddTicks(1448), "Fantastic Fresh Shoes" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Patricia O'Reilly", "0", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 569.450769692497m, new DateTime(2023, 1, 19, 8, 46, 32, 59, DateTimeKind.Local).AddTicks(3651), "Unbranded Fresh Mouse" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Donavon Howe", "3", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 543.899993259356m, new DateTime(2023, 5, 29, 1, 6, 48, 339, DateTimeKind.Local).AddTicks(9958), "Rustic Frozen Gloves" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Author", "Barcode", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Tristian Kunde", "3", 579.55350085461m, new DateTime(2023, 10, 23, 18, 9, 58, 277, DateTimeKind.Local).AddTicks(5852), "Licensed Metal Salad" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Author", "Barcode", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Deshawn Prosacco", "8", 632.067368846005m, new DateTime(2023, 2, 8, 12, 51, 37, 702, DateTimeKind.Local).AddTicks(4839), "Tasty Steel Chips" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Author", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Mariana Ernser", "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 547.047220525215m, new DateTime(2023, 1, 23, 22, 20, 29, 194, DateTimeKind.Local).AddTicks(5782), "Refined Steel Bike" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Rebekah Becker", "9", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 900.997820894014m, new DateTime(2023, 4, 22, 20, 2, 12, 958, DateTimeKind.Local).AddTicks(3084), "Intelligent Rubber Table" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Ruth Jast", "5", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 826.511995187668m, new DateTime(2023, 10, 20, 21, 20, 40, 439, DateTimeKind.Local).AddTicks(3785), "Unbranded Metal Fish" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Waino D'Amore", "8", "The Football Is Good For Training And Recreational Purposes", 978.831964206182m, new DateTime(2023, 5, 11, 5, 48, 13, 697, DateTimeKind.Local).AddTicks(5906), "Tasty Wooden Table" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Mable Jakubowski", "1", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 125.059140629201m, new DateTime(2023, 2, 27, 16, 0, 28, 56, DateTimeKind.Local).AddTicks(2764), "Tasty Soft Chair" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Christopher Orn", "0", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 273.235762937297m, new DateTime(2022, 12, 6, 7, 48, 0, 191, DateTimeKind.Local).AddTicks(4745), "Handcrafted Rubber Shirt" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Aniya Kling", "2", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 336.326750282121m, new DateTime(2023, 9, 18, 22, 9, 29, 479, DateTimeKind.Local).AddTicks(8629), "Handmade Concrete Mouse" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Wallace Rippin", "7", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 122.237311441406m, new DateTime(2023, 10, 2, 2, 53, 15, 130, DateTimeKind.Local).AddTicks(7199), "Ergonomic Plastic Chair" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "Author", "Barcode", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Carley Bruen", "8", 500.189340646013m, new DateTime(2023, 2, 18, 13, 4, 17, 332, DateTimeKind.Local).AddTicks(4586), "Rustic Granite Chair" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "Author", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Hayden Emmerich", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 674.312620116099m, new DateTime(2023, 1, 12, 15, 32, 0, 742, DateTimeKind.Local).AddTicks(7530), "Awesome Metal Chicken" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Pat Bernhard", "9", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 562.843133290168m, new DateTime(2023, 5, 7, 3, 11, 3, 70, DateTimeKind.Local).AddTicks(7413), "Unbranded Plastic Pizza" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Easton Orn", "5", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 27.8777851619072m, new DateTime(2023, 9, 9, 8, 5, 27, 709, DateTimeKind.Local).AddTicks(5061), "Tasty Fresh Gloves" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Carmelo Weber", "2", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 956.498126618644m, new DateTime(2023, 1, 16, 2, 22, 38, 996, DateTimeKind.Local).AddTicks(147), "Awesome Wooden Soap" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "Author", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Cathy Schroeder", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 220.147074059332m, new DateTime(2023, 10, 27, 5, 39, 36, 355, DateTimeKind.Local).AddTicks(7105), "Tasty Wooden Keyboard" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Jacinthe Metz", "6", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 154.149030736779m, new DateTime(2022, 11, 26, 6, 5, 16, 971, DateTimeKind.Local).AddTicks(3801), "Rustic Frozen Chair" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "Author", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Newell Dooley", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 401.095486825941m, new DateTime(2023, 1, 23, 20, 45, 54, 507, DateTimeKind.Local).AddTicks(9235), "Sleek Frozen Mouse" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Lourdes McKenzie", "3", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 827.724565997729m, new DateTime(2023, 1, 13, 20, 45, 29, 859, DateTimeKind.Local).AddTicks(2660), "Rustic Cotton Shirt" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Edgardo Considine", "8", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 382.40657297713m, new DateTime(2023, 4, 24, 0, 9, 10, 436, DateTimeKind.Local).AddTicks(528), "Sleek Cotton Computer" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Mathilde Deckow", "2", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 210.464538701752m, new DateTime(2023, 1, 28, 0, 14, 52, 46, DateTimeKind.Local).AddTicks(1095), "Tasty Granite Keyboard" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Arvilla Hermiston", "9", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 381.489476618558m, new DateTime(2023, 8, 29, 17, 45, 3, 305, DateTimeKind.Local).AddTicks(3239), "Awesome Frozen Chair" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Pat Jacobson", "3", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 782.485941637059m, new DateTime(2023, 1, 20, 2, 2, 28, 107, DateTimeKind.Local).AddTicks(7314), "Unbranded Concrete Bacon" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "Author", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Kyra Watsica", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 776.513499768605m, new DateTime(2023, 1, 15, 17, 39, 49, 52, DateTimeKind.Local).AddTicks(791), "Intelligent Metal Tuna" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[] { "Madge Lubowitz", "8", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 372.063000160198m, new DateTime(2023, 8, 7, 13, 57, 54, 556, DateTimeKind.Local).AddTicks(1110), "Handcrafted Metal Towels" });
        }
    }
}
