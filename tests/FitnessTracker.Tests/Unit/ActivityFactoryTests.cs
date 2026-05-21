using FitnessTracker.Application;
using FitnessTracker.Domain;
using Xunit;

namespace FitnessTracker.Tests.Unit;

public class ActivityFactoryTests
{
    [Fact]
    public void Create_WithCardioType_ShouldCreateCardioActivity()
    {
        var input = new ActivityInput
        {
            Type = "cardio",
            Name = "Running",
            DurationMinutes = 30,
            DistanceKm = 5
        };

        var result = ActivityFactory.Create(input);

        Assert.IsType<CardioActivity>(result);
    }

    [Fact]
    public void Create_WithStrengthType_ShouldCreateStrengthActivity()
    {
        var input = new ActivityInput
        {
            Type = "strength",
            Name = "Bench Press",
            DurationMinutes = 30,
            Sets = 3,
            RepsPerSet = 10,
            WeightKg = 50
        };

        var result = ActivityFactory.Create(input);

        Assert.IsType<StrengthActivity>(result);
    }

    [Fact]
    public void Create_WithUnknownType_ShouldThrowException()
    {
        var input = new ActivityInput
        {
            Type = "unknown",
            Name = "Test",
            DurationMinutes = 10
        };

        Assert.Throws<ArgumentException>(() =>
        {
            ActivityFactory.Create(input);
        });
    }

    [Fact]
    public void Create_WithNullInput_ShouldThrowException()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            ActivityFactory.Create(null!);
        });
    }
}