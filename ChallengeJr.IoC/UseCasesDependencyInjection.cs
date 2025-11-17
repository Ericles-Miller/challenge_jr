using ChallengeJr.Application.Interfaces;
using ChallengeJr.Application.Mappings;
using ChallengeJr.Application.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace ChallengeJr.IoC;

public static class UseCasesDependencyInjection
{
    public static IServiceCollection AddAppUseCases(this IServiceCollection services)
    {
        services.AddScoped<IProductUseCase, ProductUseCase>();
        
        // AutoMapper
        services.AddAutoMapper(typeof(AppMappings));
        
        return services;
    }
}
