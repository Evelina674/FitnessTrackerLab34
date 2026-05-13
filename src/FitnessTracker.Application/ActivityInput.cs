namespace FitnessTracker.Application;

public sealed record ActivityInput
{
    public string Name { get; init; } = string.Empty;
    public string Type { get; init; } = string.Empty;
    public double DurationMinutes { get; init; }
    public double DistanceKm { get; init; }
    public int Sets { get; init; }
    public int RepsPerSet { get; init; }
    public double WeightKg { get; init; }
    public string Notes { get; init; } = string.Empty;
}
