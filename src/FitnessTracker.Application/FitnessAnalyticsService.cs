using FitnessTracker.Domain;

namespace FitnessTracker.Application;

public sealed class FitnessAnalyticsService
{
    public double GetTotalDurationMinutes(IEnumerable<TrainingSession> sessions)
    {
        return sessions.Sum(session => session.TotalDurationMinutes());
    }

    public int GetTotalActivities(IEnumerable<TrainingSession> sessions)
    {
        return sessions.Sum(session => session.TotalActivities());
    }

    public IReadOnlyList<TrainingSession> GetSessionsByDate(
        IEnumerable<TrainingSession> sessions,
        DateTime date)
    {
        return sessions
            .Where(session => session.Date.Date == date.Date)
            .ToList();
    }

    public IReadOnlyList<TrainingSession> GetSessionsSortedByDate(
        IEnumerable<TrainingSession> sessions)
    {
        return sessions
            .OrderByDescending(session => session.Date)
            .ToList();
    }

    public Dictionary<DateTime, int> CountSessionsByDate(
        IEnumerable<TrainingSession> sessions)
    {
        return sessions
            .GroupBy(session => session.Date.Date)
            .ToDictionary(group => group.Key, group => group.Count());
    }
}