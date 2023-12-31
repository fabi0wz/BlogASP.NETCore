﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfilePictureUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "personalUserName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Post_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Post_Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Post_Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Post_Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Post_Id);
                    table.ForeignKey(
                        name: "FK_Post_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Post_AspNetUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Post_Images",
                columns: table => new
                {
                    Image_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image_Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Post_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post_Images", x => x.Image_Id);
                    table.ForeignKey(
                        name: "FK_Post_Images_Post_Post_Id",
                        column: x => x.Post_Id,
                        principalTable: "Post",
                        principalColumn: "Post_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Post_User_Comments",
                columns: table => new
                {
                    Comment_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Post_User_Comments1Comment_Id = table.Column<int>(type: "int", nullable: true),
                    Post_Id = table.Column<int>(type: "int", nullable: false),
                    User_CommentId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post_User_Comments", x => x.Comment_Id);
                    table.ForeignKey(
                        name: "FK_Post_User_Comments_AspNetUsers_User_CommentId",
                        column: x => x.User_CommentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Post_User_Comments_Post_Post_Id",
                        column: x => x.Post_Id,
                        principalTable: "Post",
                        principalColumn: "Post_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Post_User_Comments_Post_User_Comments_Post_User_Comments1Comment_Id",
                        column: x => x.Post_User_Comments1Comment_Id,
                        principalTable: "Post_User_Comments",
                        principalColumn: "Comment_Id");
                });

            migrationBuilder.CreateTable(
                name: "Post_User_Likes",
                columns: table => new
                {
                    Like_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Post_Id = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post_User_Likes", x => x.Like_Id);
                    table.ForeignKey(
                        name: "FK_Post_User_Likes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Post_User_Likes_Post_Post_Id",
                        column: x => x.Post_Id,
                        principalTable: "Post",
                        principalColumn: "Post_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Post_User_Views",
                columns: table => new
                {
                    View_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Post_Id = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post_User_Views", x => x.View_Id);
                    table.ForeignKey(
                        name: "FK_Post_User_Views_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Post_User_Views_Post_Post_Id",
                        column: x => x.Post_Id,
                        principalTable: "Post",
                        principalColumn: "Post_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Post_CreatedById",
                table: "Post",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Post_UpdatedById",
                table: "Post",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Post_Images_Post_Id",
                table: "Post_Images",
                column: "Post_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Post_User_Comments_Post_Id",
                table: "Post_User_Comments",
                column: "Post_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Post_User_Comments_Post_User_Comments1Comment_Id",
                table: "Post_User_Comments",
                column: "Post_User_Comments1Comment_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Post_User_Comments_User_CommentId",
                table: "Post_User_Comments",
                column: "User_CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_User_Likes_Post_Id",
                table: "Post_User_Likes",
                column: "Post_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Post_User_Likes_UserId",
                table: "Post_User_Likes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_User_Views_Post_Id",
                table: "Post_User_Views",
                column: "Post_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Post_User_Views_UserId",
                table: "Post_User_Views",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Post_Images");

            migrationBuilder.DropTable(
                name: "Post_User_Comments");

            migrationBuilder.DropTable(
                name: "Post_User_Likes");

            migrationBuilder.DropTable(
                name: "Post_User_Views");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfilePictureUrl",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "personalUserName",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
