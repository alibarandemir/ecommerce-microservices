using Identity.Data;
using Identity.Models;
using Identity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddDbContext<AppIdentityDbContext>(options =>
            options.UseInMemoryDatabase("IdentityDb"));


        builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<AppIdentityDbContext>()
            .AddDefaultTokenProviders();
        builder.Services.AddControllers();
        builder.Services.AddAuthentication();
        builder.Services.AddAuthorization();
        //DI
        builder.Services.AddScoped<TokenService>();

        var app = builder.Build();
        //  Admin kullanýcýyý oluþtur
       

        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers(); // BUNU DA EKLE

        app.Run();

    }
}
