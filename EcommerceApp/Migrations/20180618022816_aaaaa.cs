using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EcommerceApp.Migrations
{
    public partial class aaaaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Picture_Product_productId",
                table: "Picture");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "productName",
                table: "Product",
                newName: "ProductName");

            migrationBuilder.RenameColumn(
                name: "productId",
                table: "Product",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "productId",
                table: "Picture",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "fileNamee",
                table: "Picture",
                newName: "FileName");

            migrationBuilder.RenameIndex(
                name: "IX_Picture_productId",
                table: "Picture",
                newName: "IX_Picture_ProductId");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Product",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Picture_Product_ProductId",
                table: "Picture",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "categoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Picture_Product_ProductId",
                table: "Picture");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "Product",
                newName: "productName");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Product",
                newName: "productId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Picture",
                newName: "productId");

            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "Picture",
                newName: "fileNamee");

            migrationBuilder.RenameIndex(
                name: "IX_Picture_ProductId",
                table: "Picture",
                newName: "IX_Picture_productId");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Product",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Picture_Product_productId",
                table: "Picture",
                column: "productId",
                principalTable: "Product",
                principalColumn: "productId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "categoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
