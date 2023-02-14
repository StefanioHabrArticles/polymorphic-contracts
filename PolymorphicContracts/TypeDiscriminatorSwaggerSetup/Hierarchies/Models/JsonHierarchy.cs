using Microsoft.OpenApi.Any;

namespace PolymorphicContracts.TypeDiscriminatorSwaggerSetup.Hierarchies.Models;

public interface IDiscriminator
{
    string Type { get; }
    
    IOpenApiAny Value { get; }
}

public record IntegerDiscriminator(int IntValue) : IDiscriminator
{
    public string Type => "integer";

    public IOpenApiAny Value =>
        new OpenApiInteger(IntValue);

    public override string ToString() =>
        IntValue.ToString();
}

public record StringDiscriminator(string StrValue) : IDiscriminator
{
    public string Type => "string";

    public IOpenApiAny Value =>
        new OpenApiString(StrValue);
    
    public override string ToString() =>
        StrValue;
}

public static class ObjectExtensions
{
    public static IDiscriminator ToDiscriminator
        (this object? typeDiscriminator, Type derivedType) =>
        typeDiscriminator switch
        {
            int intValue => new IntegerDiscriminator(intValue),
            string strValue => new StringDiscriminator(strValue),
            null => throw new ArgumentNullException(nameof(typeDiscriminator), $"{derivedType}"),
            _ => throw new ArgumentOutOfRangeException(nameof(typeDiscriminator), $"{derivedType}")
        };
}

public record DerivedTypeInfo(
    Type Type,
    IDiscriminator Discriminator
);

public record JsonHierarchy(
    Type BaseType,
    Dictionary<Type, DerivedTypeInfo> DerivedTypes
);