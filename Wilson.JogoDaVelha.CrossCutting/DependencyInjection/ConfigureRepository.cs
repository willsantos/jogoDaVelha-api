﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WIlson.JogoDaVelha.Domain.Interfaces.Repositories;
using Wilson.JogoDaVelha.Repository;

namespace Wilson.JogoDaVelha.CrossCutting.DependencyInjection;

public static class ConfigureRepository
{
    public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection,string connectionString)
    {
        serviceCollection.AddScoped<IGameRepository, GameRepository>();
        serviceCollection.AddScoped<IPlayerRepository, PlayerRepository>();
        serviceCollection.AddScoped<IPlayRepository, PlayRepository>();
        serviceCollection.AddDbContext<ApiDbContext>(options => options.UseSqlServer(connectionString));
    }
}