using FitnessTracker.Domain;
using Xunit;

namespace FitnessTracker.Tests.Unit;

public class CardioActivityTests
{
    [Fact]
    public void CreateCardioActivity_WithEmptyName_ShouldThrowException()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var activity = new CardioActivity(
                "",
                TimeSpan.FromMinutes(20),
                new Distance(5)
            );
        });
    }

    [Fact]
    public void CreateCardioActivity_WithZeroDuration_ShouldThrowException()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var activity = new CardioActivity(
                "Running",
                TimeSpan.Zero,
                new Distance(5)
            );
        });
    }

    [Fact]
    public void CreateCardioActivity_WithValidData_ShouldCreateActivity()
    {
        var activity = new CardioActivity(
            "Running",
            TimeSpan.FromMinutes(20),
            new Distance(5)
        );

        Assert.NotNull(activity);
    }
}