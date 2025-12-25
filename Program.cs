using Cardle.Components;
using Cardle.Services;
using Cardle.Data;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

using System;
using System.IO;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);

// ===============================
// SQLITE ABSOLUTE PATH + I/O SAFE
// ===============================
var contentRoot = builder.Environment.ContentRootPath;
var dataDir = Path.Combine(contentRoot, "App_Data");
Directory.CreateDirectory(dataDir);

var dbPath = Path.Combine(dataDir, "cardle.db");

// ===============================
// SERVICES
// ===============================
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<GameService>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite($"Data Source={dbPath}");
});

var app = builder.Build();

// ===============================
// PIPELINE
// ===============================
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery();
app.UseStaticFiles();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// ===============================
// SAFE DB INIT + SEED
// ===============================
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();

    if (!context.Cars.Any())
    {
        DataSeeder.SeedAsync(
            context,
            app.Environment.WebRootPath
        ).GetAwaiter().GetResult();
    }
}

app.Run();