using System.Text.Json.Serialization;

namespace PolymorphicContracts.Models.Animals;

[JsonDerivedType(typeof(Cat), nameof(Cat))]
[JsonDerivedType(typeof(Dog), nameof(Dog))]
public abstract record Animal;