using MediatR;
using PolymorphicContracts.Models.Fruits;

namespace PolymorphicContracts.Handlers.CreateFruit;

public record CreateCitrusRequest(CreateCitrusRequestType Type) : CreateFruitRequest;

public enum CreateCitrusRequestType
{
    Lemon,
    Orange,
    Lime
}

public class CreateCitrusHandler : IRequestHandler<CreateCitrusRequest, Fruit>
{
    public Task<Fruit> Handle(CreateCitrusRequest request, CancellationToken cancellationToken) =>
        Task.FromResult<Fruit>(new Citrus
        {
            Type = request.Type switch
            {
                CreateCitrusRequestType.Lemon => CitrusType.Lemon,
                CreateCitrusRequestType.Orange => CitrusType.Orange,
                CreateCitrusRequestType.Lime => CitrusType.Lime,
                _ => throw new ArgumentOutOfRangeException(nameof(request.Type))
            }
        });
}