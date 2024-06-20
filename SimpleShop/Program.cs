using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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

app.MapPost("/Client",
    (IClientServices clientServices, [FromBody] ClientAddRequest clientAddRequest) =>
    {
        clientServices.AddClientAsync(clientAddRequest);
        return Results.Ok();
    });

app.MapGet("/Client", (IClientServices clientServices, [FromHeader] string dni) =>
{
    var client = clientServices.GetClientAsync(dni);
    Results.Ok(client);
});

app.MapPut("/Client",
    (IClientServices clientServices, [FromHeader] Guid id, [FromBody] ClientUpdateRequest clientUpdateRequest) =>
    {
        var client = clientServices.UpdateClientAsync(clientUpdateRequest);
        Results.Ok(client);
    });
app.MapPost("/Item",
    (IItemsServices itemsServices, [FromBody] List<ItemAddRequest> itemAddRequest) =>
    {
        itemsServices.AddItemsAsync(itemAddRequest);
        Results.Ok();
    });
app.MapPut("/Item",
    (IItemsServices itemsServices, [FromHeader] Guid id, [FromBody] ItemUpdateRequest itemUpdateRequest) =>
    {
        var item = itemsServices.UpdateItem(id,itemUpdateRequest);
        Results.Ok(item);
    });
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.Run();