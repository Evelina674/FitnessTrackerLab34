namespace FitnessTracker.Domain;

public abstract class Activity
{
    public string Name { get; }
    public ActivityCategory Category { get; }
    public TimeSpan Duration { get; }

    protected Activity(string name, ActivityCategory category, TimeSpan duration)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Activity name cannot be empty.", nameof(name));
        }

        if (duration <= TimeSpan.Zero)
        {
            throw new ArgumentException("Activity duration must be positive.", nameof(duration));
        }

        Name = name.Trim();
        Category = category;
        Duration = duration;
    }

    public abstract string Describe();
}
