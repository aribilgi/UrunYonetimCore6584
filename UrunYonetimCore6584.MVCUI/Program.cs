using UrunYonetimCore6584.Data;
using UrunYonetimCore6584.Service.Abstract;
using UrunYonetimCore6584.Service.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DatabaseContext>();

builder.Services.AddTransient(typeof(IService<>), typeof(Service<>)); // veritabaný iþlerini yapacak olan yazdýðýmýz servisi uygulamaya tanýttýk

//builder.Services.AddTransient<IProductService, ProductService>(); // 1. yazým türü
builder.Services.AddTransient(typeof(IProductService), typeof(ProductService)); // 2. yazým türü. ürün yönetimi için yaptýðýmýz özel servisi ekledik, bunu eklemezsek uygulama hata verir!

// Uygulamaya Servis eklemede 3 farklý yöntem var
/*
 * builder.Services.AddTransient : Bu yöntem eðer kullanýmda nesne varsa onu kullanýr yoksa yeni nesne oluþturur.
 * builder.Services.AddSingleton : Bu yöntem uygulama çalýþtýðýnda nesneyi 1 kez oluþturur ve her istekte ayný nesneyi döndürür
 * builder.Services.AddScoped : Bu yöntemde servise gelen her istekte yeni nesne oluþturulur
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
