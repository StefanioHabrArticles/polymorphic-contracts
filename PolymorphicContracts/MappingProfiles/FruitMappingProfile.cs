using AutoMapper;
using PolymorphicContracts.Handlers.CreateFruit;
using PolymorphicContracts.Models.Fruits;

namespace PolymorphicContracts.MappingProfiles;

public class FruitMappingProfile : Profile
{
    public FruitMappingProfile()
    {
        CreateMap<CreateFruitRequest, Fruit>()
            .Include<CreateAppleRequest, Apple>()
            .Include<CreateCitrusRequest, Citrus>()
            .Include<CreateGrapeRequest, Grape>();

        CreateMap<CreateAppleRequest, Apple>();
        CreateMap<CreateCitrusRequest, Citrus>();
        CreateMap<CreateGrapeRequest, Grape>();
    }
}