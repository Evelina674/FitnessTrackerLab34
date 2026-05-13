using FitnessTracker.Domain;

namespace FitnessTracker.Infrastructure;

public sealed class InMemoryFitnessSessionRepository : IFitnessSessionRepository
{
    private readonly List<TrainingSession> _sessions = new();

    public void Add(TrainingSession session)
    {
        if (session is null)
        {
            throw new ArgumentNullException(nameof(session));
        }

        if (_sessions.Any(existing => existing.Id == session.Id))
        {
            throw new InvalidOperationException("Session with the same id already exists.");
        }

        _sessions.Add(session);
    }

    public TrainingSession? GetById(Guid sessionId) => _sessions.FirstOrDefault(s => s.Id == sessionId);

    public IReadOnlyList<TrainingSession> GetForUser(Guid userId) => _sessions.Where(s => s.UserId == userId).OrderBy(s => s.Date).ToList();
}
