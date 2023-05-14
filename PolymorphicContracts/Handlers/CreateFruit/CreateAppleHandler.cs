using MediatR;
using PolymorphicContracts.Models.Fruits;

namespace PolymorphicContracts.Handlers.CreateFruit;

public record CreateAppleRequest : CreateFruitRequest;

public class CreateAppleHandler : IRequestHandler<CreateAppleRequest, Fruit>
{
    public Task<Fruit> Handle(CreateAppleRequest request, CancellationToken cancellationToken) =>
        Task.FromResult<Fruit>(new Apple());
}