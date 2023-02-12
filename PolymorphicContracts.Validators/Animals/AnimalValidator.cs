using FluentValidation;
using PolymorphicContracts.Models.Animals;

namespace PolymorphicContracts.Validators.Animals;

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