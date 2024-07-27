using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AspNetCoreMvc_eTicaret_MovieSales.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedDataAndRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Email", "Name", "Password", "Phone" },
                values: new object[,]
                {
                    { 1, "Beşiktaş-İstanbul", "aucar@gmail.com", "Ali Uçar", "123", "543 345 66 77" },
                    { 2, "Kadıköy-İstanbul", "okosar@gmail.com", "Oya Koşar", "123", "533 345 66 77" },
                    { 3, "Bakırköy-İstanbul", "nsever@gmail.com", "Neşe Sever", "123", "542 345 66 77" },
                    { 4, "Fatih-İstanbul", "hkaya@gmail.com", "Hasan Kaya", "123", "535 345 66 77" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Komik olaylar", "Komedi" },
                    { 2, "Tarihi savaşlar", "Savaş" },
                    { 3, "Hem romantik hem komik", "Romantik Komedi" },
                    { 4, "Acıklı hikayeler", "Dram" },
                    { 5, "Korku, gerilim", "Korku" },
                    { 6, "Uzay, robotlar", "Bilim Kurgu" },
                    { 7, "Gerçek dışı, heyecanlı", "Fantastik" },
                    { 8, "Hareket, aksiyon sahneleri", "Aksiyon" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Cast", "Director", "GenreId", "IsLocal", "Name", "Price", "ReleaseDate", "Stock", "Summary" },
                values: new object[,]
                {
                    { 1, "Bradd Pitt, Orlando Bloom", "Wolfgan Pettersen", 2, false, "Truva", 450m, new DateTime(2024, 7, 24, 22, 4, 59, 228, DateTimeKind.Local).AddTicks(7466), 5, "Tarihi Truva savaşından kesitler" },
                    { 2, "Annda George, Donny Alamsyah", "Gareth Evans", 8, false, "Baskın", 400m, new DateTime(2024, 7, 24, 22, 4, 59, 228, DateTimeKind.Local).AddTicks(7483), 6, "Operasyon timinin uyuşturucu baskınları" },
                    { 3, "Leonardo Di Caprio, Cate Winslet", "James Cameron", 4, false, "Titanic", 500m, new DateTime(2024, 7, 24, 22, 4, 59, 228, DateTimeKind.Local).AddTicks(7486), 15, "Lüks titanic gemisinin hazin öyküsü" },
                    { 4, "Bradd Pitt, Edward Norton", "David Lyinch", 8, false, "Fight Club", 450m, new DateTime(2024, 7, 24, 22, 4, 59, 228, DateTimeKind.Local).AddTicks(7488), 5, "Dövüş kulübü, ilk kural bahsetmemek" },
                    { 5, "Bradd Pitt, Christoph Walls", "Quantin Tarantino", 2, false, "Soysuzlar Çetesi", 520m, new DateTime(2024, 7, 24, 22, 4, 59, 228, DateTimeKind.Local).AddTicks(7490), 10, "2. Dünya savaşından kesitler" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieSales_CustomerId",
                table: "MovieSales",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieSaleDetails_MovieId",
                table: "MovieSaleDetails",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieSaleDetails_MovieSaleId",
                table: "MovieSaleDetails",
                column: "MovieSaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreId",
                table: "Movies",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genres_GenreId",
                table: "Movies",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieSaleDetails_MovieSales_MovieSaleId",
                table: "MovieSaleDetails",
                column: "MovieSaleId",
                principalTable: "MovieSales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieSaleDetails_Movies_MovieId",
                table: "MovieSaleDetails",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieSales_Customers_CustomerId",
                table: "MovieSales",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genres_GenreId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieSaleDetails_MovieSales_MovieSaleId",
                table: "MovieSaleDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieSaleDetails_Movies_MovieId",
                table: "MovieSaleDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieSales_Customers_CustomerId",
                table: "MovieSales");

            migrationBuilder.DropIndex(
                name: "IX_MovieSales_CustomerId",
                table: "MovieSales");

            migrationBuilder.DropIndex(
                name: "IX_MovieSaleDetails_MovieId",
                table: "MovieSaleDetails");

            migrationBuilder.DropIndex(
                name: "IX_MovieSaleDetails_MovieSaleId",
                table: "MovieSaleDetails");

            migrationBuilder.DropIndex(
                name: "IX_Movies_GenreId",
                table: "Movies");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
