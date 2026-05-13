namespace FitnessTracker.Domain;

public sealed class CardioActivity : Activity
{
    public Distance Distance { get; }

    public CardioActivity(string name, TimeSpan duration, Distance distance)
        : base(name, ActivityCategory.Cardio, duration)
    {
        Distance = distance;
    }

    public override string Describe() => $"{Name}: {Duration.TotalMinutes:0.##} min, {Distance}";
}
