namespace PolymorphicContracts.Models.Models.Fruits;

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