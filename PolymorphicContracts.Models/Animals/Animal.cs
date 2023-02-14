using System.Text.Json.Serialization;

namespace PolymorphicContracts.Models.Animals;

[JsonDerivedType(typeof(Cat), typeDiscriminator: nameof(Cat))]
[JsonDerivedType(typeof(Dog), typeDiscriminator: nameof(Dog))]
public abstract record Animal;