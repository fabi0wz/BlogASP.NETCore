using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class bababa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_AspNetUsers_Created_ById",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_AspNetUsers_Updated_ById",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_Updated_ById",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "Updated_ById",
                table: "Post");

            migrationBuilder.RenameColumn(
                name: "Created_ById",
                table: "Post",
                newName: "UpdatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Post_Created_ById",
                table: "Post",
                newName: "IX_Post_UpdatedById");

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Post",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Post_CreatedById",
                table: "Post",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_AspNetUsers_CreatedById",
                table: "Post",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_AspNetUsers_UpdatedById",
                table: "Post",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_AspNetUsers_CreatedById",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_AspNetUsers_UpdatedById",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_CreatedById",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Post");

            migrationBuilder.RenameColumn(
                name: "UpdatedById",
                table: "Post",
                newName: "Created_ById");

            migrationBuilder.RenameIndex(
                name: "IX_Post_UpdatedById",
                table: "Post",
                newName: "IX_Post_Created_ById");

            migrationBuilder.AddColumn<string>(
                name: "Updated_ById",
                table: "Post",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Post_Updated_ById",
                table: "Post",
                column: "Updated_ById");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_AspNetUsers_Created_ById",
                table: "Post",
                column: "Created_ById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_AspNetUsers_Updated_ById",
                table: "Post",
                column: "Updated_ById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
