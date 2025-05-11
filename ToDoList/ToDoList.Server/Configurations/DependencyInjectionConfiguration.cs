using FluentValidation;
using ToDoList.Repository.Services;
using ToDoList.Service.Dtos;
using ToDoList.Service.MappingProfile;
using ToDoList.Service.Services;
using ToDoList.Service.Services.Security;
using ToDoList.Service.Validators;

namespace ToDoList.Server.Configurations;

public static class DependencyInjectionConfiguration
{
    public static void Configure(this WebApplicationBuilder builder)
    {
        //builder.Services.AddScoped<IToDoItemRepository, AdoNetWithSpAndFn>();
        builder.Services.AddScoped<IToDoListRepository, ToDoListRepository>();
        builder.Services.AddScoped<IToDoListService, ToDoListService>();    
        
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();

        builder.Services.AddScoped<ITokenService, TokenService>();

        builder.Services.AddScoped<ValidatorCreateDto, ValidatorCreateDto>();
        builder.Services.AddScoped<ValidatorUpdateDto, ValidatorUpdateDto>();

        builder.Services.AddScoped<IValidator<ToDoItemCreatDto>, ValidatorCreateDto>();
        builder.Services.AddScoped<IValidator<ToDoItemUpdateDto>, ValidatorUpdateDto>();

        builder.Services.AddAutoMapper(typeof(MappingProFile));
        //builder.Services.AddLogging();



    }
}
