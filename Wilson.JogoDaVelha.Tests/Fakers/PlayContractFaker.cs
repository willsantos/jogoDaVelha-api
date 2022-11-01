using Bogus;
using WIlson.JogoDaVelha.Domain.Contracts.Play;
using WIlson.JogoDaVelha.Domain.Enums;

namespace Wilson.JogoDaVelha.Tests.Fakers;

public class PlayContractFaker
{
    private static readonly Faker Fake = new Faker();

    public static int GetId()
    {
        return Fake.IndexFaker;
    }

    
    public static async Task<IEnumerable<PlayResponse>> PlayResponseAsync()
    {
        var response = new List<PlayResponse>();

        for (int i = 0; i < 5; i++)
        {
            response.Add(new PlayResponse()
            {
                Id = i,
                GameId = Fake.IndexFaker,
                PlayerId = Fake.IndexFaker,
                Symbol = Fake.PickRandom<PlaySymbolEnum>(),
                Position = Fake.Random.Number(1,3).ToString() + "," + Fake.Random.Number(1,3).ToString()
            });
        }

        return response;
    }
    
    public static PlayRequest PlayRequest(int gameId)
    {
        return new PlayRequest
        {
            GameId = gameId,
            PlayerId = Fake.Random.Number(1,2),
            Symbol = Fake.PickRandom<PlaySymbolEnum>(),
            Position = Fake.Random.Number(1,3).ToString() + "," + Fake.Random.Number(1,3).ToString()
        };
    }


    
}