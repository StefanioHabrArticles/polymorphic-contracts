using System.Net.Http.Json;
using System.Reflection;
using System.Text.Json;
using Refit;

namespace PolymorphicContractsConsumer;

internal class PolymorphicSerializer : IHttpContentSerializer
{
    private readonly IHttpContentSerializer _defaultSerializer;
    private readonly JsonSerializerOptions _serializerOptions;

    public PolymorphicSerializer(
        IHttpContentSerializer defaultSerializer,
        JsonSerializerOptions serializerOptions) =>
        (_defaultSerializer, _serializerOptions) =
        (defaultSerializer, serializerOptions);

    public HttpContent ToHttpContent<T>(T item) =>
        JsonContent.Create(item, item!.GetType().BaseType!, options: _serializerOptions);

    public Task<T?> FromHttpContentAsync<T>(HttpContent content, CancellationToken cancellationToken = default) =>
        _defaultSerializer.FromHttpContentAsync<T?>(content, cancellationToken);

    public string? GetFieldNameForProperty(PropertyInfo propertyInfo) =>
        _defaultSerializer.GetFieldNameForProperty(propertyInfo);
}