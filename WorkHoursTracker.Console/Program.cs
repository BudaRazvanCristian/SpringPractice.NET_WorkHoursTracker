using WorkHoursTracker.ConsoleClient;

Console.Write("Enter your username: ");
var username = Console.ReadLine() ?? "default";

var client = new ApiClient();
bool running = true;

while (running)
{
    Console.WriteLine("\n===== Work Tracker Menu =====");
    Console.WriteLine("1. Start Work");
    Console.WriteLine("2. Stop Work");
    Console.WriteLine("3. View Today's Hours");
    Console.WriteLine("4. View Weekly Summary");
    Console.WriteLine("5. View Full Log");
    Console.WriteLine("6. Exit");
    Console.Write("Select an option: ");
    
    var input = Console.ReadLine();

    switch (input)
    {
        case "1":
            Console.WriteLine(await client.StartWorkAsync(username));
            break;
        case "2":
            Console.WriteLine(await client.StopWorkAsync(username));
            break;
        case "3":
            Console.WriteLine(await client.GetTodayAsync(username));
            break;
        case "4":
            Console.WriteLine(await client.GetWeekAsync(username));
            break;
        case "5":
            Console.WriteLine(await client.GetLogsAsync(username));
            break;
        case "6":
            running = false;
            break;
        default:
            Console.WriteLine("Invalid option.");
            break;
    }
}
