using FluentValidation;
using FluentValidation.AspNetCore;
using ListRace.BL.Services.Abstractions;
using ListRace.BL.Services.Concretes;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ListRace.BL;

public static class ConfigurationServices
{
    public static void AddBLService(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();

        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IPlaceService, PlaceService>();
    }
}
