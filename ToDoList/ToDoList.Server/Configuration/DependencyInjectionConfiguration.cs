using ToDoList.Repository.Services;
using ToDoList.Service.Services;

namespace ToDoList.Server.Configuration;

public static class DependencyInjectionConfiguration
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IToDoItemRepository, ToDoItemRepository>();
        services.AddScoped<IToDoItemService, ToDoItemService>();
        
    }
}
