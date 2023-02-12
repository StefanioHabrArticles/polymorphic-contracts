namespace PolymorphicContracts.Models.Fruits;

public record Apple : Fruit
{
    public AppleColor Color { get; set; }
}

public enum AppleColor
{
    Red,
    Gold,
    Yellow,
    Green
}