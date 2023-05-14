using MediatR;
using PolymorphicContracts.Models.Fruits;

namespace PolymorphicContracts.Handlers.CreateFruit;

public record CreateCitrusRequest : CreateFruitRequest;

public class CreateCitrusHandler : IRequestHandler<CreateCitrusRequest, Fruit>
{
    public Task<Fruit> Handle(CreateCitrusRequest request, CancellationToken cancellationToken) =>
        Task.FromResult<Fruit>(new Citrus());
}