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

        var records = request.Activities
            .Select(CreateActivityRecord)
            .ToList();

        var session = new TrainingSession(
            request.UserId,
            request.Date,
            records,
            request.Notes);

        _repository.Add(session);

        return session;
    }

    private static ActivityRecord CreateActivityRecord(ActivityInput input)
    {
        if (input is null)
        {
            throw new ArgumentNullException(nameof(input));
        }

        var activity = ActivityFactory.Create(input);

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

        var lastDate = sessions.Max(session => session.Date);

        return new TrainingSummary
        {
            UserId = userId,
            LastSessionDate = lastDate,
            SessionsCount = sessions.Count,
            TotalDurationMinutes = sessions.Sum(session => session.TotalDurationMinutes()),
            TotalActivities = sessions.Sum(session => session.TotalActivities()),
            TotalWeightLifted = sessions.Sum(session => session.TotalWeightLifted()),
            SummaryText =
                $"{sessions.Count} sessions, " +
                $"{sessions.Sum(session => session.TotalDurationMinutes()):0.#} min total, " +
                $"{sessions.Sum(session => session.TotalActivities())} activities"
        };
    }

    public IReadOnlyList<TrainingSession> GetSessionsForUser(Guid userId)
    {
        if (userId == Guid.Empty)
        {
            throw new ArgumentException("UserId must be set.", nameof(userId));
        }

        return _repository.GetForUser(userId);
    }

    public TrainingSession? GetSessionById(Guid sessionId)
    {
        if (sessionId == Guid.Empty)
        {
            throw new ArgumentException("SessionId must be set.", nameof(sessionId));
        }

        return _repository.GetById(sessionId);
    }
}