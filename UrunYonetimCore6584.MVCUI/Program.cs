using UrunYonetimCore6584.Data;
using UrunYonetimCore6584.Service.Abstract;
using UrunYonetimCore6584.Service.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DatabaseContext>();

builder.Services.AddTransient(typeof(IService<>), typeof(Service<>)); // veritaban� i�lerini yapacak olan yazd���m�z servisi uygulamaya tan�tt�k

//builder.Services.AddTransient<IProductService, ProductService>(); // 1. yaz�m t�r�
builder.Services.AddTransient(typeof(IProductService), typeof(ProductService)); // 2. yaz�m t�r�. �r�n y�netimi i�in yapt���m�z �zel servisi ekledik, bunu eklemezsek uygulama hata verir!

// Uygulamaya Servis eklemede 3 farkl� y�ntem var
/*
 * builder.Services.AddTransient : Bu y�ntem e�er kullan�mda nesne varsa onu kullan�r yoksa yeni nesne olu�turur.
 * builder.Services.AddSingleton : Bu y�ntem uygulama �al��t���nda nesneyi 1 kez olu�turur ve her istekte ayn� nesneyi d�nd�r�r
 * builder.Services.AddScoped : Bu y�ntemde servise gelen her istekte yeni nesne olu�turulur
 * */

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
            name: "admin",
            pattern: "{area:exists}/{controller=Main}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
