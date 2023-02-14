using System.Text.Json.Serialization;

namespace PolymorphicContracts.Models.Fruits;

[JsonDerivedType(typeof(Apple), typeDiscriminator: 0)]
[JsonDerivedType(typeof(Citrus), typeDiscriminator: 1)]
[JsonDerivedType(typeof(Grape), typeDiscriminator: 2)]
public abstract record Fruit;