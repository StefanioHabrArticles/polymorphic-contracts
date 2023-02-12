using System.Text.Json.Serialization;

namespace PolymorphicContracts.Models.Fruits;

[JsonDerivedType(typeof(Apple), 0)]
[JsonDerivedType(typeof(Citrus), 1)]
[JsonDerivedType(typeof(Grape), 2)]
public abstract record Fruit;