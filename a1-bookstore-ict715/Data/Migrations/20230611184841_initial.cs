using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace a1_bookstore_ict715.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactUs",
                columns: table => new
                {
                    ContactUsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUs", x => x.ContactUsId);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    GenreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GenreName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenreName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenreId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Authors = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Book_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "GenreId");
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "BookId", "Authors", "Description", "GenreId", "GenreName", "Name", "Price", "PublishDate" },
                values: new object[,]
                {
                    { 1, "Robert Jordan", "Yet another book in the Eye of the World saga", null, "Science Fiction and fantasy", "Winter's Heart", 49m, new DateTime(2000, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "David Wong", "The spoiler is that John does not, in fact, die in the end", null, "General Fiction and literature", "John Dies at the End", 18m, new DateTime(2009, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Carl Sagan", "Cosmos is about science in its broadest human context, how science and society grew up together", null, "Natural sciences & mathmatics", "Cosmos", 50m, new DateTime(2010, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Barbara W Tuchman", "Tells the story of the opening months of World War 1", null, "Geography and history", "The Guns of August", 50m, new DateTime(1994, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "J.R.R. Tolkein", "A masterful fantasy told by the legendary J.R.R. Tolkein", null, "Science Fiction and fantasy", "The Hobbit", 50m, new DateTime(1978, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Herman Melville", "The latest edition of the classic tale by American writer Herman Melville", null, "General Fiction and literature", "Moby Dick", 50m, new DateTime(1984, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "Douglas Adams", "A trilogy in five parts", null, "Science Fiction and fantasy", "The Hitch Hiker's Guide to the Galaxy", 50m, new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "Diana Walstad", "A comprehensive guide to the science and biology within our aquariums", null, "Natural sciences & mathmatics", "The Ecology of the Planted Aquarium", 30m, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "Mighael Brooks", "A thoughtful look into how science actually works", null, "Natural sciences & mathmatics", "13 Thing That Don't Make Sense", 30m, new DateTime(2009, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "Cormac McCarthy", "A searing, postapocalyptic tale of a father and son's journey", null, "General Fiction and literature", "The Road", 11m, new DateTime(2006, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "GenreId", "GenreName" },
                values: new object[,]
                {
                    { "Art", "The arts" },
                    { "Fic", "General Fiction and literature" },
                    { "Geo", "Geography and history" },
                    { "Lang", "Languages" },
                    { "Nat", "Natural sciences & mathmatics" },
                    { "Phi", "Philosophy and psychology" },
                    { "Rel", "Religion" },
                    { "ScFi", "Science Fiction and fantasy" },
                    { "Soc", "Social sciences" },
                    { "Tec", "Technology and applied sciences" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_GenreId",
                table: "Book",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "ContactUs");

            migrationBuilder.DropTable(
                name: "Genre");
        }
    }
}
