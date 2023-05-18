using MediatR;
using PolymorphicContracts.Models.Fruits;

namespace PolymorphicContracts.Handlers.CreateFruit;

public record CreateGrapeRequest(bool Seed) : CreateFruitRequest;

public class CreateGrapeHandler : IRequestHandler<CreateGrapeRequest, Fruit>
{
    public Task<Fruit> Handle(CreateGrapeRequest request, CancellationToken cancellationToken) =>
        Task.FromResult<Fruit>(new Grape { Seed = request.Seed });
}