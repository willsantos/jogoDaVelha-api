using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using WIlson.JogoDaVelha.Domain.Contracts.Play;
using WIlson.JogoDaVelha.Domain.Entities;
using WIlson.JogoDaVelha.Domain.Enums;
using WIlson.JogoDaVelha.Domain.Interfaces.Repositories;
using WIlson.JogoDaVelha.Domain.Interfaces.Services;
using Wilson.JogoDaVelha.IoC;
using Wilson.JogoDaVelha.Repository;
using Wilson.JogoDavelha.Services;
using Wilson.JogoDaVelha.Tests.CrossCutting;

namespace Wilson.JogoDaVelha.Tests;

[Trait("Game", "Simula uma partida")]
public class GameIntegrationTest
{
    private readonly IGameRepository _gameRepository;
    private readonly IPlayerRepository _playerRepository;
    private IPlayRepository _playRepository;
    private IGameService _gameService;
    private IPlayService _playService;
    private IPlayerService _playerService;
    private PlayerEntity _mockPlayerA;
    private PlayerEntity _mockPlayerB;
    private GameEntity _mockGame;
    private IMapper _mapper = new AutoMapperFixture().GetMapper();

    
    
    
   


    public GameIntegrationTest()
    {
        //Aqui ainda está bagunçado, sem as injeçoes corretamente
        //mas preciso disso pra agilizar o desenvolvimento
        
        //var serviceCollection = new ServiceCollection();
        // serviceCollection.AddScoped<IGameRepository, GameRepository>();
        // serviceCollection.AddScoped<IPlayRepository, PlayRepository>();
        // serviceCollection.AddScoped<IPlayerRepository, PlayerRepository>();
        //
        // serviceCollection.AddScoped<IGameService, GameService>();
        // serviceCollection.AddScoped<IPlayerService, PlayerService>();
        // serviceCollection.AddScoped<IPlayService, PlayService>();
        // serviceCollection.AddDbContext<ApiDbContext>(
        //     options => options.UseSqlServer(@"Server=127.0.0.1,1439;Database=api_teste_jogoVelha_wilson_santos;User=SA;Password=wd%!r$H7Ez@yuPz*sx*3wUgBcwv;")
        // );
        //ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
        //
        //_gameRepository = serviceProvider.GetRequiredService<IGameRepository>();
         //_playerRepository = serviceProvider.GetRequiredService<IPlayerRepository>();
        // _playRepository = serviceProvider.GetRequiredService<IPlayRepository>();
        //
        // _gameService = serviceProvider.GetRequiredService<IGameService>();
        // _playService = serviceProvider.GetRequiredService<IPlayService>();


        
       
        

         _mockPlayerA = new PlayerEntity
        {
            Name = "Wilson",
            Password = "123456",
            

        };
        
        _mockPlayerB = new PlayerEntity
        {
            Name = "Stella",
            Password = "123456",
            CreatedAt = DateTime.Now
        };
        
        _mockGame = new GameEntity
        {
            Date = DateTime.Now,
            CreatedAt = DateTime.Now,
            PlayerA = 1,
            PlayerB = 2,
            Status = GameStatusEnum.Preparing
        };

        _playerService = new PlayerService(_playerRepository, _mapper);
        _gameService = new GameService(_gameRepository, _playerService, _mapper);

        _playService = new PlayService(_playRepository, _gameService, _mapper);

        
        
        
        



    }
    
    
    [Fact]
    public async void VerificaSePartidaEstaEncerrada()
    {
        //PREPARE
        
        await _playerRepository.Post(_mockPlayerA);
        await _playerRepository.Post(_mockPlayerB);
        var players = await _playerRepository.Get();

        _mockGame.PlayerA = players.FirstOrDefault().Id;
        _mockGame.PlayerB = players.OrderBy(prop => prop.CreatedAt).LastOrDefault().Id;
        await _gameRepository.Post(_mockGame);
        
        
        var plays = mockWinPlaysHorizontal(_mockGame.Id, _mockGame.PlayerA, _mockGame.PlayerB);

        foreach (var play in plays)
        {
            await _playRepository.Post(play);
        }
        //ACT

        try
        {
            
            
            await _playService.Post(new PlayRequest
                { GameId = _mockGame.Id, Symbol = PlaySymbolEnum.X, PlayerId = _mockPlayerB.Id, Position = "3,3" });
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        //Clean

        var playsRemove = await _playRepository.Get();
        foreach (var play in playsRemove)
        {
            await _playRepository.Delete(play.Id);
        }
        await _playerRepository.Delete(_mockPlayerA.Id);
        await _playerRepository.Delete(_mockPlayerB.Id);

        await _gameRepository.Delete(_mockGame.Id);




    }

    private List<PlayEntity> mockWinPlaysHorizontal(int gameId, int playerA,int playerB)
    {
        var mockWinPlay = new List<PlayEntity>();
        
        mockWinPlay.Add(new PlayEntity{GameId = gameId,PlayerId = playerA,Symbol = PlaySymbolEnum.X,CreatedAt = DateTime.Now,Position = "1,1"});
        mockWinPlay.Add(new PlayEntity{GameId = gameId,PlayerId = playerB,Symbol = PlaySymbolEnum.O,CreatedAt = DateTime.Now,Position = "3,1"});
        mockWinPlay.Add(new PlayEntity{GameId = gameId,PlayerId = playerA,Symbol = PlaySymbolEnum.X,CreatedAt = DateTime.Now,Position = "1,2"});
        mockWinPlay.Add(new PlayEntity{GameId = gameId,PlayerId = playerB,Symbol = PlaySymbolEnum.O,CreatedAt = DateTime.Now,Position = "3,2"});
        mockWinPlay.Add(new PlayEntity{GameId = gameId,PlayerId = playerA,Symbol = PlaySymbolEnum.X,CreatedAt = DateTime.Now,Position = "1,3"});

        return mockWinPlay;
    }
}