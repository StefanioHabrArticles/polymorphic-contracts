namespace PolymorphicContracts.Models.Fruits;

[JsonDerivedType(typeof(Grape), typeDiscriminator: 2)]
public record Grape : Fruit
{
    public bool Seed { get; set; }
}