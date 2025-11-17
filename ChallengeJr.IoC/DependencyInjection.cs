using ChallengeJr.Application.Mappings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChallengeJr.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration,
        bool isDevelopment)
    {
        // Adicionar configurações de infraestrutura
        services.AddDatabaseConnection(configuration, isDevelopment);
        services.AddInfraServices();
        services.AddRepositories();
        
        return services;
    }
    
    public static IServiceCollection AddAutoMapperConfig(this IServiceCollection services)
    {
        // Configurar AutoMapper
        services.AddAutoMapper(typeof(AppMappings));
        
        return services;
    }
    
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        // Registrar casos de uso da camada Application
        services.AddAppUseCases();
        
        return services;
    }
    
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        // Serviços adicionais da aplicação
        return services;
    }
}
