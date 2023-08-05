using PolymorphicContracts.Models.Animals;
using RestEase;

namespace PolymorphicContractsConsumer.Clients;

public interface IAnimalsClient
{
    [Get("")]
    Task<IEnumerable<Animal>> GetAllAnimals();

    [Post("")]
    Task SendAnimal([Body] Animal animal);
}