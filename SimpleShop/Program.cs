using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleShop;
using SimpleShop.Context;
using SimpleShop.Context.Repositories;
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
builder.Services.AddTransient<IClientRepository, ClientRepository>();
builder.Services.AddTransient<IItemRepository, ItemRepository>();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapPost("/Client",
    async (IClientServices clientServices, [FromBody] ClientAddRequest clientAddRequest) =>
    {
        await clientServices.AddClientAsync(clientAddRequest);
        return Results.Ok();
    });

app.MapGet("/Client", async (IClientServices clientServices, [FromHeader] string dni) =>
{
    var client = await clientServices.GetClientAsync(dni);
    return Results.Ok(client);
});

app.MapPut("/Client",
    async (IClientServices clientServices, [FromHeader] Guid id, [FromBody] ClientUpdateRequest clientUpdateRequest) =>
    {
        var client = await clientServices.UpdateClientAsync(clientUpdateRequest);
        return Results.Ok(client);
    });
app.MapPost("/Item",
    async (IItemsServices itemsServices, [FromBody] List<ItemAddRequest> itemAddRequest) =>
    {
        await itemsServices.AddItemsAsync(itemAddRequest);
        return Results.Ok();
    });

app.MapDelete("/Item",
    async (IItemsServices itemsServices, [FromHeader] Guid id) =>
    {
        await itemsServices.RemoveItemAsync(id);
        return Results.Ok();
    });
app.MapPut("/Item",
    async (IItemsServices itemsServices, [FromHeader] Guid id, [FromBody] ItemUpdateRequest itemUpdateRequest) =>
    {
        var item = await itemsServices.UpdateItem(id, itemUpdateRequest);
        return Results.Ok(item);
    });
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.Migrations();
}

app.UseHttpsRedirection();
app.Run();