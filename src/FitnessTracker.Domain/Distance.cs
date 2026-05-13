namespace FitnessTracker.Domain;

public readonly struct Distance
{
    public double Kilometers { get; }

    public Distance(double kilometers)
    {
        if (kilometers < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(kilometers), "Distance must be zero or positive.");
        }

        Kilometers = Math.Round(kilometers, 2);
    }

    public override string ToString() => $"{Kilometers:0.##} km";
}
