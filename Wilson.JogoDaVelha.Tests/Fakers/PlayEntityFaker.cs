using Bogus;
using WIlson.JogoDaVelha.Domain.Contracts.Play;
using WIlson.JogoDaVelha.Domain.Entities;
using WIlson.JogoDaVelha.Domain.Enums;

namespace Wilson.JogoDaVelha.Tests.Fakers;

public static class PlayEntityFaker
{
    private static readonly Faker Fake = new Faker();
    
    public static int GetId()
    {
        return Fake.IndexGlobal;
    }

    public static async Task<IEnumerable<PlayEntity>> PlayEntityAsync()
    {
        var repository = new List<PlayEntity>();

        for (int i = 0; i < 9; i++)
        {
            repository.Add(new PlayEntity()
            {
                Id = i,
                GameId = Fake.Random.Number(1,9),
                PlayerId = Fake.Random.Number(1,2),
                Symbol = Fake.PickRandom<PlaySymbolEnum>(),
                Position = Fake.Random.Number(1,3).ToString() + "," + Fake.Random.Number(1,3).ToString(),
                CreatedAt = DateTime.Now
            });
        }

        return repository;
    }
    
    public static async Task<PlayEntity> PlayEntityAsync(int id,int gameId)
    {
        return new PlayEntity()
        {
            Id = id,
            GameId = gameId,
            PlayerId = Fake.Random.Number(1,2),
            Symbol = Fake.PickRandom<PlaySymbolEnum>(),
            Position = Fake.Random.Number(1,3).ToString() + "," + Fake.Random.Number(1,3).ToString()
            
        };
    }
    
    public static PlayEntity PlayEntity()
    {
        return new PlayEntity()
        {
            GameId = Fake.Random.Number(1,9),
            PlayerId = Fake.Random.Number(1,2),
            Symbol = Fake.PickRandom<PlaySymbolEnum>(),
            Position = Fake.Random.Number(1,3).ToString() + "," + Fake.Random.Number(1,3).ToString(),
        };
    }

    

    
}