using Microsoft.EntityFrameworkCore;
using ProductApp.Data;
using ProductApp.DAO;
using ProductApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Добавляем поддержку контроллеров с представлениями
builder.Services.AddControllersWithViews();

// Настраиваем EF Core для PostgreSQL с использованием строки подключения
builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Регистрируем зависимости для DAO и Service слоев
builder.Services.AddScoped<IProductDao, ProductDao>();
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Маршрутизация: по умолчанию контроллер Product и его метод Index
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
