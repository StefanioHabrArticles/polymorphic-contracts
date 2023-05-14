using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using AutoFixture;
using AutoFixture.Kernel;
using BenchmarkDotNet.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using PolymorphicContracts.Models.Fruits;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace PolymorphicContracts.Benchmark;

[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
public class SystemVsNewtonsoft
{
    private readonly Fruit _fruit;
    private readonly List<Fruit> _fruits;

    private readonly JsonSerializerSettings _newtonsoftSettings = new()
    {
        ContractResolver = new DefaultContractResolver
            { NamingStrategy = new CamelCaseNamingStrategy() },
        Converters = { new StringEnumConverter() },
        TypeNameHandling = TypeNameHandling.All,
        Formatting = Formatting.Indented
    };

    private readonly JsonSerializerOptions _systemOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true,
        Converters = { new JsonStringEnumConverter() }
    };

    public SystemVsNewtonsoft()
    {
        var fixture = new Fixture();
        fixture.Customizations.Add(
            new FilteringSpecimenBuilder(
                new RandomRelayCustomization(builders:
                    new ISpecimenBuilder[]
                    {
                        new TypeRelay(typeof(Fruit), typeof(Apple)),
                        new TypeRelay(typeof(Fruit), typeof(Citrus)),
                        new TypeRelay(typeof(Fruit), typeof(Grape))
                    }
                ),
                new ExactTypeSpecification(typeof(Fruit))
            )
        );

        _fruits = fixture.CreateMany<Fruit>(30000).ToList();
        _fruit = fixture.Create<Fruit>();
    }

    [Benchmark]
    public string SerializeSystem() =>
        JsonSerializer.Serialize(_fruit, _systemOptions);

    [Benchmark]
    public string SerializeNewtonsoft() =>
        JsonConvert.SerializeObject(_fruit, _newtonsoftSettings);

    [Benchmark]
    public string SerializeListSystem() =>
        JsonSerializer.Serialize(_fruits, _systemOptions);

    [Benchmark]
    public string SerializeListNewtonsoft() =>
        JsonConvert.SerializeObject(_fruits, _newtonsoftSettings);

    [Benchmark]
    public Fruit DeserializeSystem() =>
        JsonSerializer.Deserialize<Fruit>(SerializeSystem(), _systemOptions)!;

    [Benchmark]
    public Fruit DeserializeNewtonsoft() =>
        JsonConvert.DeserializeObject<Fruit>(SerializeNewtonsoft(), _newtonsoftSettings)!;

    [Benchmark]
    public List<Fruit> DeserializeListSystem() =>
        JsonSerializer.Deserialize<List<Fruit>>(SerializeListSystem(), _systemOptions)!;

    [Benchmark]
    public List<Fruit> DeserializeListNewtonsoft() =>
        JsonConvert.DeserializeObject<List<Fruit>>(SerializeListNewtonsoft(), _newtonsoftSettings)!;

}