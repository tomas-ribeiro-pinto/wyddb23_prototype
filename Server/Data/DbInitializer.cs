using BlazorWYDDB23.Shared.Models;

namespace BlazorWYDDB23.Server.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // Look for any days.
            if (context.Days.Any())
            {
                return;   // DB has been seeded
            }

            var days = new Day[]
            {
                new Day{Date=DateTime.Parse("2023-08-01")},
                new Day{Date=DateTime.Parse("2023-08-02")},
                new Day{Date=DateTime.Parse("2023-08-03")},
                new Day{Date=DateTime.Parse("2023-08-04")},
                new Day{Date=DateTime.Parse("2023-08-05")},
                new Day{Date=DateTime.Parse("2023-08-06")}
            };

            context.Days.AddRange(days);
            context.SaveChanges();
        }
    }
}