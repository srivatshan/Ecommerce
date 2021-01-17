using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductsApi.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "PictureName", "PictureUrl", "Price" },
                values: new object[] { 1, "Mobile Phone", "Samsung_01", "Samsung_01", "Url", 10m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "PictureName", "PictureUrl", "Price" },
                values: new object[] { 2, "Mobile Phone", "Samsung_02", "Samsung_02", "Url", 11m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
