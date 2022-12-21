using PolymorphicContracts.TypeDiscriminatorSwaggerSetup.Hierarchies;
using PolymorphicContracts.TypeDiscriminatorSwaggerSetup.Hierarchies.Options;

namespace PolymorphicContracts.TypeDiscriminatorSwaggerSetup;

public static class ServiceCollectionExtensions
{
    public static void AddTypeDiscriminatorToSwagger
        (this WebApplicationBuilder builder) => builder.Services
        .Configure<JsonHierarchiesOptions>(builder.Configuration.GetSection(JsonHierarchiesOptions.Key))
        .AddSingleton<IJsonHierarchyRootsProvider, JsonHierarchyRootsProvider>()
        .AddSingleton<IJsonHierarchiesProvider, JsonHierarchiesProvider>()
        .AddSingleton<IJsonHierarchiesRepository, JsonHierarchiesRepository>()
        .ConfigureSwaggerGen(options =>
        {
            options.UseOneOfForPolymorphism();
            options.SchemaFilter<TypeDiscriminatorSchemaFilter>();
        });
}