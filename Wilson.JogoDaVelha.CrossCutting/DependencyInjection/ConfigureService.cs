using Microsoft.Extensions.DependencyInjection;
using WIlson.JogoDaVelha.Domain.Interfaces.Services;
using Wilson.JogoDavelha.Services;

namespace Wilson.JogoDaVelha.CrossCutting.DependencyInjection;

public static class ConfigureService
{
    public static void ConfigureDependenciesService(IServiceCollection serviceColletion)
    {
        serviceColletion.AddScoped<IGameService, GameService>();
        serviceColletion.AddScoped<IPlayerService, PlayerService>();

    }
    
}