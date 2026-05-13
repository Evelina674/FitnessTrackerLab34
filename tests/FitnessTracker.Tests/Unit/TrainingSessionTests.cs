using FitnessTracker.Domain;
using Xunit;

namespace FitnessTracker.Tests.Unit;

public class TrainingSessionTests
{
    [Fact]
    public void CreateTrainingSession_WithEmptyUserId_ShouldThrowException()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var session = new TrainingSession(
                Guid.Empty,
                DateTime.Today,
                new List<ActivityRecord>()
            );
        });
    }

    [Fact]
    public void CreateTrainingSession_WithInvalidDate_ShouldThrowException()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var session = new TrainingSession(
                Guid.NewGuid(),
                DateTime.MinValue,
                new List<ActivityRecord>()
            );
        });
    }
    [Fact]
public void CreateTrainingSession_WithNullActivities_ShouldThrowException()
{
    Assert.Throws<ArgumentNullException>(() =>
    {
        var session = new TrainingSession(
            Guid.NewGuid(),
            DateTime.Today,
            null!
        );
    });
}
[Fact]
public void CreateTrainingSession_WithEmptyActivities_ShouldThrowException()
{
    Assert.Throws<ArgumentException>(() =>
    {
        var session = new TrainingSession(
            Guid.NewGuid(),
            DateTime.Today,
            new List<ActivityRecord>()
        );
    });
}
[Fact]
public void CreateTrainingSession_WithValidData_ShouldCreateSession()
{
    var activity = new CardioActivity(
        "Running",
        TimeSpan.FromMinutes(30),
        new Distance(5)
    );

   var activityRecord = new ActivityRecord(activity, "Morning run");
    var session = new TrainingSession(
        Guid.NewGuid(),
        DateTime.Today,
        new List<ActivityRecord> { activityRecord }
    );

    Assert.NotNull(session);
}
}