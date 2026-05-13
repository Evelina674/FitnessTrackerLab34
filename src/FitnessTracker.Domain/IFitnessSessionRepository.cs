namespace FitnessTracker.Domain;

public interface IFitnessSessionRepository
{
    void Add(TrainingSession session);
    TrainingSession? GetById(Guid sessionId);
    IReadOnlyList<TrainingSession> GetForUser(Guid userId);
}
