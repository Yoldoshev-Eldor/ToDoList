using Microsoft.EntityFrameworkCore;
using ToDoList.DataAccess;

namespace ToDoList.Server.Configurations;


public static class DataBaseConfiguration
{
    public static void ConfigureDatabase(this WebApplicationBuilder builder)
    {
        var connectionConfiguration = builder.Configuration.GetConnectionString("DatabaseConnection");

        builder.Services.AddDbContext<MainContext>(options => options.UseSqlServer(connectionConfiguration));
    }
}