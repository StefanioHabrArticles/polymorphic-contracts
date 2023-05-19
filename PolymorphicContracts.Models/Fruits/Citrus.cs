namespace PolymorphicContracts.Models.Fruits;

[JsonDerivedType(typeof(Citrus), typeDiscriminator: 1)]
public record Citrus : Fruit
{
    public CitrusType Type { get; set; }
}

public enum CitrusType
{
    Lemon,
    Orange,
    Lime
}