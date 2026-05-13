namespace FitnessTracker.Domain;

public sealed class UserProfile
{
    public Guid Id { get; }
    public string Name { get; private set; }
    public int Age { get; private set; }
    public double WeightKg { get; private set; }
    public double HeightCm { get; private set; }

    public UserProfile(string name, int age, double weightKg, double heightCm)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("User name cannot be empty.", nameof(name));
        }

        if (age <= 0)
        {
            throw new ArgumentException("Age must be positive.", nameof(age));
        }

        if (weightKg <= 0)
        {
            throw new ArgumentException("Weight must be positive.", nameof(weightKg));
        }

        if (heightCm <= 0)
        {
            throw new ArgumentException("Height must be positive.", nameof(heightCm));
        }

        Id = Guid.NewGuid();
        Name = name.Trim();
        Age = age;
        WeightKg = Math.Round(weightKg, 1);
        HeightCm = Math.Round(heightCm, 1);
    }

    public void UpdateWeight(double newWeightKg)
    {
        if (newWeightKg <= 0)
        {
            throw new ArgumentException("Weight must be positive.", nameof(newWeightKg));
        }

        WeightKg = Math.Round(newWeightKg, 1);
    }
}
