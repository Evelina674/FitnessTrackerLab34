namespace FitnessTracker.Domain;

public sealed class ActivityRecord
{
    public Activity Activity { get; }
    public string Notes { get; }

    public ActivityRecord(Activity activity, string notes)
    {
        Activity = activity ?? throw new ArgumentNullException(nameof(activity));
        Notes = notes?.Trim() ?? string.Empty;
    }
}
