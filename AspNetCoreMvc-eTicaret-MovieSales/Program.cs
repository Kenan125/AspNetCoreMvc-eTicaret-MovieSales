using AspNetCoreMvc_eTicaret_MovieSales.Data;
using AspNetCoreMvc_eTicaret_MovieSales.Interfaces;
using AspNetCoreMvc_eTicaret_MovieSales.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MovieDbContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr"))
    );

builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IMovieSaleRepository, MovieSaleRepository>();
builder.Services.AddScoped<IMovieSaleDetailRepository, MovieSaleDetailRepository>();


builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddSession();

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

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
