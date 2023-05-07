using Microsoft.EntityFrameworkCore;
using WHSAPI;
using WHSAPI.Context;
using WHSAPI.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<WHSDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("WHSConnection")
    ));
builder.Services.AddDbContext<ITCompanyDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("MainDbConnection")
    ));

builder.Services.AddAutoMapper(config => config.AddProfile<MapperProfile>());
builder.Services.AddScoped<IWHSService, WHSService>();
builder.Services.AddScoped<IITCompanyDBService, ITCompanyDBService>();

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

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.Run();