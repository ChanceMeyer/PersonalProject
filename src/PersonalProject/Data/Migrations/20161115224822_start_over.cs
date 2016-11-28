using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalProject.Data.Migrations
{
    public partial class start_over : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "AddPost",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "AddPost",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AddPost");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "AddPost");
        }
    }
}
