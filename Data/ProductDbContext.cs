using Microsoft.EntityFrameworkCore;
using ProductApp.Entities;

namespace ProductApp.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Price = 1500m,
                    Name = "Боди Caero",
                    Size = "M",
                    Color = "Черный",
                    Material = "Хлопок",
                    Description = "Элегантное боди Caero для бальных танцев.",
                    Gender = "Женский",
                    Type = "Боди",
                    Care = "Ручная стирка",
                    Season = "Лето",
                    Length = 100,
                    Image = "/img/catalog/bodi_caero.jpg"
                },
                new Product
                {
                    Id = 2,
                    Price = 1600m,
                    Name = "Боди Volano",
                    Size = "M",
                    Color = "Белый",
                    Material = "Шелк",
                    Description = "Элегантное боди Volano для танцев.",
                    Gender = "Женский",
                    Type = "Боди",
                    Care = "Ручная стирка",
                    Season = "Лето",
                    Length = 100,
                    Image = "/img/catalog/bodi_volano.jpg"
                },
                new Product
                {
                    Id = 3,
                    Price = 2000m,
                    Name = "Брюки Frandio",
                    Size = "L",
                    Color = "Синий",
                    Material = "Лён",
                    Description = "Стильные брюки Frandio для мужчин.",
                    Gender = "Мужской",
                    Type = "Брюки",
                    Care = "Химчистка",
                    Season = "Осень",
                    Length = 110,
                    Image = "/img/catalog/bruki_muzsk.jpg"
                },
                new Product
                {
                    Id = 4,
                    Price = 2300m,
                    Name = "Мужские туфли",
                    Size = "42",
                    Color = "Черные",
                    Material = "Кожа",
                    Description = "Классические мужские туфли.",
                    Gender = "Мужской",
                    Type = "Туфли",
                    Care = "Полировка",
                    Season = "Зима",
                    Length = 30,
                    Image = "/img/catalog/muzhskie_tufli.jpg"
                },
                new Product
                {
                    Id = 5,
                    Price = 3000m,
                    Name = "Платье Clarine Beige",
                    Size = "38",
                    Color = "Бежевый",
                    Material = "Шелк и эластан",
                    Description = "Элегантное платье для бальных танцев.",
                    Gender = "Женский",
                    Type = "Платье",
                    Care = "Ручная стирка",
                    Season = "Весна/Лето",
                    Length = 140,
                    Image = "/img/catalog/plate_clarine_beige.jpg"
                },
                new Product
                {
                    Id = 6,
                    Price = 3200m,
                    Name = "Платье Clarine Rustica Roze",
                    Size = "40",
                    Color = "Розовый",
                    Material = "Шелк",
                    Description = "Платье Clarine Rustica Roze в элегантном стиле.",
                    Gender = "Женский",
                    Type = "Платье",
                    Care = "Химчистка",
                    Season = "Осень",
                    Length = 135,
                    Image = "/img/catalog/plate_clarine_rustica_roze.jpg"
                },
                new Product
                {
                    Id = 7,
                    Price = 3500m,
                    Name = "Платье Fuego Ardiente Red",
                    Size = "36",
                    Color = "Красный",
                    Material = "Шелк",
                    Description = "Яркое платье Fuego Ardiente Red для смелых образов.",
                    Gender = "Женский",
                    Type = "Платье",
                    Care = "Ручная стирка",
                    Season = "Лето",
                    Length = 130,
                    Image = "/img/catalog/plate_fuego_ardiente_red.jpg"
                },
                new Product
                {
                    Id = 8,
                    Price = 1800m,
                    Name = "Рубашка Frame",
                    Size = "M",
                    Color = "Белый",
                    Material = "Хлопок",
                    Description = "Стильная рубашка Frame для мужчин.",
                    Gender = "Мужской",
                    Type = "Рубашка",
                    Care = "Стирка в машине",
                    Season = "Весна",
                    Length = 70,
                    Image = "/img/catalog/rubashka_frame.jpg"
                },
                new Product
                {
                    Id = 9,
                    Price = 2800m,
                    Name = "Женские туфли",
                    Size = "37",
                    Color = "Бежевый",
                    Material = "Кожа",
                    Description = "Изящные женские туфли для стильного образа.",
                    Gender = "Женский",
                    Type = "Туфли",
                    Care = "Полировка",
                    Season = "Лето",
                    Length = 25,
                    Image = "/img/catalog/tufli_latina_zhensk.jpg"
                }
            );
        }
    }
}
