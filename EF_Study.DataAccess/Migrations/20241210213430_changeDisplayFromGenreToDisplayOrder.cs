﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Study.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class changeDisplayFromGenreToDisplayOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Display",
                table: "Genres",
                newName: "DisplayOrder");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DisplayOrder",
                table: "Genres",
                newName: "Display");
        }
    }
}
