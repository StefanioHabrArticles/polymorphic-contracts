namespace PolymorphicContracts.Models.Models.Animals;

public record Cat : Animal
{
    public bool Meow { get; set; } = true;
}