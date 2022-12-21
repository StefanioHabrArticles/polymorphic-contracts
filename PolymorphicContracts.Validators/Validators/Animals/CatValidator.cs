using FluentValidation;
using PolymorphicContracts.Models.Models.Animals;

namespace PolymorphicContracts.Validators.Validators.Animals;

public class CatValidator : AbstractValidator<Cat>
{
    public CatValidator()
    {
        RuleFor(x => x.Meow)
            .Equal(true);
    }
}