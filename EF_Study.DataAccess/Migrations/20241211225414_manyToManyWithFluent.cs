﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Study.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class manyToManyWithFluent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FluentAuthorFluentBook");

            migrationBuilder.CreateTable(
                name: "FluentBookAuthorMap",
                columns: table => new
                {
                    Book_Id = table.Column<int>(type: "int", nullable: false),
                    Author_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FluentBookAuthorMap", x => new { x.Author_Id, x.Book_Id });
                    table.ForeignKey(
                        name: "FK_FluentBookAuthorMap_Fluent_Author_Author_Id",
                        column: x => x.Author_Id,
                        principalTable: "Fluent_Author",
                        principalColumn: "Author_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FluentBookAuthorMap_Fluent_Book_Book_Id",
                        column: x => x.Book_Id,
                        principalTable: "Fluent_Book",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FluentBookAuthorMap_Book_Id",
                table: "FluentBookAuthorMap",
                column: "Book_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FluentBookAuthorMap");

            migrationBuilder.CreateTable(
                name: "FluentAuthorFluentBook",
                columns: table => new
                {
                    AuthorsAuthor_Id = table.Column<int>(type: "int", nullable: false),
                    BooksBookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FluentAuthorFluentBook", x => new { x.AuthorsAuthor_Id, x.BooksBookId });
                    table.ForeignKey(
                        name: "FK_FluentAuthorFluentBook_Fluent_Author_AuthorsAuthor_Id",
                        column: x => x.AuthorsAuthor_Id,
                        principalTable: "Fluent_Author",
                        principalColumn: "Author_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FluentAuthorFluentBook_Fluent_Book_BooksBookId",
                        column: x => x.BooksBookId,
                        principalTable: "Fluent_Book",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FluentAuthorFluentBook_BooksBookId",
                table: "FluentAuthorFluentBook",
                column: "BooksBookId");
        }
    }
}