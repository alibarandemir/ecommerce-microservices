using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:3000") // client url
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Ocelot dosyasýnýn okunmasý
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot();

var app = builder.Build();
app.UseCors("AllowFrontend");
app.UseOcelot().Wait();

app.Run();
