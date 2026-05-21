using FitnessTracker.Domain;
using FitnessTracker.Infrastructure;
using Xunit;

namespace FitnessTracker.Tests.Integration;

public class JsonTrainingSessionStoreTests
{
    private static TrainingSession CreateSession()
    {
        var activity = new CardioActivity(
            "Running",
            TimeSpan.FromMinutes(30),
            new Distance(5)
        );

        var record = new ActivityRecord(activity, "Morning run");

        return new TrainingSession(
            Guid.NewGuid(),
            DateTime.Today,
            new List<ActivityRecord> { record }
        );
    }

    [Fact]
    public async Task SaveAsync_ShouldCreateJsonFile()
    {
        var filePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".json");
        var store = new JsonTrainingSessionStore(filePath);

        var sessions = new List<TrainingSession>
        {
            CreateSession()
        };

        await store.SaveAsync(sessions);

        Assert.True(File.Exists(filePath));

        File.Delete(filePath);
    }

    [Fact]
    public async Task LoadAsync_WhenFileDoesNotExist_ShouldReturnEmptyCollection()
    {
        var filePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".json");
        var store = new JsonTrainingSessionStore(filePath);

        var result = await store.LoadAsync();

        Assert.Empty(result);
    }

    [Fact]
    public async Task LoadAsync_WhenFileIsBroken_ShouldReturnEmptyCollection()
    {
        var filePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".json");

        await File.WriteAllTextAsync(filePath, "broken json");

        var store = new JsonTrainingSessionStore(filePath);

        var result = await store.LoadAsync();

        Assert.Empty(result);

        File.Delete(filePath);
    }
}