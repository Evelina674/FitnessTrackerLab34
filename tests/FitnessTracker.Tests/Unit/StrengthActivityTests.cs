using FitnessTracker.Domain;
using Xunit;

namespace FitnessTracker.Tests.Unit;

public class StrengthActivityTests
{
    [Fact]
    public void CreateStrengthActivity_WithEmptyName_ShouldThrowException()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var activity = new StrengthActivity(
                "",
                TimeSpan.FromMinutes(30),
                3,
                10,
                50
            );
        });
    }

    [Fact]
    public void CreateStrengthActivity_WithInvalidSets_ShouldThrowException()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var activity = new StrengthActivity(
                "Bench Press",
                TimeSpan.FromMinutes(30),
                0,
                10,
                50
            );
        });
    }

    [Fact]
    public void CreateStrengthActivity_WithValidData_ShouldCreateActivity()
    {
        var activity = new StrengthActivity(
            "Bench Press",
            TimeSpan.FromMinutes(30),
            3,
            10,
            50
        );

        Assert.NotNull(activity);
        Assert.Equal(3, activity.Sets);
        Assert.Equal(10, activity.RepsPerSet);
        Assert.Equal(50, activity.WeightKg);
    }
    [Fact]
public void CreateStrengthActivity_WithInvalidReps_ShouldThrowException()
{
    Assert.Throws<ArgumentException>(() =>
    {
        var activity = new StrengthActivity(
            "Bench Press",
            TimeSpan.FromMinutes(30),
            3,
            0,
            50
        );
    });
}

[Fact]
public void CreateStrengthActivity_WithNegativeWeight_ShouldThrowException()
{
    Assert.Throws<ArgumentException>(() =>
    {
        var activity = new StrengthActivity(
            "Bench Press",
            TimeSpan.FromMinutes(30),
            3,
            10,
            -1
        );
    });
}

[Fact]
public void CreateStrengthActivity_WithZeroWeight_ShouldCreateActivity()
{
    var activity = new StrengthActivity(
        "Push Ups",
        TimeSpan.FromMinutes(15),
        3,
        12,
        0
    );

    Assert.Equal(0, activity.WeightKg);
}

[Fact]
public void CreateStrengthActivity_ShouldRoundWeightToOneDecimal()
{
    var activity = new StrengthActivity(
        "Bench Press",
        TimeSpan.FromMinutes(30),
        3,
        10,
        50.56
    );

    Assert.Equal(50.6, activity.WeightKg);
}
}