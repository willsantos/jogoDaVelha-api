using AutoMapper;
using Moq;
using WIlson.JogoDaVelha.Domain.Entities;
using WIlson.JogoDaVelha.Domain.Interfaces.Repositories;
using Wilson.JogoDavelha.Services;
using Wilson.JogoDaVelha.Tests.CrossCutting;
using Wilson.JogoDaVelha.Tests.Fakers;

namespace Wilson.JogoDaVelha.Tests.Services;

[Trait("PlayService", "Testa as jogadas")]
public class PlayServiceTest
{
    private readonly Mock<IPlayRepository> _playRepositoryMock = new Mock<IPlayRepository>();
    private readonly Mock<IGameRepository> _gameRepositoryMock = new Mock<IGameRepository>();
    private IMapper _mapper = new AutoMapperFixture().GetMapper();
    
    
    [Fact(DisplayName = "Tenta fazer uma jogada valida")]
    public async Task Post ()
    {
        int gameId = GameEntityFaker.GetId();
        var playRequest = PlayContractFaker.PlayRequest(gameId);
        var resultPlayRequest = PlayEntityFaker.PlayEntityAsync(playRequest.PlayerId,gameId);


        var resultGameRepository = GameEntityFaker.GameEntityAsync(gameId);
        _gameRepositoryMock.Setup(mock => mock.GetById(gameId)).Returns(resultGameRepository);
        var gameService = new GameService(_gameRepositoryMock.Object, null, _mapper);
        
       
        
        _playRepositoryMock.Setup(mock => mock.Post(It.IsAny<PlayEntity>())).Returns(resultPlayRequest);
        
        
        var playService = new PlayService(_playRepositoryMock.Object,gameService, _mapper);
        var result = await playService.Post(playRequest);
        
        Assert.Equal(result.PlayerId,resultPlayRequest.Result.PlayerId);
        
       
        
    }
}