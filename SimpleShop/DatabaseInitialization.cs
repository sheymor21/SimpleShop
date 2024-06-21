using Microsoft.EntityFrameworkCore;
using SimpleShop.Context;

namespace SimpleShop;

public static class DatabaseInitialization
{
    public static void Migrations(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        serviceScope.ServiceProvider.GetService<DatabaseContext>()?.Database.Migrate();
    }
}