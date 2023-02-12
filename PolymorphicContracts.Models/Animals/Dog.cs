namespace PolymorphicContracts.Models.Animals;

public record Dog : Animal
{
    public bool Bark { get; set; } = true;
}