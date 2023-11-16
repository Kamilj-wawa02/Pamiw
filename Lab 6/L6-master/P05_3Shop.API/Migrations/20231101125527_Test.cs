using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace P05_2Library.API.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, "Jeramy Rohan", "4", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 623.194472255976m, new DateTime(2023, 8, 18, 2, 52, 34, 55, DateTimeKind.Local).AddTicks(3022), "Fantastic Rubber Bacon" },
                    { 2, "Grayson Kuhn", "1", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 7.73332853075381m, new DateTime(2022, 12, 3, 12, 36, 53, 337, DateTimeKind.Local).AddTicks(5847), "Handcrafted Plastic Ball" },
                    { 3, "Braden Smith", "5", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 955.709538937144m, new DateTime(2023, 7, 30, 15, 48, 9, 457, DateTimeKind.Local).AddTicks(4553), "Gorgeous Soft Chips" },
                    { 4, "Ara Collins", "9", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 549.316120477835m, new DateTime(2023, 4, 19, 18, 22, 15, 823, DateTimeKind.Local).AddTicks(9194), "Rustic Cotton Sausages" },
                    { 5, "Lane Kris", "3", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 454.711343110546m, new DateTime(2023, 4, 18, 2, 15, 27, 363, DateTimeKind.Local).AddTicks(6132), "Refined Rubber Salad" },
                    { 6, "Camila Brakus", "5", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 976.907570571144m, new DateTime(2023, 6, 28, 4, 24, 43, 212, DateTimeKind.Local).AddTicks(9067), "Fantastic Soft Chicken" },
                    { 7, "Theresia Wiegand", "3", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 688.388556309006m, new DateTime(2022, 11, 18, 21, 46, 17, 74, DateTimeKind.Local).AddTicks(466), "Small Soft Bike" },
                    { 8, "Fritz Wilderman", "1", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 719.870070907503m, new DateTime(2023, 6, 6, 5, 50, 30, 114, DateTimeKind.Local).AddTicks(5060), "Ergonomic Fresh Sausages" },
                    { 9, "Guy Lind", "3", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 908.192430632838m, new DateTime(2023, 10, 10, 4, 16, 9, 753, DateTimeKind.Local).AddTicks(5733), "Tasty Wooden Soap" },
                    { 10, "Solon Wiza", "3", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 757.961488455906m, new DateTime(2023, 2, 21, 15, 51, 50, 125, DateTimeKind.Local).AddTicks(9725), "Practical Soft Keyboard" },
                    { 11, "Susan Deckow", "7", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 142.775606268679m, new DateTime(2023, 6, 26, 2, 52, 0, 92, DateTimeKind.Local).AddTicks(2087), "Handmade Cotton Chair" },
                    { 12, "Morgan Legros", "4", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 215.198147634631m, new DateTime(2023, 1, 15, 10, 11, 49, 955, DateTimeKind.Local).AddTicks(3534), "Awesome Plastic Gloves" },
                    { 13, "Marc Green", "4", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 365.040097065933m, new DateTime(2023, 7, 4, 23, 25, 20, 980, DateTimeKind.Local).AddTicks(1405), "Gorgeous Granite Gloves" },
                    { 14, "Hope Ledner", "1", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 455.090221482029m, new DateTime(2023, 8, 16, 8, 26, 13, 417, DateTimeKind.Local).AddTicks(2110), "Awesome Soft Table" },
                    { 15, "Lessie Rice", "9", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 797.962521155086m, new DateTime(2023, 10, 19, 14, 52, 7, 449, DateTimeKind.Local).AddTicks(881), "Gorgeous Granite Keyboard" },
                    { 16, "Tyreek Nitzsche", "8", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 396.98708045998m, new DateTime(2023, 10, 9, 23, 45, 37, 139, DateTimeKind.Local).AddTicks(930), "Licensed Plastic Salad" },
                    { 17, "Roslyn Hirthe", "0", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 665.167680339616m, new DateTime(2023, 5, 10, 6, 5, 38, 313, DateTimeKind.Local).AddTicks(2688), "Sleek Wooden Shirt" },
                    { 18, "Kaitlyn Ferry", "9", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 840.533164726331m, new DateTime(2023, 5, 5, 5, 15, 33, 819, DateTimeKind.Local).AddTicks(4038), "Rustic Soft Hat" },
                    { 19, "Bonita Schinner", "5", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 802.534907814746m, new DateTime(2022, 12, 23, 22, 43, 43, 553, DateTimeKind.Local).AddTicks(3942), "Licensed Soft Shirt" },
                    { 20, "Tyrel Lind", "5", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 765.075126062654m, new DateTime(2023, 8, 9, 22, 33, 3, 805, DateTimeKind.Local).AddTicks(5150), "Unbranded Frozen Fish" },
                    { 21, "Daphne Gulgowski", "5", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 282.811282221706m, new DateTime(2023, 9, 26, 0, 32, 26, 679, DateTimeKind.Local).AddTicks(5443), "Small Fresh Soap" },
                    { 22, "Trystan Hackett", "3", "The Football Is Good For Training And Recreational Purposes", 888.649468609283m, new DateTime(2023, 8, 22, 19, 35, 23, 701, DateTimeKind.Local).AddTicks(3301), "Generic Steel Keyboard" },
                    { 23, "Wendy DuBuque", "0", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 488.220469822891m, new DateTime(2022, 12, 29, 23, 28, 9, 452, DateTimeKind.Local).AddTicks(1448), "Fantastic Fresh Shoes" },
                    { 24, "Patricia O'Reilly", "0", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 569.450769692497m, new DateTime(2023, 1, 19, 8, 46, 32, 59, DateTimeKind.Local).AddTicks(3651), "Unbranded Fresh Mouse" },
                    { 25, "Donavon Howe", "3", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 543.899993259356m, new DateTime(2023, 5, 29, 1, 6, 48, 339, DateTimeKind.Local).AddTicks(9958), "Rustic Frozen Gloves" },
                    { 26, "Tristian Kunde", "3", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 579.55350085461m, new DateTime(2023, 10, 23, 18, 9, 58, 277, DateTimeKind.Local).AddTicks(5852), "Licensed Metal Salad" },
                    { 27, "Deshawn Prosacco", "8", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 632.067368846005m, new DateTime(2023, 2, 8, 12, 51, 37, 702, DateTimeKind.Local).AddTicks(4839), "Tasty Steel Chips" },
                    { 28, "Mariana Ernser", "7", "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 547.047220525215m, new DateTime(2023, 1, 23, 22, 20, 29, 194, DateTimeKind.Local).AddTicks(5782), "Refined Steel Bike" },
                    { 29, "Rebekah Becker", "9", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 900.997820894014m, new DateTime(2023, 4, 22, 20, 2, 12, 958, DateTimeKind.Local).AddTicks(3084), "Intelligent Rubber Table" },
                    { 30, "Ruth Jast", "5", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 826.511995187668m, new DateTime(2023, 10, 20, 21, 20, 40, 439, DateTimeKind.Local).AddTicks(3785), "Unbranded Metal Fish" },
                    { 31, "Waino D'Amore", "8", "The Football Is Good For Training And Recreational Purposes", 978.831964206182m, new DateTime(2023, 5, 11, 5, 48, 13, 697, DateTimeKind.Local).AddTicks(5906), "Tasty Wooden Table" },
                    { 32, "Mable Jakubowski", "1", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 125.059140629201m, new DateTime(2023, 2, 27, 16, 0, 28, 56, DateTimeKind.Local).AddTicks(2764), "Tasty Soft Chair" },
                    { 33, "Christopher Orn", "0", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 273.235762937297m, new DateTime(2022, 12, 6, 7, 48, 0, 191, DateTimeKind.Local).AddTicks(4745), "Handcrafted Rubber Shirt" },
                    { 34, "Aniya Kling", "2", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 336.326750282121m, new DateTime(2023, 9, 18, 22, 9, 29, 479, DateTimeKind.Local).AddTicks(8629), "Handmade Concrete Mouse" },
                    { 35, "Wallace Rippin", "7", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 122.237311441406m, new DateTime(2023, 10, 2, 2, 53, 15, 130, DateTimeKind.Local).AddTicks(7199), "Ergonomic Plastic Chair" },
                    { 36, "Carley Bruen", "8", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 500.189340646013m, new DateTime(2023, 2, 18, 13, 4, 17, 332, DateTimeKind.Local).AddTicks(4586), "Rustic Granite Chair" },
                    { 37, "Hayden Emmerich", "2", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 674.312620116099m, new DateTime(2023, 1, 12, 15, 32, 0, 742, DateTimeKind.Local).AddTicks(7530), "Awesome Metal Chicken" },
                    { 38, "Pat Bernhard", "9", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 562.843133290168m, new DateTime(2023, 5, 7, 3, 11, 3, 70, DateTimeKind.Local).AddTicks(7413), "Unbranded Plastic Pizza" },
                    { 39, "Easton Orn", "5", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 27.8777851619072m, new DateTime(2023, 9, 9, 8, 5, 27, 709, DateTimeKind.Local).AddTicks(5061), "Tasty Fresh Gloves" },
                    { 40, "Carmelo Weber", "2", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 956.498126618644m, new DateTime(2023, 1, 16, 2, 22, 38, 996, DateTimeKind.Local).AddTicks(147), "Awesome Wooden Soap" },
                    { 41, "Cathy Schroeder", "7", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 220.147074059332m, new DateTime(2023, 10, 27, 5, 39, 36, 355, DateTimeKind.Local).AddTicks(7105), "Tasty Wooden Keyboard" },
                    { 42, "Jacinthe Metz", "6", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 154.149030736779m, new DateTime(2022, 11, 26, 6, 5, 16, 971, DateTimeKind.Local).AddTicks(3801), "Rustic Frozen Chair" },
                    { 43, "Newell Dooley", "1", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 401.095486825941m, new DateTime(2023, 1, 23, 20, 45, 54, 507, DateTimeKind.Local).AddTicks(9235), "Sleek Frozen Mouse" },
                    { 44, "Lourdes McKenzie", "3", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 827.724565997729m, new DateTime(2023, 1, 13, 20, 45, 29, 859, DateTimeKind.Local).AddTicks(2660), "Rustic Cotton Shirt" },
                    { 45, "Edgardo Considine", "8", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 382.40657297713m, new DateTime(2023, 4, 24, 0, 9, 10, 436, DateTimeKind.Local).AddTicks(528), "Sleek Cotton Computer" },
                    { 46, "Mathilde Deckow", "2", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 210.464538701752m, new DateTime(2023, 1, 28, 0, 14, 52, 46, DateTimeKind.Local).AddTicks(1095), "Tasty Granite Keyboard" },
                    { 47, "Arvilla Hermiston", "9", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 381.489476618558m, new DateTime(2023, 8, 29, 17, 45, 3, 305, DateTimeKind.Local).AddTicks(3239), "Awesome Frozen Chair" },
                    { 48, "Pat Jacobson", "3", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 782.485941637059m, new DateTime(2023, 1, 20, 2, 2, 28, 107, DateTimeKind.Local).AddTicks(7314), "Unbranded Concrete Bacon" },
                    { 49, "Kyra Watsica", "6", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 776.513499768605m, new DateTime(2023, 1, 15, 17, 39, 49, 52, DateTimeKind.Local).AddTicks(791), "Intelligent Metal Tuna" },
                    { 50, "Madge Lubowitz", "8", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 372.063000160198m, new DateTime(2023, 8, 7, 13, 57, 54, 556, DateTimeKind.Local).AddTicks(1110), "Handcrafted Metal Towels" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
