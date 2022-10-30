using Microsoft.Extensions.DependencyInjection;
using Wilson.JogoDaVelha.CrossCutting.DependencyInjection;

namespace Wilson.JogoDaVelha.IoC;

public static class NativeInjectorBootStrapper
{
    public static void RegisterAppDependencies(this IServiceCollection service)
    {
        ConfigureService.ConfigureDependenciesService(service);
        ConfigureMappers.ConfigureDependenciesMapper(service);
    }

    public static void RegisterAppDependenciesContext(this IServiceCollection services, string connectionString)
    {
        ConfigureRepository.ConfigureDependenciesRepository(services,connectionString);
    }
}