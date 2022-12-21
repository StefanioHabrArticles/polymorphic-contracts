using FluentValidation;
using PolymorphicContracts.Models.Models.Animals;

namespace PolymorphicContracts.Validators.Validators.Animals;

public class AnimalValidator : AbstractValidator<Animal>
{
    public AnimalValidator()
    {
        RuleFor(x => x)
            .SetInheritanceValidator(v => v
                .Add(new CatValidator())
                .Add(new DogValidator())
            );
    }
}