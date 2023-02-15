using Microsoft.OpenApi.Any;

namespace PolymorphicContracts.TypeDiscriminatorSwaggerSetup.Hierarchies.Models.Discriminators;

public interface IDiscriminator
{
    string Type { get; }
    
    IOpenApiAny Value { get; }
}