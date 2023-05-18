using MediatR;
using Microsoft.AspNetCore.Mvc;
using PolymorphicContracts.Handlers.CreateFruit;
using PolymorphicContracts.Models.Animals;
using PolymorphicContracts.Models.Fruits;

namespace PolymorphicContracts;

[ApiController]
[Route("[controller]")]
public class AnimalsController : Controller
{
    [HttpGet]
    public IEnumerable<Animal> GetAnimals() =>
        new List<Animal> { new Dog(), new Cat() };

    [HttpPost]
    public void PostAnimal([FromBody] Animal animal,
        ILogger<AnimalsController> logger) =>
        logger.LogInformation("{Animal}", animal.ToString());
}

[ApiController]
[Route("[controller]")]
public class FruitsController : Controller
{
    [HttpGet]
    public IEnumerable<Fruit> GetFruits() =>
        new List<Fruit> { new Apple(), new Citrus(), new Grape() };

    [HttpPost]
    public Task<Fruit> CreateFruit([FromBody] CreateFruitRequest request,
        IMediator mediator,
        CancellationToken ctn) =>
        mediator.Send(request, ctn);
}