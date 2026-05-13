using FitnessTracker.Domain;

namespace FitnessTracker.Application;

public sealed class CreateTrainingSessionRequest
{
    public Guid UserId { get; init; }
    public DateTime Date { get; init; }
    public IReadOnlyList<ActivityInput> Activities { get; init; } = Array.Empty<ActivityInput>();
    public string Notes { get; init; } = string.Empty;
}
