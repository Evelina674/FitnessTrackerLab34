using FitnessTracker.Application;
using FitnessTracker.Domain;
using Xunit;

namespace FitnessTracker.Tests.Unit;

public class FitnessAnalyticsServiceTests
{
    private static TrainingSession CreateSession(DateTime date, int minutes)
    {
        var activity = new CardioActivity(
            "Running",
            TimeSpan.FromMinutes(minutes),
            new Distance(5)
        );

        var record = new ActivityRecord(activity, "Test");

        return new TrainingSession(
            Guid.NewGuid(),
            date,
            new List<ActivityRecord> { record }
        );
    }

    [Fact]
    public void GetTotalDurationMinutes_ShouldReturnSum()
    {
        var service = new FitnessAnalyticsService();

        var sessions = new List<TrainingSession>
        {
            CreateSession(DateTime.Today, 30),
            CreateSession(DateTime.Today, 20)
        };

        var result = service.GetTotalDurationMinutes(sessions);

        Assert.Equal(50, result);
    }

    [Fact]
    public void GetTotalActivities_ShouldReturnCount()
    {
        var service = new FitnessAnalyticsService();

        var sessions = new List<TrainingSession>
        {
            CreateSession(DateTime.Today, 30),
            CreateSession(DateTime.Today, 20)
        };

        var result = service.GetTotalActivities(sessions);

        Assert.Equal(2, result);
    }

    [Fact]
    public void GetSessionsByDate_ShouldReturnOnlyMatchingDate()
    {
        var service = new FitnessAnalyticsService();

        var today = DateTime.Today;
        var yesterday = DateTime.Today.AddDays(-1);

        var sessions = new List<TrainingSession>
        {
            CreateSession(today, 30),
            CreateSession(yesterday, 20)
        };

        var result = service.GetSessionsByDate(sessions, today);

        Assert.Single(result);
    }

    [Fact]
    public void GetSessionsSortedByDate_ShouldReturnNewestFirst()
    {
        var service = new FitnessAnalyticsService();

        var oldDate = DateTime.Today.AddDays(-2);
        var newDate = DateTime.Today;

        var sessions = new List<TrainingSession>
        {
            CreateSession(oldDate, 20),
            CreateSession(newDate, 30)
        };

        var result = service.GetSessionsSortedByDate(sessions);

        Assert.Equal(newDate, result.First().Date.Date);
    }

    [Fact]
    public void CountSessionsByDate_ShouldReturnGroupedCount()
    {
        var service = new FitnessAnalyticsService();

        var today = DateTime.Today;

        var sessions = new List<TrainingSession>
        {
            CreateSession(today, 20),
            CreateSession(today, 30)
        };

        var result = service.CountSessionsByDate(sessions);

        Assert.Equal(2, result[today]);
    }
}