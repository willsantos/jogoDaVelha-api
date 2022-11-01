using Bogus;
using WIlson.JogoDaVelha.Domain.Entities;
using WIlson.JogoDaVelha.Domain.Enums;

namespace Wilson.JogoDaVelha.Tests.Fakers;

public class GameEntityFaker
{
    private static readonly Faker Fake = new Faker();
    
    public static int GetId()
    {
        return Fake.Random.Number(1,9);
    }
    
    public static async Task<IEnumerable<GameEntity>> GameEntityAsync()
    {
        var repository = new List<GameEntity>();

        for (int i = 0; i < 9; i++)
        {
            repository.Add(new GameEntity()
            {
                Id = i,
                Date = Fake.Date.Recent(),
                CreatedAt = Fake.Date.Recent(),
                UpdateAt = Fake.Date.Recent(),
                PlayerA = 1,
                PlayerB = 2,
                Status = Fake.PickRandom<GameStatusEnum>()
            });
        }

        return repository;
    }
    
    public static async Task<GameEntity> GameEntityAsync(int id)
    {
        return new GameEntity()
        {
            Id = id,
            Date = Fake.Date.Recent(),
            CreatedAt = Fake.Date.Recent(),
            UpdateAt = Fake.Date.Recent(),
            PlayerA = 1,
            PlayerB = 2,
            Status = GameStatusEnum.Preparing
            
        };
    }
    
    public static GameEntity GameEntity()
    {
        return new GameEntity()
        {
            Date = Fake.Date.Recent(),
            CreatedAt = Fake.Date.Recent(),
            UpdateAt = Fake.Date.Recent(),
            PlayerA = 1,
            PlayerB = 2,
            Status = GameStatusEnum.Preparing
        };
    }
}