using FitnessTracker.Application;
using FitnessTracker.Domain;
using FitnessTracker.Infrastructure;

var filePath = "fitness-sessions.json";

var store = new JsonTrainingSessionStore(filePath);
var repository = new JsonFitnessSessionRepository(store);

await repository.LoadAsync();

var service = new FitnessTrackerService(repository);
var analyticsService = new FitnessAnalyticsService();
var userProfile = CreateUserProfile();

while (true)
{
    Console.WriteLine();
    Console.WriteLine("FitnessTracker Console");
    Console.WriteLine("1. Add workout session");
    Console.WriteLine("2. Show session summary");
    Console.WriteLine("3. Save sessions to JSON");
    Console.WriteLine("4. Load sessions from JSON");
    Console.WriteLine("5. Show analytics");
    Console.WriteLine("6. Exit");
    Console.Write("Choose action: ");

    var key = Console.ReadLine()?.Trim();
    Console.WriteLine();

    if (key == "1")
    {
        AddWorkoutSession(userProfile, service);
    }
    else if (key == "2")
    {
        ShowSummary(userProfile, service);
    }
    else if (key == "3")
    {
        await SaveSessions(repository);
    }
    else if (key == "4")
    {
        await LoadSessions(repository);
    }
    else if (key == "5")
    {
        ShowAnalytics(userProfile, service, analyticsService);
    }
    else if (key == "6")
    {
        await repository.SaveAsync();
        break;
    }
    else
    {
        Console.WriteLine("Unknown command. Please enter a number from 1 to 6.");
    }
}

static UserProfile CreateUserProfile()
{
    Console.WriteLine("Welcome to FitnessTracker.");
    Console.Write("Enter your name: ");
    var name = Console.ReadLine()?.Trim() ?? string.Empty;

    Console.Write("Enter your age: ");
    var age = int.TryParse(Console.ReadLine(), out var parsedAge) ? parsedAge : 0;

    Console.Write("Enter your weight in kg: ");
    var weight = double.TryParse(Console.ReadLine(), out var parsedWeight) ? parsedWeight : 0;

    Console.Write("Enter your height in cm: ");
    var height = double.TryParse(Console.ReadLine(), out var parsedHeight) ? parsedHeight : 0;

    try
    {
        var profile = new UserProfile(name, age, weight, height);
        Console.WriteLine($"Hello, {profile.Name}! Your profile is ready.");
        return profile;
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"Invalid profile: {ex.Message}");
        return CreateUserProfile();
    }
}

static void AddWorkoutSession(UserProfile user, FitnessTrackerService service)
{
    try
    {
        Console.Write("Enter session date (yyyy-MM-dd) or leave empty for today: ");
        var inputDate = Console.ReadLine();
        var date = DateTime.TryParse(inputDate, out var parsedDate)
            ? parsedDate
            : DateTime.Today;

        var activities = new List<ActivityInput>();

        while (true)
        {
            Console.Write("Activity name: ");
            var name = Console.ReadLine()?.Trim() ?? string.Empty;

            Console.Write("Type (cardio/strength): ");
            var type = Console.ReadLine()?.Trim() ?? string.Empty;

            Console.Write("Duration in minutes: ");
            var duration = double.TryParse(Console.ReadLine(), out var parsedDuration)
                ? parsedDuration
                : 0;

            var activity = new ActivityInput
            {
                Name = name,
                Type = type,
                DurationMinutes = duration
            };

            if (type.Equals("cardio", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Distance in km: ");
                activity = activity with
                {
                    DistanceKm = double.TryParse(Console.ReadLine(), out var parsedDistance)
                        ? parsedDistance
                        : 0
                };
            }
            else if (type.Equals("strength", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Sets: ");
                activity = activity with
                {
                    Sets = int.TryParse(Console.ReadLine(), out var parsedSets)
                        ? parsedSets
                        : 0
                };

                Console.Write("Reps per set: ");
                activity = activity with
                {
                    RepsPerSet = int.TryParse(Console.ReadLine(), out var parsedReps)
                        ? parsedReps
                        : 0
                };

                Console.Write("Weight in kg: ");
                activity = activity with
                {
                    WeightKg = double.TryParse(Console.ReadLine(), out var parsedWeight)
                        ? parsedWeight
                        : 0
                };
            }
            else
            {
                Console.WriteLine("Unknown activity type. Use cardio or strength.");
                continue;
            }

            Console.Write("Notes for this activity: ");
            activity = activity with
            {
                Notes = Console.ReadLine()?.Trim() ?? string.Empty
            };

            activities.Add(activity);

            Console.Write("Add another activity? (y/n): ");
            var next = Console.ReadLine()?.Trim().ToLowerInvariant();

            if (next != "y" && next != "yes")
            {
                break;
            }
        }

        var request = new CreateTrainingSessionRequest
        {
            UserId = user.Id,
            Date = date,
            Activities = activities,
            Notes = "Console workout session"
        };

        var session = service.CreateTrainingSession(request);

        Console.WriteLine($"Session created: {session.Id}");
        Console.WriteLine($"Total duration: {session.TotalDurationMinutes():0.##} minutes");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Unable to create session: {ex.Message}");
    }
}

static void ShowSummary(UserProfile user, FitnessTrackerService service)
{
    try
    {
        var summary = service.GetSummary(user.Id);

        Console.WriteLine("--- Session summary ---");
        Console.WriteLine($"User ID: {summary.UserId}");
        Console.WriteLine($"Last session: {summary.LastSessionDate:yyyy-MM-dd}");
        Console.WriteLine($"Sessions count: {summary.SessionsCount}");
        Console.WriteLine($"Total duration: {summary.TotalDurationMinutes:0.#} minutes");
        Console.WriteLine($"Total activities: {summary.TotalActivities}");
        Console.WriteLine($"Total weight lifted: {summary.TotalWeightLifted:0.##}");
        Console.WriteLine(summary.SummaryText);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Unable to show summary: {ex.Message}");
    }
}

static async Task SaveSessions(JsonFitnessSessionRepository repository)
{
    try
    {
        await repository.SaveAsync();
        Console.WriteLine("Sessions saved to JSON file.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Unable to save sessions: {ex.Message}");
    }
}

static async Task LoadSessions(JsonFitnessSessionRepository repository)
{
    try
    {
        await repository.LoadAsync();
        Console.WriteLine("Sessions loaded from JSON file.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Unable to load sessions: {ex.Message}");
    }
}

static void ShowAnalytics(
    UserProfile user,
    FitnessTrackerService service,
    FitnessAnalyticsService analyticsService)
{
    try
    {
        var sessions = service.GetSessionsForUser(user.Id);

        if (sessions.Count == 0)
        {
            Console.WriteLine("No sessions found for analytics.");
            return;
        }

        Console.WriteLine("--- Analytics ---");
        Console.WriteLine($"Total duration: {analyticsService.GetTotalDurationMinutes(sessions):0.#} minutes");
        Console.WriteLine($"Total activities: {analyticsService.GetTotalActivities(sessions)}");

        var sortedSessions = analyticsService.GetSessionsSortedByDate(sessions);
        Console.WriteLine($"Newest session: {sortedSessions.First().Date:yyyy-MM-dd}");

        var groupedByDate = analyticsService.CountSessionsByDate(sessions);

        Console.WriteLine("Sessions by date:");
        foreach (var item in groupedByDate)
        {
            Console.WriteLine($"{item.Key:yyyy-MM-dd}: {item.Value}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Unable to show analytics: {ex.Message}");
    }
}