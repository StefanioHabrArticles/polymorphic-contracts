using FluentValidation;
using PolymorphicContracts.Models.Animals;

namespace PolymorphicContracts.Validators.Animals;

public class AnimalValidator : AbstractValidator<Animal>
{
    public AnimalValidator(CatValidator catValidator, DogValidator dogValidator)
    {
        RuleFor(x => x)
            .SetInheritanceValidator(v => v
                .Add(catValidator)
                .Add(dogValidator)
            );
    }
}