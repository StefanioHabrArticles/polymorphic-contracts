using System.Reflection;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Options;
using PolymorphicContracts.TypeDiscriminatorSwaggerSetup.Hierarchies.Models;
using PolymorphicContracts.TypeDiscriminatorSwaggerSetup.Hierarchies.Options;

namespace PolymorphicContracts.TypeDiscriminatorSwaggerSetup.Hierarchies;

public interface IJsonHierarchyRootsProvider
{
    IEnumerable<JsonHierarchyRoot> GetAllRoots();
}

public class JsonHierarchyRootsProvider : IJsonHierarchyRootsProvider
{
    private readonly List<string> _assemblies;

    public JsonHierarchyRootsProvider(IOptions<JsonHierarchiesOptions> options) =>
        _assemblies = options.Value.Assemblies;

    public IEnumerable<JsonHierarchyRoot> GetAllRoots() =>
        _assemblies.SelectMany(assembly => Assembly.Load(assembly)
            .GetTypes().Select(type => new JsonHierarchyRoot(
                type, type.GetCustomAttributes<JsonDerivedTypeAttribute>()
            )).Where(x => x.Attributes.Any()));
}