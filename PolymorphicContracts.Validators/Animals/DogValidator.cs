using FluentValidation;
using PolymorphicContracts.Models.Animals;

namespace PolymorphicContracts.Validators.Animals;

public class DogValidator : AbstractValidator<Dog>
{
    public DogValidator()
    {
        RuleFor(x => x.Bark)
            .Equal(true);
    }
}