using FluentValidation;
using PolymorphicContracts.Models.Models.Animals;

namespace PolymorphicContracts.Validators.Validators.Animals;

public class DogValidator : AbstractValidator<Dog>
{
    public DogValidator()
    {
        RuleFor(x => x.Bark)
            .Equal(true);
    }
}