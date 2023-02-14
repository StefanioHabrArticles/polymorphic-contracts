using PolymorphicContracts.Models.Fruits;
using Refit;

namespace PolymorphicContractsConsumer.Clients;

public interface IFruitsClient
{
    [Get("")]
    public Task<IEnumerable<Fruit>> GetAllFruits();
}