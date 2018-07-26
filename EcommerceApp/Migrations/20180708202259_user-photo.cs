using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EcommerceApp.Migrations
{
    public partial class userphoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "JwtUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "JwtUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "JwtUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "JwtUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "JwtUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Interests",
                table: "JwtUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Introduction",
                table: "JwtUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KnownAs",
                table: "JwtUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastActive",
                table: "JwtUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LookingFor",
                table: "JwtUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsMain = table.Column<bool>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photo_JwtUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "JwtUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photo_UserId",
                table: "Photo",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DropColumn(
                name: "City",
                table: "JwtUsers");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "JwtUsers");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "JwtUsers");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "JwtUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "JwtUsers");

            migrationBuilder.DropColumn(
                name: "Interests",
                table: "JwtUsers");

            migrationBuilder.DropColumn(
                name: "Introduction",
                table: "JwtUsers");

            migrationBuilder.DropColumn(
                name: "KnownAs",
                table: "JwtUsers");

            migrationBuilder.DropColumn(
                name: "LastActive",
                table: "JwtUsers");

            migrationBuilder.DropColumn(
                name: "LookingFor",
                table: "JwtUsers");
        }
    }
}
