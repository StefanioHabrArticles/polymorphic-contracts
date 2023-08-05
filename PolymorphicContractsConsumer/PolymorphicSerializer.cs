using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection;
using System.Text.Json;
using Refit;
using RestEase;

namespace PolymorphicContractsConsumer;

internal class PolymorphicSerializer : IHttpContentSerializer
{
    private readonly IHttpContentSerializer _defaultSerializer;
    private readonly JsonSerializerOptions _serializerOptions;

    public PolymorphicSerializer(
        IHttpContentSerializer defaultSerializer,
        JsonSerializerOptions serializerOptions)
    {
        _defaultSerializer = defaultSerializer;
        _serializerOptions = serializerOptions;
    }

    public HttpContent ToHttpContent<T>(T item) =>
        JsonContent.Create(item, item!.GetType().BaseType!, options: _serializerOptions);

    public Task<T?> FromHttpContentAsync<T>(HttpContent content, CancellationToken cancellationToken = default) =>
        _defaultSerializer.FromHttpContentAsync<T?>(content, cancellationToken);

    public string? GetFieldNameForProperty(PropertyInfo propertyInfo) =>
        _defaultSerializer.GetFieldNameForProperty(propertyInfo);
}

internal class PolymorphicRequestBodySerializer : RequestBodySerializer
{
    public JsonSerializerOptions? JsonSerializerOptions { get; set; }

    public override HttpContent? SerializeBody<T>(T body, RequestBodySerializerInfo info)
    {
        if (body == null)
            return null;

        var json = JsonSerializer.Serialize(body, JsonSerializerOptions);
        var content = new StringContent(json);

        const string contentType = "application/json";
        if (content.Headers.ContentType == null)
        {
            content.Headers.ContentType = new MediaTypeHeaderValue(contentType);
        }
        else
        {
            content.Headers.ContentType.MediaType = contentType;
        }
        return content;
    }
}

internal class PolymorphicResponseDeserializer : ResponseDeserializer
{
    public JsonSerializerOptions? JsonSerializerOptions { get; set; }

    public override T Deserialize<T>(
        string? content,
        HttpResponseMessage response,
        ResponseDeserializerInfo info) =>
        JsonSerializer.Deserialize<T>(
            content!,
            JsonSerializerOptions)!;
}