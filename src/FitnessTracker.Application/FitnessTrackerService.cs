using FitnessTracker.Domain;

namespace FitnessTracker.Application;

public sealed class FitnessTrackerService
{
    private readonly IFitnessSessionRepository _repository;

    public FitnessTrackerService(IFitnessSessionRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public TrainingSession CreateTrainingSession(CreateTrainingSessionRequest request)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        if (request.UserId == Guid.Empty)
        {
            throw new ArgumentException("UserId must be set.", nameof(request.UserId));
        }

        if (request.Date == DateTime.MinValue)
        {
            throw new ArgumentException("Date must be valid.", nameof(request.Date));
        }

        if (request.Activities == null || request.Activities.Count == 0)
        {
            throw new ArgumentException("At least one activity is required.", nameof(request.Activities));
        }

        var records = request.Activities.Select(CreateActivityRecord).ToList();

        var session = new TrainingSession(request.UserId, request.Date, records, request.Notes);
        _repository.Add(session);
        return session;
    }

    private static ActivityRecord CreateActivityRecord(ActivityInput input)
    {
        if (input is null)
        {
            throw new ArgumentNullException(nameof(input));
        }

        Activity activity = input.Type.Trim().ToLowerInvariant() switch
        {
            "cardio" => new CardioActivity(input.Name, TimeSpan.FromMinutes(input.DurationMinutes), new Distance(input.DistanceKm)),
            "strength" => new StrengthActivity(input.Name, TimeSpan.FromMinutes(input.DurationMinutes), input.Sets, input.RepsPerSet, input.WeightKg),
            _ => throw new ArgumentException($"Unsupported activity type: {input.Type}", nameof(input.Type))
        };

        return new ActivityRecord(activity, input.Notes);
    }

    public TrainingSummary GetSummary(Guid userId)
    {
        if (userId == Guid.Empty)
        {
            throw new ArgumentException("UserId must be set.", nameof(userId));
        }

        var sessions = _repository.GetForUser(userId);
        if (sessions == null || sessions.Count == 0)
        {
            throw new InvalidOperationException("No training sessions found for the user.");
        }

        var lastDate = sessions.Max(s => s.Date);
        return new TrainingSummary
        {
            UserId = userId,
            LastSessionDate = lastDate,
            SessionsCount = sessions.Count,
            TotalDurationMinutes = sessions.Sum(s => s.TotalDurationMinutes()),
            TotalActivities = sessions.Sum(s => s.TotalActivities()),
            TotalWeightLifted = sessions.Sum(s => s.TotalWeightLifted()),
            SummaryText = $"{sessions.Count} sessions, {sessions.Sum(s => s.TotalDurationMinutes()):0.#} min total, {sessions.Sum(s => s.TotalActivities())} activities"
        };
    }
}
