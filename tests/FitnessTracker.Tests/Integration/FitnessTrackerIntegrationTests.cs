using FitnessTracker.Domain;
using FitnessTracker.Infrastructure;
using Xunit;

namespace FitnessTracker.Tests.Integration;

public class FitnessTrackerIntegrationTests
{
    [Fact]
    public void AddSession_ThenGetById_ShouldReturnSession()
    {
        var repository = new InMemoryFitnessSessionRepository();

        var activity = new CardioActivity(
            "Running",
            TimeSpan.FromMinutes(20),
            new Distance(5)
        );

        var record = new ActivityRecord(activity, "Morning");

        var session = new TrainingSession(
            Guid.NewGuid(),
            DateTime.Today,
            new List<ActivityRecord> { record }
        );

        repository.Add(session);

        var result = repository.GetById(session.Id);

        Assert.NotNull(result);
        Assert.Equal(session.Id, result!.Id);
    }

    [Fact]
    public void AddDuplicateSession_ShouldThrowException()
    {
        var repository = new InMemoryFitnessSessionRepository();

        var activity = new CardioActivity(
            "Running",
            TimeSpan.FromMinutes(20),
            new Distance(5)
        );

        var record = new ActivityRecord(activity, "Morning");

        var session = new TrainingSession(
            Guid.NewGuid(),
            DateTime.Today,
            new List<ActivityRecord> { record }
        );

        repository.Add(session);

        Assert.Throws<InvalidOperationException>(() =>
        {
            repository.Add(session);
        });
    }

    [Fact]
    public void AddNullSession_ShouldThrowException()
    {
        var repository = new InMemoryFitnessSessionRepository();

        Assert.Throws<ArgumentNullException>(() =>
        {
            repository.Add(null!);
        });
    }

    [Fact]
    public void GetById_WithUnknownId_ShouldReturnNull()
    {
        var repository = new InMemoryFitnessSessionRepository();

        var result = repository.GetById(Guid.NewGuid());

        Assert.Null(result);
    }

    [Fact]
    public void GetForUser_ShouldReturnOnlyUserSessions()
    {
        var repository = new InMemoryFitnessSessionRepository();

        var userId = Guid.NewGuid();

        var activity = new CardioActivity(
            "Running",
            TimeSpan.FromMinutes(20),
            new Distance(5)
        );

        var record = new ActivityRecord(activity, "Morning");

        var session1 = new TrainingSession(
            userId,
            DateTime.Today,
            new List<ActivityRecord> { record }
        );

        var session2 = new TrainingSession(
            Guid.NewGuid(),
            DateTime.Today,
            new List<ActivityRecord> { record }
        );

        repository.Add(session1);
        repository.Add(session2);

        var result = repository.GetForUser(userId);

        Assert.Single(result);
    }

    [Fact]
    public void GetForUser_WithNoSessions_ShouldReturnEmptyCollection()
    {
        var repository = new InMemoryFitnessSessionRepository();

        var result = repository.GetForUser(Guid.NewGuid());

        Assert.Empty(result);
    }

    [Fact]
    public void AddMultipleSessions_ShouldStoreAllSessions()
    {
        var repository = new InMemoryFitnessSessionRepository();

        var activity = new CardioActivity(
            "Running",
            TimeSpan.FromMinutes(20),
            new Distance(5)
        );

        var record = new ActivityRecord(activity, "Morning");

        var session1 = new TrainingSession(
            Guid.NewGuid(),
            DateTime.Today,
            new List<ActivityRecord> { record }
        );

        var session2 = new TrainingSession(
            Guid.NewGuid(),
            DateTime.Today,
            new List<ActivityRecord> { record }
        );

        repository.Add(session1);
        repository.Add(session2);

        var result1 = repository.GetById(session1.Id);
        var result2 = repository.GetById(session2.Id);

        Assert.NotNull(result1);
        Assert.NotNull(result2);
    }

    [Fact]
    public void Repository_ShouldHandleSequentialOperations()
    {
        var repository = new InMemoryFitnessSessionRepository();

        var activity = new CardioActivity(
            "Cycling",
            TimeSpan.FromMinutes(40),
            new Distance(15)
        );

        var record = new ActivityRecord(activity, "Evening");

        var session = new TrainingSession(
            Guid.NewGuid(),
            DateTime.Today,
            new List<ActivityRecord> { record }
        );

        repository.Add(session);

        var loaded = repository.GetById(session.Id);

        Assert.NotNull(loaded);

        var userSessions = repository.GetForUser(session.UserId);

        Assert.Single(userSessions);
    }
}