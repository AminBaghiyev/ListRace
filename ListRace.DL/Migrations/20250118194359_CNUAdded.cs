using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListRace.DL.Migrations
{
    /// <inheritdoc />
    public partial class CNUAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Places",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Places",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Categories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90f58f47-7bd6-4005-b6ee-e40f632a8fc3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c79e0a37-e686-471b-b654-7701218c442b", "AQAAAAIAAYagAAAAELQYr2K8Er7pt++lo7wV1mdtSRwKQFIWECZ0JJneqnfhgSJL9xRTt2TXAqYPZ4Ex3g==", "45d1d318-4d8f-4d79-990e-b74539598552" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90f58f47-7bd6-4005-b6ee-e40f632a8fc3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "35d05239-d962-4095-be67-af7a57a2d15d", "AQAAAAIAAYagAAAAEHR5hY9ME2r0e1tD5zID10w5b0yDgS7sm2T/Dg4rqzNsPijzCuFUTZkEnze9/450cg==", "81684766-1182-419f-8372-efc59862a7ce" });
        }
    }
}
