﻿using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EcommerceApp.Migrations
{
    public partial class qqq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppId",
                table: "AspNetRoles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AppRoleName",
                table: "AspNetRoles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppId",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "AppRoleName",
                table: "AspNetRoles");
        }
    }
}
