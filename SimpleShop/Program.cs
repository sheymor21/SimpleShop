using Microsoft.EntityFrameworkCore;
using SimpleShop.Context;
using SimpleShop.DTO;
using SimpleShop.Interfaces;
using SimpleShop.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<DatabaseContext>(options => { options.UseSqlite("Data Source=DatabaseShop.db"); });
builder.Services.AddScoped<IItemsServices, ItemsServices>();
builder.Services.AddScoped<IClientServices, ClientServices>();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.Run();