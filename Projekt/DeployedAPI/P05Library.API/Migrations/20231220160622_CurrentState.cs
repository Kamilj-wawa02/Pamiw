using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P05_2Library.API.Migrations
{
    /// <inheritdoc />
    public partial class CurrentState : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateTime(2023, 11, 21, 7, 27, 17, 435, DateTimeKind.Local).AddTicks(4277));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "ReleaseDate",
                value: new DateTime(2023, 4, 25, 21, 12, 29, 415, DateTimeKind.Local).AddTicks(1788));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "ReleaseDate",
                value: new DateTime(2023, 6, 20, 15, 59, 12, 595, DateTimeKind.Local).AddTicks(7050));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                column: "ReleaseDate",
                value: new DateTime(2023, 12, 15, 9, 28, 53, 560, DateTimeKind.Local).AddTicks(3418));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                column: "ReleaseDate",
                value: new DateTime(2023, 2, 9, 2, 29, 21, 265, DateTimeKind.Local).AddTicks(8894));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                column: "ReleaseDate",
                value: new DateTime(2023, 7, 22, 10, 48, 5, 81, DateTimeKind.Local).AddTicks(2307));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                column: "ReleaseDate",
                value: new DateTime(2023, 2, 7, 2, 1, 6, 924, DateTimeKind.Local).AddTicks(4139));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                column: "ReleaseDate",
                value: new DateTime(2023, 5, 25, 4, 26, 58, 388, DateTimeKind.Local).AddTicks(9623));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9,
                column: "ReleaseDate",
                value: new DateTime(2023, 11, 23, 13, 25, 58, 857, DateTimeKind.Local).AddTicks(1367));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10,
                column: "ReleaseDate",
                value: new DateTime(2023, 5, 16, 7, 59, 40, 346, DateTimeKind.Local).AddTicks(4276));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11,
                column: "ReleaseDate",
                value: new DateTime(2023, 8, 26, 17, 17, 45, 903, DateTimeKind.Local).AddTicks(7445));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12,
                column: "ReleaseDate",
                value: new DateTime(2023, 1, 4, 8, 28, 34, 24, DateTimeKind.Local).AddTicks(9829));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13,
                column: "ReleaseDate",
                value: new DateTime(2023, 12, 5, 22, 34, 18, 371, DateTimeKind.Local).AddTicks(9785));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14,
                column: "ReleaseDate",
                value: new DateTime(2023, 10, 17, 23, 12, 38, 824, DateTimeKind.Local).AddTicks(5219));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15,
                column: "ReleaseDate",
                value: new DateTime(2023, 7, 8, 13, 59, 39, 409, DateTimeKind.Local).AddTicks(7066));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 16,
                column: "ReleaseDate",
                value: new DateTime(2023, 3, 22, 4, 39, 4, 681, DateTimeKind.Local).AddTicks(8907));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 17,
                column: "ReleaseDate",
                value: new DateTime(2022, 12, 22, 4, 14, 11, 834, DateTimeKind.Local).AddTicks(8303));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 18,
                column: "ReleaseDate",
                value: new DateTime(2023, 5, 26, 19, 31, 45, 675, DateTimeKind.Local).AddTicks(4533));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 19,
                column: "ReleaseDate",
                value: new DateTime(2023, 6, 17, 4, 59, 24, 687, DateTimeKind.Local).AddTicks(5959));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 20,
                column: "ReleaseDate",
                value: new DateTime(2023, 6, 29, 17, 4, 11, 758, DateTimeKind.Local).AddTicks(9646));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 21,
                column: "ReleaseDate",
                value: new DateTime(2023, 5, 29, 13, 19, 12, 208, DateTimeKind.Local).AddTicks(438));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 22,
                column: "ReleaseDate",
                value: new DateTime(2023, 10, 18, 7, 27, 31, 204, DateTimeKind.Local).AddTicks(2443));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 23,
                column: "ReleaseDate",
                value: new DateTime(2023, 6, 17, 14, 6, 24, 992, DateTimeKind.Local).AddTicks(4045));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 24,
                column: "ReleaseDate",
                value: new DateTime(2023, 6, 28, 23, 32, 25, 165, DateTimeKind.Local).AddTicks(2141));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 25,
                column: "ReleaseDate",
                value: new DateTime(2023, 12, 18, 21, 57, 23, 963, DateTimeKind.Local).AddTicks(5487));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 26,
                column: "ReleaseDate",
                value: new DateTime(2023, 1, 16, 7, 31, 33, 28, DateTimeKind.Local).AddTicks(1325));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 27,
                column: "ReleaseDate",
                value: new DateTime(2022, 12, 30, 9, 49, 28, 685, DateTimeKind.Local).AddTicks(2832));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 28,
                column: "ReleaseDate",
                value: new DateTime(2023, 10, 30, 4, 3, 6, 153, DateTimeKind.Local).AddTicks(3428));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 29,
                column: "ReleaseDate",
                value: new DateTime(2023, 10, 18, 6, 32, 58, 43, DateTimeKind.Local).AddTicks(5835));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 30,
                column: "ReleaseDate",
                value: new DateTime(2023, 4, 23, 1, 15, 27, 51, DateTimeKind.Local).AddTicks(8025));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 31,
                column: "ReleaseDate",
                value: new DateTime(2023, 3, 5, 17, 0, 39, 920, DateTimeKind.Local).AddTicks(1588));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 32,
                column: "ReleaseDate",
                value: new DateTime(2023, 1, 9, 4, 30, 10, 284, DateTimeKind.Local).AddTicks(8825));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 33,
                column: "ReleaseDate",
                value: new DateTime(2023, 8, 4, 23, 51, 32, 818, DateTimeKind.Local).AddTicks(2816));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 34,
                column: "ReleaseDate",
                value: new DateTime(2023, 6, 7, 22, 27, 54, 198, DateTimeKind.Local).AddTicks(7922));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 35,
                column: "ReleaseDate",
                value: new DateTime(2023, 2, 19, 8, 39, 37, 193, DateTimeKind.Local).AddTicks(7784));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 36,
                column: "ReleaseDate",
                value: new DateTime(2023, 8, 8, 15, 13, 13, 336, DateTimeKind.Local).AddTicks(8723));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 37,
                column: "ReleaseDate",
                value: new DateTime(2023, 8, 8, 21, 3, 29, 894, DateTimeKind.Local).AddTicks(9883));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 38,
                column: "ReleaseDate",
                value: new DateTime(2023, 7, 19, 14, 48, 4, 822, DateTimeKind.Local).AddTicks(6294));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 39,
                column: "ReleaseDate",
                value: new DateTime(2023, 1, 2, 8, 47, 11, 776, DateTimeKind.Local).AddTicks(3598));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 40,
                column: "ReleaseDate",
                value: new DateTime(2023, 8, 16, 21, 18, 4, 102, DateTimeKind.Local).AddTicks(6469));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 41,
                column: "ReleaseDate",
                value: new DateTime(2023, 10, 8, 0, 15, 38, 729, DateTimeKind.Local).AddTicks(8765));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 42,
                column: "ReleaseDate",
                value: new DateTime(2023, 1, 26, 16, 26, 12, 992, DateTimeKind.Local).AddTicks(5983));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 43,
                column: "ReleaseDate",
                value: new DateTime(2023, 10, 11, 17, 47, 24, 699, DateTimeKind.Local).AddTicks(1904));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 44,
                column: "ReleaseDate",
                value: new DateTime(2023, 11, 30, 7, 2, 16, 405, DateTimeKind.Local).AddTicks(74));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 45,
                column: "ReleaseDate",
                value: new DateTime(2023, 10, 9, 9, 27, 42, 768, DateTimeKind.Local).AddTicks(8265));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 46,
                column: "ReleaseDate",
                value: new DateTime(2023, 5, 4, 2, 52, 52, 53, DateTimeKind.Local).AddTicks(4634));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 47,
                column: "ReleaseDate",
                value: new DateTime(2023, 2, 9, 7, 10, 59, 536, DateTimeKind.Local).AddTicks(2758));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 48,
                column: "ReleaseDate",
                value: new DateTime(2023, 11, 13, 0, 2, 26, 743, DateTimeKind.Local).AddTicks(9697));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 49,
                column: "ReleaseDate",
                value: new DateTime(2023, 9, 8, 13, 17, 16, 272, DateTimeKind.Local).AddTicks(3708));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 50,
                column: "ReleaseDate",
                value: new DateTime(2023, 3, 28, 9, 41, 50, 304, DateTimeKind.Local).AddTicks(5786));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateTime(2023, 10, 30, 0, 46, 29, 266, DateTimeKind.Local).AddTicks(9622));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "ReleaseDate",
                value: new DateTime(2023, 4, 3, 14, 31, 41, 246, DateTimeKind.Local).AddTicks(7658));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "ReleaseDate",
                value: new DateTime(2023, 5, 29, 9, 18, 24, 427, DateTimeKind.Local).AddTicks(2956));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                column: "ReleaseDate",
                value: new DateTime(2023, 11, 23, 2, 48, 5, 391, DateTimeKind.Local).AddTicks(9416));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                column: "ReleaseDate",
                value: new DateTime(2023, 1, 17, 19, 48, 33, 97, DateTimeKind.Local).AddTicks(4913));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                column: "ReleaseDate",
                value: new DateTime(2023, 6, 30, 4, 7, 16, 912, DateTimeKind.Local).AddTicks(8321));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                column: "ReleaseDate",
                value: new DateTime(2023, 1, 15, 19, 20, 18, 756, DateTimeKind.Local).AddTicks(166));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                column: "ReleaseDate",
                value: new DateTime(2023, 5, 2, 21, 46, 10, 220, DateTimeKind.Local).AddTicks(5666));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9,
                column: "ReleaseDate",
                value: new DateTime(2023, 11, 1, 6, 45, 10, 688, DateTimeKind.Local).AddTicks(7426));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10,
                column: "ReleaseDate",
                value: new DateTime(2023, 4, 24, 1, 18, 52, 178, DateTimeKind.Local).AddTicks(400));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11,
                column: "ReleaseDate",
                value: new DateTime(2023, 8, 4, 10, 36, 57, 735, DateTimeKind.Local).AddTicks(3589));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12,
                column: "ReleaseDate",
                value: new DateTime(2022, 12, 13, 1, 47, 45, 856, DateTimeKind.Local).AddTicks(5969));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13,
                column: "ReleaseDate",
                value: new DateTime(2023, 11, 13, 15, 53, 30, 203, DateTimeKind.Local).AddTicks(5941));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14,
                column: "ReleaseDate",
                value: new DateTime(2023, 9, 25, 16, 31, 50, 656, DateTimeKind.Local).AddTicks(1391));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15,
                column: "ReleaseDate",
                value: new DateTime(2023, 6, 16, 7, 18, 51, 241, DateTimeKind.Local).AddTicks(3278));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 16,
                column: "ReleaseDate",
                value: new DateTime(2023, 2, 27, 21, 58, 16, 513, DateTimeKind.Local).AddTicks(5141));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 17,
                column: "ReleaseDate",
                value: new DateTime(2022, 11, 29, 21, 33, 23, 666, DateTimeKind.Local).AddTicks(4557));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 18,
                column: "ReleaseDate",
                value: new DateTime(2023, 5, 4, 12, 50, 57, 507, DateTimeKind.Local).AddTicks(785));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 19,
                column: "ReleaseDate",
                value: new DateTime(2023, 5, 25, 22, 18, 36, 519, DateTimeKind.Local).AddTicks(2228));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 20,
                column: "ReleaseDate",
                value: new DateTime(2023, 6, 7, 10, 23, 23, 590, DateTimeKind.Local).AddTicks(5932));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 21,
                column: "ReleaseDate",
                value: new DateTime(2023, 5, 7, 6, 38, 24, 39, DateTimeKind.Local).AddTicks(6740));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 22,
                column: "ReleaseDate",
                value: new DateTime(2023, 9, 26, 0, 46, 43, 35, DateTimeKind.Local).AddTicks(8788));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 23,
                column: "ReleaseDate",
                value: new DateTime(2023, 5, 26, 7, 25, 36, 824, DateTimeKind.Local).AddTicks(405));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 24,
                column: "ReleaseDate",
                value: new DateTime(2023, 6, 6, 16, 51, 36, 996, DateTimeKind.Local).AddTicks(8498));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 25,
                column: "ReleaseDate",
                value: new DateTime(2023, 11, 26, 15, 16, 35, 795, DateTimeKind.Local).AddTicks(1861));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 26,
                column: "ReleaseDate",
                value: new DateTime(2022, 12, 25, 0, 50, 44, 859, DateTimeKind.Local).AddTicks(7713));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 27,
                column: "ReleaseDate",
                value: new DateTime(2022, 12, 8, 3, 8, 40, 516, DateTimeKind.Local).AddTicks(9238));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 28,
                column: "ReleaseDate",
                value: new DateTime(2023, 10, 7, 21, 22, 17, 984, DateTimeKind.Local).AddTicks(9884));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 29,
                column: "ReleaseDate",
                value: new DateTime(2023, 9, 25, 23, 52, 9, 875, DateTimeKind.Local).AddTicks(2311));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 30,
                column: "ReleaseDate",
                value: new DateTime(2023, 3, 31, 18, 34, 38, 883, DateTimeKind.Local).AddTicks(4486));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 31,
                column: "ReleaseDate",
                value: new DateTime(2023, 2, 11, 10, 19, 51, 751, DateTimeKind.Local).AddTicks(8065));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 32,
                column: "ReleaseDate",
                value: new DateTime(2022, 12, 17, 21, 49, 22, 116, DateTimeKind.Local).AddTicks(5321));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 33,
                column: "ReleaseDate",
                value: new DateTime(2023, 7, 13, 17, 10, 44, 649, DateTimeKind.Local).AddTicks(9332));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 34,
                column: "ReleaseDate",
                value: new DateTime(2023, 5, 16, 15, 47, 6, 30, DateTimeKind.Local).AddTicks(4484));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 35,
                column: "ReleaseDate",
                value: new DateTime(2023, 1, 28, 1, 58, 49, 25, DateTimeKind.Local).AddTicks(4368));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 36,
                column: "ReleaseDate",
                value: new DateTime(2023, 7, 17, 8, 32, 25, 168, DateTimeKind.Local).AddTicks(5297));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 37,
                column: "ReleaseDate",
                value: new DateTime(2023, 7, 17, 14, 22, 41, 726, DateTimeKind.Local).AddTicks(6473));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 38,
                column: "ReleaseDate",
                value: new DateTime(2023, 6, 27, 8, 7, 16, 654, DateTimeKind.Local).AddTicks(2900));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 39,
                column: "ReleaseDate",
                value: new DateTime(2022, 12, 11, 2, 6, 23, 608, DateTimeKind.Local).AddTicks(220));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 40,
                column: "ReleaseDate",
                value: new DateTime(2023, 7, 25, 14, 37, 15, 934, DateTimeKind.Local).AddTicks(3135));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 41,
                column: "ReleaseDate",
                value: new DateTime(2023, 9, 15, 17, 34, 50, 561, DateTimeKind.Local).AddTicks(5450));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 42,
                column: "ReleaseDate",
                value: new DateTime(2023, 1, 4, 9, 45, 24, 824, DateTimeKind.Local).AddTicks(2665));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 43,
                column: "ReleaseDate",
                value: new DateTime(2023, 9, 19, 11, 6, 36, 530, DateTimeKind.Local).AddTicks(8601));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 44,
                column: "ReleaseDate",
                value: new DateTime(2023, 11, 8, 0, 21, 28, 236, DateTimeKind.Local).AddTicks(6783));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 45,
                column: "ReleaseDate",
                value: new DateTime(2023, 9, 17, 2, 46, 54, 600, DateTimeKind.Local).AddTicks(4993));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 46,
                column: "ReleaseDate",
                value: new DateTime(2023, 4, 11, 20, 12, 3, 885, DateTimeKind.Local).AddTicks(1404));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 47,
                column: "ReleaseDate",
                value: new DateTime(2023, 1, 18, 0, 30, 11, 367, DateTimeKind.Local).AddTicks(9547));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 48,
                column: "ReleaseDate",
                value: new DateTime(2023, 10, 21, 17, 21, 38, 575, DateTimeKind.Local).AddTicks(6504));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 49,
                column: "ReleaseDate",
                value: new DateTime(2023, 8, 17, 6, 36, 28, 104, DateTimeKind.Local).AddTicks(601));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 50,
                column: "ReleaseDate",
                value: new DateTime(2023, 3, 6, 3, 1, 2, 136, DateTimeKind.Local).AddTicks(2701));
        }
    }
}
