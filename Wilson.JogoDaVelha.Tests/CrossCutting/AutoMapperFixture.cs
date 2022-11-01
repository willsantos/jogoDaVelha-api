using AutoMapper;
using Wilson.JogoDaVelha.CrossCutting.Mappers;

namespace Wilson.JogoDaVelha.Tests.CrossCutting;

public abstract class BaseAutoMapperFixture
{
    public IMapper mapper { get; set; }

    public BaseAutoMapperFixture()
    {
        mapper = new AutoMapperFixture().GetMapper();
    }
}

public class AutoMapperFixture : IDisposable
{
    public IMapper GetMapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new GameEntityToContractMap());
            cfg.AddProfile(new PlayerEntityToContractMap());
            cfg.AddProfile(new PlayEntityToContractMap());
        });

        return config.CreateMapper();
    }

    public void Dispose()
    {
    }
}