using MobileShop.API.Data;
using Microsoft.EntityFrameworkCore;
using MobileShop.API.Implementantions.Interfaces;
using MobileShop.API.Implementantions.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MobileShopDbContex>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("MobileShopConnectionString")));
builder.Services.AddTransient<IUserInterface,UserServices>();
builder.Services.AddTransient<IDeviceInterface, DeviceServices>();
//builder.Services.AddTransient<IDe,UserServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
