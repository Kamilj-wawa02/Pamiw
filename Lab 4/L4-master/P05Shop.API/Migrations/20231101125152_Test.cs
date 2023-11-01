using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace P05Shop.API.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, "3", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 712.021981759007m, new DateTime(2023, 3, 15, 19, 11, 52, 663, DateTimeKind.Local).AddTicks(8617), "Gorgeous Wooden Chair" },
                    { 2, "7", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 839.010165513032m, new DateTime(2023, 9, 25, 15, 50, 26, 300, DateTimeKind.Local).AddTicks(1061), "Handcrafted Steel Shoes" },
                    { 3, "1", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 198.083692779804m, new DateTime(2023, 1, 14, 10, 44, 9, 573, DateTimeKind.Local).AddTicks(3088), "Handmade Granite Table" },
                    { 4, "1", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 160.643399712929m, new DateTime(2023, 8, 15, 22, 57, 39, 932, DateTimeKind.Local).AddTicks(4537), "Handmade Wooden Table" },
                    { 5, "0", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 359.887736376788m, new DateTime(2023, 2, 16, 0, 15, 51, 662, DateTimeKind.Local).AddTicks(730), "Intelligent Steel Salad" },
                    { 6, "8", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 181.360829243139m, new DateTime(2023, 8, 30, 12, 3, 24, 771, DateTimeKind.Local).AddTicks(8020), "Handcrafted Rubber Bike" },
                    { 7, "1", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 938.297015022625m, new DateTime(2023, 3, 31, 11, 15, 37, 181, DateTimeKind.Local).AddTicks(8082), "Unbranded Steel Car" },
                    { 8, "3", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 223.882037785315m, new DateTime(2023, 6, 24, 2, 30, 4, 870, DateTimeKind.Local).AddTicks(316), "Tasty Plastic Cheese" },
                    { 9, "0", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 249.172251003875m, new DateTime(2022, 12, 13, 18, 29, 20, 326, DateTimeKind.Local).AddTicks(7797), "Handcrafted Fresh Sausages" },
                    { 10, "1", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 905.322284099796m, new DateTime(2023, 10, 5, 10, 11, 29, 788, DateTimeKind.Local).AddTicks(498), "Fantastic Frozen Gloves" },
                    { 11, "3", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 842.480734222792m, new DateTime(2023, 8, 4, 3, 25, 33, 929, DateTimeKind.Local).AddTicks(7674), "Generic Steel Ball" },
                    { 12, "1", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 928.928430071533m, new DateTime(2023, 8, 12, 7, 57, 30, 703, DateTimeKind.Local).AddTicks(6388), "Ergonomic Rubber Car" },
                    { 13, "6", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 706.948686653259m, new DateTime(2023, 7, 12, 13, 10, 59, 623, DateTimeKind.Local).AddTicks(2374), "Generic Steel Pizza" },
                    { 14, "3", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 306.262494314584m, new DateTime(2023, 1, 6, 2, 23, 38, 110, DateTimeKind.Local).AddTicks(8693), "Small Metal Sausages" },
                    { 15, "2", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 378.222576259273m, new DateTime(2023, 7, 27, 19, 29, 31, 140, DateTimeKind.Local).AddTicks(5849), "Fantastic Soft Pants" },
                    { 16, "6", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 461.718092748764m, new DateTime(2022, 11, 14, 11, 24, 19, 607, DateTimeKind.Local).AddTicks(4711), "Gorgeous Frozen Towels" },
                    { 17, "7", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 126.128098112125m, new DateTime(2023, 6, 24, 1, 45, 51, 185, DateTimeKind.Local).AddTicks(4317), "Tasty Steel Cheese" },
                    { 18, "8", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 530.970371435383m, new DateTime(2023, 6, 21, 3, 28, 32, 544, DateTimeKind.Local).AddTicks(7385), "Gorgeous Granite Cheese" },
                    { 19, "9", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 913.003066283186m, new DateTime(2022, 11, 14, 14, 46, 32, 124, DateTimeKind.Local).AddTicks(742), "Sleek Rubber Chicken" },
                    { 20, "5", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 940.814879371698m, new DateTime(2023, 4, 7, 16, 17, 16, 606, DateTimeKind.Local).AddTicks(3994), "Intelligent Wooden Salad" },
                    { 21, "4", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 479.41424090062m, new DateTime(2023, 6, 16, 3, 40, 10, 794, DateTimeKind.Local).AddTicks(6381), "Handcrafted Wooden Sausages" },
                    { 22, "7", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 320.499838554068m, new DateTime(2023, 1, 26, 23, 7, 33, 64, DateTimeKind.Local).AddTicks(4109), "Sleek Granite Car" },
                    { 23, "6", "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 478.915239043029m, new DateTime(2023, 5, 28, 16, 57, 40, 382, DateTimeKind.Local).AddTicks(7683), "Small Wooden Car" },
                    { 24, "2", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 910.785444308438m, new DateTime(2023, 6, 29, 9, 33, 59, 612, DateTimeKind.Local).AddTicks(906), "Sleek Steel Shirt" },
                    { 25, "3", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 802.238750720974m, new DateTime(2023, 7, 15, 11, 2, 51, 175, DateTimeKind.Local).AddTicks(7368), "Incredible Frozen Mouse" },
                    { 26, "7", "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 150.818741621831m, new DateTime(2023, 5, 10, 4, 39, 11, 299, DateTimeKind.Local).AddTicks(2643), "Incredible Wooden Chair" },
                    { 27, "5", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 721.773541800572m, new DateTime(2023, 1, 29, 16, 42, 47, 295, DateTimeKind.Local).AddTicks(4225), "Gorgeous Plastic Chips" },
                    { 28, "5", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 688.245783060904m, new DateTime(2023, 4, 23, 19, 8, 42, 406, DateTimeKind.Local).AddTicks(9458), "Incredible Fresh Bacon" },
                    { 29, "7", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 553.558320945389m, new DateTime(2023, 7, 17, 5, 39, 36, 400, DateTimeKind.Local).AddTicks(774), "Incredible Soft Computer" },
                    { 30, "4", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 663.536718269594m, new DateTime(2022, 11, 11, 6, 34, 59, 616, DateTimeKind.Local).AddTicks(2609), "Handcrafted Rubber Bike" },
                    { 31, "2", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 922.479030014704m, new DateTime(2023, 10, 7, 5, 0, 48, 813, DateTimeKind.Local).AddTicks(778), "Handcrafted Concrete Tuna" },
                    { 32, "3", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 255.49067058018m, new DateTime(2023, 7, 18, 0, 48, 14, 752, DateTimeKind.Local).AddTicks(1221), "Gorgeous Wooden Fish" },
                    { 33, "7", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 955.272407213818m, new DateTime(2023, 4, 25, 1, 17, 16, 2, DateTimeKind.Local).AddTicks(7116), "Handcrafted Frozen Keyboard" },
                    { 34, "8", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 151.982358236323m, new DateTime(2022, 11, 21, 18, 33, 3, 841, DateTimeKind.Local).AddTicks(4723), "Intelligent Plastic Chair" },
                    { 35, "9", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 434.299358334532m, new DateTime(2022, 12, 9, 23, 25, 21, 836, DateTimeKind.Local).AddTicks(4410), "Unbranded Wooden Pizza" },
                    { 36, "4", "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 57.7988712865854m, new DateTime(2022, 12, 29, 17, 59, 19, 369, DateTimeKind.Local).AddTicks(6218), "Gorgeous Rubber Bacon" },
                    { 37, "7", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 883.980300599234m, new DateTime(2023, 3, 27, 9, 32, 32, 765, DateTimeKind.Local).AddTicks(4426), "Handcrafted Rubber Shirt" },
                    { 38, "7", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 822.452619476455m, new DateTime(2023, 1, 6, 7, 34, 13, 84, DateTimeKind.Local).AddTicks(5815), "Rustic Granite Shoes" },
                    { 39, "7", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 22.2432652671092m, new DateTime(2023, 4, 2, 15, 12, 27, 644, DateTimeKind.Local).AddTicks(976), "Sleek Granite Chair" },
                    { 40, "2", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 158.364214679396m, new DateTime(2023, 6, 20, 11, 58, 44, 267, DateTimeKind.Local).AddTicks(8755), "Incredible Rubber Soap" },
                    { 41, "7", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 533.504530191656m, new DateTime(2023, 8, 2, 19, 4, 6, 416, DateTimeKind.Local).AddTicks(815), "Awesome Soft Fish" },
                    { 42, "8", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 265.709933652407m, new DateTime(2023, 7, 25, 6, 15, 5, 845, DateTimeKind.Local).AddTicks(6138), "Intelligent Cotton Tuna" },
                    { 43, "2", "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 294.402654204239m, new DateTime(2023, 1, 16, 22, 1, 19, 401, DateTimeKind.Local).AddTicks(5128), "Refined Soft Bike" },
                    { 44, "5", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 741.648888164036m, new DateTime(2023, 1, 20, 19, 41, 44, 560, DateTimeKind.Local).AddTicks(2808), "Handmade Cotton Bacon" },
                    { 45, "5", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 825.239833488706m, new DateTime(2022, 12, 29, 15, 48, 7, 630, DateTimeKind.Local).AddTicks(4340), "Small Soft Tuna" },
                    { 46, "1", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 305.894089151124m, new DateTime(2023, 5, 3, 20, 30, 19, 189, DateTimeKind.Local).AddTicks(7863), "Practical Frozen Computer" },
                    { 47, "4", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 778.911179241683m, new DateTime(2023, 1, 6, 15, 29, 53, 492, DateTimeKind.Local).AddTicks(1015), "Rustic Wooden Mouse" },
                    { 48, "2", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 318.709401070936m, new DateTime(2023, 2, 18, 12, 22, 10, 918, DateTimeKind.Local).AddTicks(663), "Handcrafted Metal Mouse" },
                    { 49, "6", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 463.195345650052m, new DateTime(2023, 4, 3, 17, 4, 14, 519, DateTimeKind.Local).AddTicks(9883), "Handcrafted Rubber Salad" },
                    { 50, "6", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 717.609017980569m, new DateTime(2023, 8, 21, 6, 13, 13, 699, DateTimeKind.Local).AddTicks(8611), "Incredible Plastic Shoes" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
