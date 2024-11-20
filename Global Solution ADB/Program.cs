using Global_Solution_ADB.Infraestructure;
using Global_Solution_ADB.Repositories.Interfaces;
using Global_Solution_ADB.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using Global_Solution_ADB.Application.Services;
using Global_Solution_ADB.Models.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("FiapOracleConnection")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<INuclearPlantRepository, NuclearPlantRepository>();
builder.Services.AddScoped<IMetricRepository, MetricRepository>();
builder.Services.AddScoped<ISensorRepository, SensorRepository>();
builder.Services.AddScoped<ISensorTypeRepository, SensorTypeRepository>();
builder.Services.AddScoped<IAnalysisRepository, AnalysisRepository>();
builder.Services.AddScoped<IAlertRepository, AlertRepository>();

builder.Services.AddScoped<NuclearPlantService>();
builder.Services.AddScoped<MetricService>();
builder.Services.AddScoped<SensorService>();
builder.Services.AddScoped<SensorTypeService>();
builder.Services.AddScoped<AnalysisService>();
builder.Services.AddScoped<AlertService>();


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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
