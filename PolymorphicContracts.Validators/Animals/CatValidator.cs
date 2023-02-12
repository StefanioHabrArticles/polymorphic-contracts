using FluentValidation;
using PolymorphicContracts.Models.Animals;

namespace PolymorphicContracts.Validators.Animals;

public class CatValidator : AbstractValidator<Cat>
{
    public CatValidator()
    {
        RuleFor(x => x.Meow)
            .Equal(true);
    }
}