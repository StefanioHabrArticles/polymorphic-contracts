using System.Text.Json.Serialization;
using MediatR;
using PolymorphicContracts.Models.Fruits;

namespace PolymorphicContracts.Handlers.CreateFruit;

[JsonDerivedType(typeof(CreateAppleRequest), typeDiscriminator: nameof(CreateAppleRequest))]
[JsonDerivedType(typeof(CreateCitrusRequest), typeDiscriminator: nameof(CreateCitrusRequest))]
[JsonDerivedType(typeof(CreateGrapeRequest), typeDiscriminator: nameof(CreateGrapeRequest))]
public abstract record CreateFruitRequest : IRequest<Fruit>;