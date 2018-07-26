using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EcommerceApp.Migrations
{
    public partial class activeproo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "unitsInStock",
                table: "Product",
                newName: "UnitsInStock");

            migrationBuilder.RenameColumn(
                name: "unitPrice",
                table: "Product",
                newName: "UnitPrice");

            migrationBuilder.RenameColumn(
                name: "productImagePath",
                table: "Product",
                newName: "ProductImagePath");

            migrationBuilder.RenameColumn(
                name: "productDetails",
                table: "Product",
                newName: "ProductDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UnitsInStock",
                table: "Product",
                newName: "unitsInStock");

            migrationBuilder.RenameColumn(
                name: "UnitPrice",
                table: "Product",
                newName: "unitPrice");

            migrationBuilder.RenameColumn(
                name: "ProductImagePath",
                table: "Product",
                newName: "productImagePath");

            migrationBuilder.RenameColumn(
                name: "ProductDetails",
                table: "Product",
                newName: "productDetails");
        }
    }
}
