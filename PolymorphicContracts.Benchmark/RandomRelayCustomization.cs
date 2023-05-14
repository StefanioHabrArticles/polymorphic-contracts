using AutoFixture.Kernel;

namespace PolymorphicContracts.Benchmark;

public class RandomRelayCustomization : ISpecimenBuilder
{
    private readonly List<ISpecimenBuilder> _builders;
    private readonly IEnumerator<int> _randomizer;

    public RandomRelayCustomization(params ISpecimenBuilder[] builders)
        : this(builders.AsEnumerable())
    {
    }

    private RandomRelayCustomization(IEnumerable<ISpecimenBuilder> builders)
    {
        if (builders is null)
        {
            throw new ArgumentNullException(nameof(builders));
        }

        _builders = builders.ToList();
        _randomizer = new RoundRobinSequence(0, _builders.Count - 1)
            .GetEnumerator();
    }

    public object Create(object request, ISpecimenContext context)
    {
        _randomizer.MoveNext();
        var builder = _builders[_randomizer.Current];
        return builder.Create(request, context);
    }
}