using PolymorphicContractsConsumer;
using PolymorphicContractsConsumer.Clients;
using Refit;
using RestEase;

const string host = "http://localhost:5206";

var refitSettings = new RefitSettings
{
    ContentSerializer = new PolymorphicSerializer(
        new SystemTextJsonContentSerializer(),
        SystemTextJsonContentSerializer.GetDefaultJsonSerializerOptions()
    )
};

var fruitsClient = RestService.For<IFruitsClient>($"{host}/fruits", refitSettings);
var fruits = await fruitsClient.GetAllFruits();
foreach (var fruit in fruits)
    Console.WriteLine(fruit);

var animalsClient = new RestClient($"{host}/animals")
{
    RequestBodySerializer = new PolymorphicRequestBodySerializer(),
    ResponseDeserializer = new PolymorphicResponseDeserializer()
}.For<IAnimalsClient>();
var animals = await animalsClient.GetAllAnimals();
foreach (var animal in animals)
    await animalsClient.SendAnimal(animal);