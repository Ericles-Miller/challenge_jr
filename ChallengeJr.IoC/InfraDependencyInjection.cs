using ChallengeJr.Domain.Interfaces.Repositories;
using ChallengeJr.Infra.Data.Contexts;
using ChallengeJr.Infra.Data.Repositories.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChallengeJr.IoC;

public static class InfraDependencyInjection
{
    public static IServiceCollection AddDatabaseConnection(
        this IServiceCollection services,
        IConfiguration configuration,
        bool isDevelopment)
    {
        // Configuração do Entity Framework Core
        var connectionString = isDevelopment
            ? configuration.GetConnectionString("DefaultConnection")
            : configuration.GetConnectionString("DefaultConnection");
        
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString));

        return services;
    }

    public static IServiceCollection AddInfraServices(this IServiceCollection services)
    {
        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        
        return services;
    }
}

