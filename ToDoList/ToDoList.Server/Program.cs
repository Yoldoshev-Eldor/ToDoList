
using ToDoList.Server.Configurations;
using ToDoList.Server.Controllers;  
using ToDoList.Server.Filters;
using ToDoList.Server.Middlewares;
using ToDoList.Service.Services;

namespace ToDoList.Server;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.ConfigureSerilog();

        builder.Services.AddControllers(options =>
        {
            options.Filters.Add<ApiExceptionFilterAttribute>();
            options.Filters.Add<ToDoListCountHeaderFilter>();
        });

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Configure();
        builder.ConfigureDatabase();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
            });
        });


        var app = builder.Build();

        app.UseMiddleware<RequestDurationMiddleware>();

        //app.Use(async (context, next) =>
        //{

        //    await next();
        //});

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.UseCors("AllowAll");

        app.MapControllers();

        app.Run();
    }
}
