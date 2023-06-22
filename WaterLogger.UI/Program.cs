using Microsoft.EntityFrameworkCore;
using WaterLogger.DataAccess;
using WaterLogger.DataAccess.UnitOfWork;
using WaterLogger.Domain.Abstraction.Services;
using WaterLogger.Domain.Abstraction.UnitOfWork;
using WaterLogger.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<WaterLoggerDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("WaterLoggerDb")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IWaterService, WaterService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();