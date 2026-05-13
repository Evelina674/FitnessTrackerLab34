namespace FitnessTracker.Domain;

public sealed class TrainingSession
{
    public Guid Id { get; }
    public Guid UserId { get; }
    public DateTime Date { get; }
    public IReadOnlyList<ActivityRecord> Activities { get; }
    public string Notes { get; }

    public TrainingSession(Guid userId, DateTime date, IEnumerable<ActivityRecord> activities, string? notes = null)
    {
        if (userId == Guid.Empty)
        {
            throw new ArgumentException("UserId must be provided.", nameof(userId));
        }

        if (date == DateTime.MinValue)
        {
            throw new ArgumentException("Date must be valid.", nameof(date));
        }

        var activityList = activities?.ToList() ?? throw new ArgumentNullException(nameof(activities));
        if (!activityList.Any())
        {
            throw new ArgumentException("Training session must contain at least one activity.", nameof(activities));
        }

        if (activityList.Any(a => a == null))
        {
            throw new ArgumentException("Activity records cannot contain null items.", nameof(activities));
        }

        Id = Guid.NewGuid();
        UserId = userId;
        Date = date;
        Activities = activityList;
        Notes = notes?.Trim() ?? string.Empty;
    }

    public double TotalDurationMinutes() => Activities.Sum(record => record.Activity.Duration.TotalMinutes);
    public int TotalActivities() => Activities.Count;
    public double TotalWeightLifted() => Activities.Select(record => record.Activity).OfType<StrengthActivity>().Sum(activity => activity.Sets * activity.RepsPerSet * activity.WeightKg);
}
