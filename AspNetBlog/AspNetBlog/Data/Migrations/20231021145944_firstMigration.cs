using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Country_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Country_Id);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Post_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Post_Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Post_Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Post_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_ById = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Updated_ById = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Post_Id);
                    table.ForeignKey(
                        name: "FK_Post_AspNetUsers_Created_ById",
                        column: x => x.Created_ById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Post_AspNetUsers_Updated_ById",
                        column: x => x.Updated_ById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Post_Images",
                columns: table => new
                {
                    Image_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Post_Id = table.Column<int>(type: "int", nullable: false),
                    Image_Path = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Post_Id = table.Column<int>(type: "int", nullable: false),
                    User_Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Parent_Comment = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post_User_Comments", x => x.Comment_Id);
                    table.ForeignKey(
                        name: "FK_Post_User_Comments_AspNetUsers_User_Id",
                        column: x => x.User_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Post_User_Comments_Post_Post_Id",
                        column: x => x.Post_Id,
                        principalTable: "Post",
                        principalColumn: "Post_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Post_User_Comments_Post_User_Comments_Parent_Comment",
                        column: x => x.Parent_Comment,
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
                    User_Id = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post_User_Likes", x => x.Like_Id);
                    table.ForeignKey(
                        name: "FK_Post_User_Likes_AspNetUsers_User_Id",
                        column: x => x.User_Id,
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
                    User_Id = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post_User_Views", x => x.View_Id);
                    table.ForeignKey(
                        name: "FK_Post_User_Views_AspNetUsers_User_Id",
                        column: x => x.User_Id,
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
                name: "IX_Post_Created_ById",
                table: "Post",
                column: "Created_ById");

            migrationBuilder.CreateIndex(
                name: "IX_Post_Updated_ById",
                table: "Post",
                column: "Updated_ById");

            migrationBuilder.CreateIndex(
                name: "IX_Post_Images_Post_Id",
                table: "Post_Images",
                column: "Post_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Post_User_Comments_Parent_Comment",
                table: "Post_User_Comments",
                column: "Parent_Comment");

            migrationBuilder.CreateIndex(
                name: "IX_Post_User_Comments_Post_Id",
                table: "Post_User_Comments",
                column: "Post_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Post_User_Comments_User_Id",
                table: "Post_User_Comments",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Post_User_Likes_Post_Id",
                table: "Post_User_Likes",
                column: "Post_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Post_User_Likes_User_Id",
                table: "Post_User_Likes",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Post_User_Views_Post_Id",
                table: "Post_User_Views",
                column: "Post_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Post_User_Views_User_Id",
                table: "Post_User_Views",
                column: "User_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Country");

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
        }
    }
}
