// print current directory
Console.WriteLine($"Current Directory: {Environment.CurrentDirectory}");
string? path = Environment.GetCommandLineArgs().Length > 1 ? Environment.GetCommandLineArgs()[1] : null;
if (string.IsNullOrEmpty(path))
{
    Console.WriteLine("Insert path to JSON file to be parsed:");
    path = Console.ReadLine();
}
if (string.IsNullOrEmpty(path))
{
    Console.WriteLine("No path provided. Exiting.");
    return;
}
Console.WriteLine($"Parsing JSON file at: {path}");
if (!File.Exists(path))
{
    Console.WriteLine($"File not found: {path}");
    return;
}
try
{
    string jsonContent = await File.ReadAllTextAsync(path);
    System.Text.Json.JsonSerializer.Deserialize<object>(jsonContent);
    Console.WriteLine("JSON file parsed successfully.");
}
catch (System.Text.Json.JsonException ex)
{
    Console.WriteLine($"Error parsing JSON file: {ex.Message}");
    return;
}
catch (Exception ex)
{
    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
    return;
}
