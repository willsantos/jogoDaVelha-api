using Microsoft.Extensions.DependencyInjection;
using Wilson.JogoDaVelha.CrossCutting.Mappers;

namespace Wilson.JogoDaVelha.CrossCutting.DependencyInjection;

public static class ConfigureMappers
{
    public static void ConfigureDependenciesMapper(IServiceCollection serviceCollection)
    {
        var config = new AutoMapper.MapperConfiguration(cnf =>
        {
            cnf.AddProfile(new PlayerEntityToContractMap());
            cnf.AddProfile(new GameEntityToContractMap());
            cnf.AddProfile(new PlayEntityToContractMap());
        });

        var mapConfiguration = config.CreateMapper();
        serviceCollection.AddSingleton(mapConfiguration);
    }
}