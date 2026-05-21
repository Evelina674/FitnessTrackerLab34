using System.Text.Json;
using FitnessTracker.Application;
using FitnessTracker.Domain;

namespace FitnessTracker.Infrastructure;

public sealed class JsonTrainingSessionStore
    : IDataStore<TrainingSession>
{
    private readonly string _filePath;

    public JsonTrainingSessionStore(string filePath)
    {
        _filePath = filePath;
    }

    public async Task<IReadOnlyCollection<TrainingSession>> LoadAsync(
        CancellationToken cancellationToken = default)
    {
        if (!File.Exists(_filePath))
        {
            return Array.Empty<TrainingSession>();
        }

        try
        {
            var json = await File.ReadAllTextAsync(
                _filePath,
                cancellationToken);

            var sessions =
                JsonSerializer.Deserialize<List<TrainingSession>>(json);

            return sessions ?? new List<TrainingSession>();
        }
        catch
        {
            return Array.Empty<TrainingSession>();
        }
    }

    public async Task SaveAsync(
        IReadOnlyCollection<TrainingSession> items,
        CancellationToken cancellationToken = default)
    {
        var json = JsonSerializer.Serialize(
            items,
            new JsonSerializerOptions
            {
                WriteIndented = true
            });

        await File.WriteAllTextAsync(
            _filePath,
            json,
            cancellationToken);
    }
}