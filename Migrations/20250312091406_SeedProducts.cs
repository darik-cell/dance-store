using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Care", "Color", "Description", "Gender", "Image", "Length", "Material", "Name", "Price", "Season", "Size", "Type" },
                values: new object[,]
                {
                    { 1, "Ручная стирка", "Черный", "Элегантное боди Caero для бальных танцев.", "Женский", "/img/catalog/bodi_caero.jpg", 100.0, "Хлопок", "Боди Caero", 1500m, "Лето", "M", "Боди" },
                    { 2, "Ручная стирка", "Белый", "Элегантное боди Volano для танцев.", "Женский", "/img/catalog/bodi_volano.jpg", 100.0, "Шелк", "Боди Volano", 1600m, "Лето", "M", "Боди" },
                    { 3, "Химчистка", "Синий", "Стильные брюки Frandio для мужчин.", "Мужской", "/img/catalog/bruki_muzsk.jpg", 110.0, "Лён", "Брюки Frandio", 2000m, "Осень", "L", "Брюки" },
                    { 4, "Полировка", "Черные", "Классические мужские туфли.", "Мужской", "/img/catalog/muzhskie_tufli.jpg", 30.0, "Кожа", "Мужские туфли", 2300m, "Зима", "42", "Туфли" },
                    { 5, "Ручная стирка", "Бежевый", "Элегантное платье для бальных танцев.", "Женский", "/img/catalog/plate_clarine_beige.jpg", 140.0, "Шелк и эластан", "Платье Clarine Beige", 3000m, "Весна/Лето", "38", "Платье" },
                    { 6, "Химчистка", "Розовый", "Платье Clarine Rustica Roze в элегантном стиле.", "Женский", "/img/catalog/plate_clarine_rustica_roze.jpg", 135.0, "Шелк", "Платье Clarine Rustica Roze", 3200m, "Осень", "40", "Платье" },
                    { 7, "Ручная стирка", "Красный", "Яркое платье Fuego Ardiente Red для смелых образов.", "Женский", "/img/catalog/plate_fuego_ardiente_red.jpg", 130.0, "Шелк", "Платье Fuego Ardiente Red", 3500m, "Лето", "36", "Платье" },
                    { 8, "Стирка в машине", "Белый", "Стильная рубашка Frame для мужчин.", "Мужской", "/img/catalog/rubashka_frame.jpg", 70.0, "Хлопок", "Рубашка Frame", 1800m, "Весна", "M", "Рубашка" },
                    { 9, "Полировка", "Бежевый", "Изящные женские туфли для стильного образа.", "Женский", "/img/catalog/tufli_latina_zhensk.jpg", 25.0, "Кожа", "Женские туфли", 2800m, "Лето", "37", "Туфли" }
                });
        }

        /// <inheritdoc />
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

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
