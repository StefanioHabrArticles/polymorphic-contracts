using MediatR;
using PolymorphicContracts.Models.Fruits;

namespace PolymorphicContracts.Handlers.CreateFruit;

public record CreateAppleRequest(CreateAppleRequestColor Color) : CreateFruitRequest;

public enum CreateAppleRequestColor
{
    Red,
    Gold,
    Yellow,
    Green
}

public class CreateAppleHandler : IRequestHandler<CreateAppleRequest, Fruit>
{
    public Task<Fruit> Handle(CreateAppleRequest request, CancellationToken cancellationToken) =>
        Task.FromResult<Fruit>(new Apple
        {
            Color = request.Color switch
            {
                CreateAppleRequestColor.Red => AppleColor.Red,
                CreateAppleRequestColor.Gold => AppleColor.Gold,
                CreateAppleRequestColor.Yellow => AppleColor.Yellow,
                CreateAppleRequestColor.Green => AppleColor.Green,
                _ => throw new ArgumentOutOfRangeException(nameof(request.Color))
            }
        });
}