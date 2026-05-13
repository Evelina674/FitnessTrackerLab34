namespace FitnessTracker.Application;

public sealed class TrainingSummary
{
    public Guid UserId { get; init; }
    public DateTime LastSessionDate { get; init; }
    public int SessionsCount { get; init; }
    public double TotalDurationMinutes { get; init; }
    public int TotalActivities { get; init; }
    public double TotalWeightLifted { get; init; }
    public string SummaryText { get; init; } = string.Empty;
}
