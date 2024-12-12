using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Study.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class createDbSetToIntermediaryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthorMap_Authors_Author_Id",
                table: "BookAuthorMap");

            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthorMap_Books_Book_Id",
                table: "BookAuthorMap");

            migrationBuilder.DropForeignKey(
                name: "FK_FluentBookAuthorMap_Fluent_Author_Author_Id",
                table: "FluentBookAuthorMap");

            migrationBuilder.DropForeignKey(
                name: "FK_FluentBookAuthorMap_Fluent_Book_Book_Id",
                table: "FluentBookAuthorMap");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FluentBookAuthorMap",
                table: "FluentBookAuthorMap");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookAuthorMap",
                table: "BookAuthorMap");

            migrationBuilder.RenameTable(
                name: "FluentBookAuthorMap",
                newName: "FluentBookAuthors");

            migrationBuilder.RenameTable(
                name: "BookAuthorMap",
                newName: "BookAuthors");

            migrationBuilder.RenameIndex(
                name: "IX_FluentBookAuthorMap_Book_Id",
                table: "FluentBookAuthors",
                newName: "IX_FluentBookAuthors_Book_Id");

            migrationBuilder.RenameIndex(
                name: "IX_BookAuthorMap_Book_Id",
                table: "BookAuthors",
                newName: "IX_BookAuthors_Book_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FluentBookAuthors",
                table: "FluentBookAuthors",
                columns: new[] { "Author_Id", "Book_Id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookAuthors",
                table: "BookAuthors",
                columns: new[] { "Author_Id", "Book_Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthors_Authors_Author_Id",
                table: "BookAuthors",
                column: "Author_Id",
                principalTable: "Authors",
                principalColumn: "Author_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthors_Books_Book_Id",
                table: "BookAuthors",
                column: "Book_Id",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FluentBookAuthors_Fluent_Author_Author_Id",
                table: "FluentBookAuthors",
                column: "Author_Id",
                principalTable: "Fluent_Author",
                principalColumn: "Author_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FluentBookAuthors_Fluent_Book_Book_Id",
                table: "FluentBookAuthors",
                column: "Book_Id",
                principalTable: "Fluent_Book",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthors_Authors_Author_Id",
                table: "BookAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthors_Books_Book_Id",
                table: "BookAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_FluentBookAuthors_Fluent_Author_Author_Id",
                table: "FluentBookAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_FluentBookAuthors_Fluent_Book_Book_Id",
                table: "FluentBookAuthors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FluentBookAuthors",
                table: "FluentBookAuthors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookAuthors",
                table: "BookAuthors");

            migrationBuilder.RenameTable(
                name: "FluentBookAuthors",
                newName: "FluentBookAuthorMap");

            migrationBuilder.RenameTable(
                name: "BookAuthors",
                newName: "BookAuthorMap");

            migrationBuilder.RenameIndex(
                name: "IX_FluentBookAuthors_Book_Id",
                table: "FluentBookAuthorMap",
                newName: "IX_FluentBookAuthorMap_Book_Id");

            migrationBuilder.RenameIndex(
                name: "IX_BookAuthors_Book_Id",
                table: "BookAuthorMap",
                newName: "IX_BookAuthorMap_Book_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FluentBookAuthorMap",
                table: "FluentBookAuthorMap",
                columns: new[] { "Author_Id", "Book_Id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookAuthorMap",
                table: "BookAuthorMap",
                columns: new[] { "Author_Id", "Book_Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthorMap_Authors_Author_Id",
                table: "BookAuthorMap",
                column: "Author_Id",
                principalTable: "Authors",
                principalColumn: "Author_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthorMap_Books_Book_Id",
                table: "BookAuthorMap",
                column: "Book_Id",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FluentBookAuthorMap_Fluent_Author_Author_Id",
                table: "FluentBookAuthorMap",
                column: "Author_Id",
                principalTable: "Fluent_Author",
                principalColumn: "Author_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FluentBookAuthorMap_Fluent_Book_Book_Id",
                table: "FluentBookAuthorMap",
                column: "Book_Id",
                principalTable: "Fluent_Book",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
