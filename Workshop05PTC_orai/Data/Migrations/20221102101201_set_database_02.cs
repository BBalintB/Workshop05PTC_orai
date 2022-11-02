using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Workshop05PTC_orai.Data.Migrations
{
    public partial class set_database_02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "ImageFileName",
                table: "Cars",
                newName: "UserId");

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Cars",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Cars",
                newName: "ImageFileName");

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                table: "Cars",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
