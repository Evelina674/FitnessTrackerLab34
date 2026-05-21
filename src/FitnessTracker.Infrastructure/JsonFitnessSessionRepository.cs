using FitnessTracker.Application;
using FitnessTracker.Domain;

namespace FitnessTracker.Infrastructure;

public sealed class JsonFitnessSessionRepository : IFitnessSessionRepository
{
    private readonly IDataStore<TrainingSession> _store;
    private readonly List<TrainingSession> _sessions = new();

    public JsonFitnessSessionRepository(IDataStore<TrainingSession> store)
    {
        _store = store ?? throw new ArgumentNullException(nameof(store));
    }

    public async Task LoadAsync(CancellationToken cancellationToken = default)
    {
        var loadedSessions = await _store.LoadAsync(cancellationToken);

        _sessions.Clear();
        _sessions.AddRange(loadedSessions);
    }

    public async Task SaveAsync(CancellationToken cancellationToken = default)
    {
        await _store.SaveAsync(_sessions, cancellationToken);
    }

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

    public TrainingSession? GetById(Guid sessionId)
    {
        return _sessions.FirstOrDefault(session => session.Id == sessionId);
    }

    public IReadOnlyList<TrainingSession> GetForUser(Guid userId)
    {
        return _sessions
            .Where(session => session.UserId == userId)
            .ToList();
    }
}