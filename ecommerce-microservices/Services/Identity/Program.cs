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

        //admin memory dbde tutulabilir
        builder.Services.AddDbContext<AppIdentityDbContext>(options =>
            options.UseInMemoryDatabase("IdentityDb"));


        builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<AppIdentityDbContext>()
            .AddDefaultTokenProviders();
        builder.Services.AddControllers();
        builder.Services.AddAuthentication();
        builder.Services.AddAuthorization();
        builder.Services.AddScoped<TokenService>();
        var app = builder.Build();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers(); 
        app.Run();

    }
}
