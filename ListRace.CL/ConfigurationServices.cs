using ListRace.Core.Models;
using ListRace.DL.Repository.Abstractions;
using ListRace.DL.Repository.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace ListRace.DL;

public static class ConfigurationServices
{
    public static void AddDLService(this IServiceCollection services)
    {
        services.AddScoped<IRepository<Place>, Repository<Place>>();
        services.AddScoped<IRepository<Category>, Repository<Category>>();
    }
}
