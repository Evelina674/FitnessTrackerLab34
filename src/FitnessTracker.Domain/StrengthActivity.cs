namespace FitnessTracker.Domain;

public sealed class StrengthActivity : Activity
{
    public int Sets { get; }
    public int RepsPerSet { get; }
    public double WeightKg { get; }

    public StrengthActivity(string name, TimeSpan duration, int sets, int repsPerSet, double weightKg)
        : base(name, ActivityCategory.Strength, duration)
    {
        if (sets <= 0)
        {
            throw new ArgumentException("Sets must be positive.", nameof(sets));
        }

        if (repsPerSet <= 0)
        {
            throw new ArgumentException("Repetitions must be positive.", nameof(repsPerSet));
        }

        if (weightKg < 0)
        {
            throw new ArgumentException("Weight must be zero or positive.", nameof(weightKg));
        }

        Sets = sets;
        RepsPerSet = repsPerSet;
        WeightKg = Math.Round(weightKg, 1);
    }

    public override string Describe() => $"{Name}: {Sets}x{RepsPerSet}, {WeightKg:0.0} kg, {Duration.TotalMinutes:0.##} min";
}
