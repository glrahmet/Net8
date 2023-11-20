using Application.Feature.CQRS.Handlers.AboutHandlers;
using Application.Feature.CQRS.Handlers.BannerHandlers;
using Application.Feature.CQRS.Handlers.BrandHandlers;
using Application.Feature.CQRS.Handlers.CarHandlers;
using Application.Feature.CQRS.Queries.BannerQueries;
using Application.Interfaces;
using Persistence.Context;
using Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<Net8Context>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddScoped<GetAboutByIdCommandHandler>();
builder.Services.AddScoped<GetAboutQueryCommandHandler>();
builder.Services.AddScoped<UpdateAboutCommandHandler>();
builder.Services.AddScoped<RemoveAboutCommandHandler>();
builder.Services.AddScoped<CreateAboutCommandHandler>();

builder.Services.AddScoped<GetBrandByIdCommandHandler>();
builder.Services.AddScoped<GetBrandCommandHandler>();
builder.Services.AddScoped<UpdateBrandCommandHandler>();
builder.Services.AddScoped<RemoveBrandCommandHandler>();
builder.Services.AddScoped<CreateBrandCommandHandler>();

builder.Services.AddScoped<GetBannerByIdQueryHandler>();
builder.Services.AddScoped<GetBannerQueryHandler>();
builder.Services.AddScoped<UpdateBannerCommandHandler>();
builder.Services.AddScoped<RemoveBannerCommandHandler>();
builder.Services.AddScoped<CreateBannerCommandHandler>();

builder.Services.AddScoped<GetCarByIdCommandHandler>();
builder.Services.AddScoped<GetCarCommandHandler>();
builder.Services.AddScoped<UpdateCarCommandHandler>();
builder.Services.AddScoped<RemoveCarCommandHandler>();
builder.Services.AddScoped<CreateCarCommandHandler>();
builder.Services.AddScoped<GetCarWithBrandQueryHandler>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
