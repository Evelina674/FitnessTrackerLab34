using FitnessTracker.Domain;
using Xunit;

namespace FitnessTracker.Tests.Unit;

public class ActivityRecordTests
{
    [Fact]
    public void CreateActivityRecord_WithNullActivity_ShouldThrowException()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            var record = new ActivityRecord(null!, "test notes");
        });
    }

    [Fact]
    public void CreateActivityRecord_WithNullNotes_ShouldSetEmptyNotes()
    {
        var activity = new CardioActivity(
            "Running",
            TimeSpan.FromMinutes(20),
            new Distance(3)
        );

        var record = new ActivityRecord(activity, null!);

        Assert.Equal(string.Empty, record.Notes);
    }
}