namespace PolymorphicContracts.Models.Fruits;

public record Grape : Fruit
{
    public bool Seed { get; set; }
}