using PolymorphicContractsConsumer;
using Refit;

var fruitsClient = RestService.For<IFruitsClient>("http://localhost:5206");
var fruits = await fruitsClient.GetAllFruits();
foreach (var fruit in fruits)
{
    Console.WriteLine(fruit);
}