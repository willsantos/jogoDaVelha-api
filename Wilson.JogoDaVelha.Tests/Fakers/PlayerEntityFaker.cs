using Bogus;
using WIlson.JogoDaVelha.Domain.Entities;

namespace Wilson.JogoDaVelha.Tests.Fakers;

public class PlayerEntityFaker
{
    private static readonly Faker Fake = new Faker();
    
    public static int GetId()
    {
        return Fake.IndexFaker;
    }
    
    public static async Task<IEnumerable<PlayerEntity>> PlayerEntityAsync()
    {
        var repository = new List<PlayerEntity>();

        for (int i = 0; i < 9; i++)
        {
            repository.Add(new PlayerEntity()
            {
                Id = i,
                Name = Fake.Name.FirstName(),
                Password = Fake.Random.Word(),
                CreatedAt = Fake.Date.Recent(),
                UpdateAt = Fake.Date.Recent()

            });
        }

        return repository;
    }
    
    public static async Task<PlayerEntity> PlayerEntityAsync(int id)
    {
        return new PlayerEntity()
        {
            Id = id,
            Name = Fake.Name.FirstName(),
            Password = Fake.Random.Word(),
            CreatedAt = Fake.Date.Recent(),
            UpdateAt = Fake.Date.Recent()
            
        };
    }
    
    public static PlayerEntity PlayerEntity()
    {
        return new PlayerEntity()
        {
            Name = Fake.Name.FirstName(),
            Password = Fake.Random.Word(),
            CreatedAt = Fake.Date.Recent(),
            UpdateAt = Fake.Date.Recent()

        };
    }
    
}