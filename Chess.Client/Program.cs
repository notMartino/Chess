using Chess.Application.Mapper;
using Chess.Application.Services.Implementation;
using Chess.Application.Services.Implementations;
using Chess.Application.Services.Interfaces;
using Chess.Infrastructure.DAL;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// AppSettings
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

string connectionString = builder.Configuration.GetConnectionString("ChessDB");
string cookiesSchemeName = builder.Configuration.GetValue<string>("CookiesScheme");

// EF Context
builder.Services.AddDbContext<ChessContext>(options => 
    options.UseSqlServer(connectionString)
);

//Authetication (via Cookies)
builder.Services.AddAuthentication()
    .AddCookie(cookiesSchemeName, options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);

        options.Cookie.Name = cookiesSchemeName;
        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = builder.Environment.IsDevelopment()
            ? CookieSecurePolicy.Always : CookieSecurePolicy.Always;
        //options.Cookie.Path = "/";

        options.ReturnUrlParameter = "loginModal";
        options.LoginPath = "/";
        options.AccessDeniedPath = "/Home/AccessDenied";
        options.LogoutPath = "/";
    });

// Authorization
builder.Services.AddAuthorization();

// Mapster
builder.Services.AddMappings();

//Unit of Work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Services DAL
builder.Services.AddScoped<IMapService>(x => new MapService(
                    x.GetRequiredService<IUnitOfWork>(),
                    x.GetRequiredService<IMapper>()
                ));
builder.Services.AddScoped<IBoxService>(x => new BoxService(
                    x.GetRequiredService<IUnitOfWork>(),
                    x.GetRequiredService<IMapper>() 
                ));


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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
