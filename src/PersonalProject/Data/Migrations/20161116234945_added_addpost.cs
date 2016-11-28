using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalProject.Data.Migrations
{
    public partial class added_addpost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "AddPost",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AddPost_ApplicationUserId",
                table: "AddPost",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AddPost_AspNetUsers_ApplicationUserId",
                table: "AddPost",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddPost_AspNetUsers_ApplicationUserId",
                table: "AddPost");

            migrationBuilder.DropIndex(
                name: "IX_AddPost_ApplicationUserId",
                table: "AddPost");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "AddPost");
        }
    }
}
