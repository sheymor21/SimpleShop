using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop.Infrastructure;
using SimpleShop;
using SimpleShop.Context;
using SimpleShop.Context.Repositories;
using SimpleShop.DTO;
using SimpleShop.Interfaces;
using SimpleShop.Services;
using SimpleShop.Validations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<DatabaseContext>(options => { options.UseSqlite("Data Source=DatabaseShop.db"); });
builder.Services.AddScoped<IItemsServices, ItemsServices>();
builder.Services.AddScoped<IClientServices, ClientServices>();
builder.Services.AddScoped<IClientValidation, ClientValidations>();
builder.Services.AddScoped<IItemValidations, ItemValidation>();
builder.Services.AddTransient<IClientRepository, ClientRepository>();
builder.Services.AddTransient<IItemRepository, ItemRepository>();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapPost("/Client",
    async (IClientServices clientServices, IClientValidation clientValidation,
        [FromBody] ClientDto.AddRequest clientAddRequest) =>
    {
        if (await clientValidation.AnyClientByDni(clientAddRequest.Dni))
        {
            return Results.BadRequest("This client is already registered");
        }

        await clientServices.AddClientAsync(clientAddRequest);
        return Results.Ok();
    });

app.MapGet("/Client",
    async (IClientServices clientServices, IClientValidation clientValidation, [FromHeader] string dni) =>
    {
        if (!await clientValidation.AnyClientByDni(dni))
        {
            return Results.BadRequest("This client isn't registered");
        }

        var client = await clientServices.GetClientAsync(dni);
        return Results.Ok(client);
    });

app.MapPut("/Client",
    async (IClientServices clientServices, IClientValidation clientValidation, [FromHeader] string dni,
        [FromBody] ClientDto.UpdateRequest clientUpdateRequest) =>
    {
        if (!await clientValidation.AnyClientByDni(dni))
        {
            return Results.BadRequest("This client isn't registered");
        }

        var client = await clientServices.UpdateClientAsync(clientUpdateRequest, dni);
        return Results.Ok(client);
    });

app.MapPost("/Item",
    async (IClientValidation clientValidation, IItemsServices itemsServices,
        [FromBody] List<ItemDto.AddRequest> itemAddRequest) =>
    {
        foreach (var item in itemAddRequest.Select(x => x.ClientDni))
        {
            if (!await clientValidation.AnyClientByDni(item))
            {
                return Results.BadRequest($"The clients dni:{item} isn't registered");
            }
        }

        await itemsServices.AddItemsAsync(itemAddRequest);
        return Results.Ok();
    });

app.MapDelete("/Item",
    async (IItemsServices itemsServices, IItemValidations itemValidations, [FromHeader] Guid id) =>
    {
        if (!await itemValidations.AnyById(id))
        {
            return Results.NotFound("This item isn't registered");
        }

        await itemsServices.RemoveItemAsync(id);
        return Results.Ok();
    });
app.MapPut("/Item",
    async (IItemsServices itemsServices, IItemValidations itemValidations, [FromHeader] Guid id,
        [FromBody] ItemDto.UpdateRequest itemUpdateRequest) =>
    {
        if (!await itemValidations.AnyById(id))
        {
            return Results.NotFound("This item isn't registered");
        }

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