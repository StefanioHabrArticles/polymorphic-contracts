using PolymorphicContracts.Models.Fruits;
using Refit;

namespace PolymorphicContractsConsumer;

public interface IFruitsClient
{
    [Get("/fruits")]
    public Task<IEnumerable<Fruit>> GetAllFruits();
}