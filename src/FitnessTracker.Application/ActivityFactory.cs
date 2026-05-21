using FitnessTracker.Domain;

namespace FitnessTracker.Application;

public static class ActivityFactory
{
    public static Activity Create(ActivityInput input)
    {
        if (input is null)
        {
            throw new ArgumentNullException(nameof(input));
        }

        return input.Type.ToLower() switch
        {
            "cardio" => new CardioActivity(
                input.Name,
                TimeSpan.FromMinutes(input.DurationMinutes),
                new Distance(input.DistanceKm)
            ),

            "strength" => new StrengthActivity(
                input.Name,
                TimeSpan.FromMinutes(input.DurationMinutes),
                input.Sets,
                input.RepsPerSet,
                input.WeightKg
            ),

            _ => throw new ArgumentException("Unsupported activity type.")
        };
    }
}