namespace PolymorphicContracts.Models.Fruits;

[JsonDerivedType(typeof(Apple), typeDiscriminator: 0)]
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