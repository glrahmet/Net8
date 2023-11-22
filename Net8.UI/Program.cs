using Net8.Data.Context;
using Net8.UI.Injections;
using Net8.UI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<Net8Context>(_ => _.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), option =>
{

}));


builder.Services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .AddRazorRuntimeCompilation();
builder.Services.AddControllers()
               .AddJsonOptions(o => o.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddSingleton(MapperInjection.Initialize());
ServiceInjection.Initialize(builder.Services, builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseStatusCodePagesWithReExecute("/Sonuc/ErisimYok");

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<HttpLoggingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
