using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace core.data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsRead = table.Column<bool>(type: "boolean", nullable: true),
                    DateRead = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Rate = table.Column<int>(type: "integer", nullable: true),
                    Genre = table.Column<string>(type: "text", nullable: true),
                    AuthorName = table.Column<string>(type: "text", nullable: true),
                    CoverUrl = table.Column<string>(type: "text", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PublisherId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Books_Authors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BookId = table.Column<Guid>(type: "uuid", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books_Authors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Authors_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorName", "CoverUrl", "DateAdded", "DateRead", "Description", "Genre", "IsRead", "PublisherId", "Rate", "Title" },
                values: new object[,]
                {
                    { new Guid("236807d4-2934-4066-8f1d-4d9e69ab5246"), null, null, null, null, null, null, null, null, null, null },
                    { new Guid("3492cfd6-ca5b-4804-8866-4e4a259b735c"), "JohnDoe", "RichDadPoorDad.png", new DateTime(2023, 6, 3, 21, 55, 19, 168, DateTimeKind.Utc).AddTicks(8363), new DateTime(2023, 6, 3, 21, 55, 19, 168, DateTimeKind.Utc).AddTicks(8361), "Story of a rich and poor dad", "Non-Fiction", true, new Guid("6067d832-74b9-400a-ad79-8b57360ab375"), 5, "Rich Dad Poor Dad" },
                    { new Guid("ab87c0b1-2038-4b4e-a8ef-9f7399bfa06a"), null, null, null, null, null, null, null, null, null, null },
                    { new Guid("f71f4168-b571-493f-b611-51b163b09835"), null, null, null, null, null, null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Books_Authors",
                columns: new[] { "Id", "AuthorId", "BookId" },
                values: new object[,]
                {
                    { new Guid("47f118a4-eedd-4272-9f07-4b2a2e5bee82"), new Guid("458e616b-da29-4b9c-b98f-9af22661cee0"), new Guid("426a6881-bd04-41fa-8460-f14b1ed6d3f2") },
                    { new Guid("ebf80ff2-d547-4581-99d4-b4587ca46443"), new Guid("effc238d-ec04-4537-894d-bd96087935d9"), new Guid("6cddd0fc-1aa3-4ac7-bdf0-d52388e8efff") }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "FullName" },
                values: new object[,]
                {
                    { new Guid("36022146-b10a-4d2b-bb2a-e434fe96ff16"), "Mike Best" },
                    { new Guid("98a68d6c-c875-4f96-bba7-68a64cb493c4"), "Chris John" },
                    { new Guid("d311092e-a78a-48b7-a8ea-76a766a84c44"), "Maria Rose" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                table: "Books",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Authors_AuthorId",
                table: "Books_Authors",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Authors_BookId",
                table: "Books_Authors",
                column: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books_Authors");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
