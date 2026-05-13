using FitnessTracker.Domain;
using Xunit;

namespace FitnessTracker.Tests.Unit;

public class DistanceTests
{
    [Fact]
    public void CreateDistance_WithZeroValue_ShouldCreateDistance()
    {
        var distance = new Distance(0);

        Assert.Equal(0, distance.Kilometers);
    }

    [Fact]
    public void CreateDistance_WithNegativeValue_ShouldThrowException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var distance = new Distance(-5);
        });
    }

    [Fact]
    public void CreateDistance_WithPositiveValue_ShouldCreateDistance()
    {
        var distance = new Distance(5);

        Assert.Equal(5, distance.Kilometers);
    }
}