using System.Diagnostics;

string[] programArguments = Environment.GetCommandLineArgs();
string[] smapiArguments = programArguments.Skip(1).ToArray();
using (var process = new Process())
{
    process.StartInfo.FileName = "StardewModdingAPI.exe";
    process.StartInfo.Arguments = string.Join(" ", smapiArguments); // Combine arguments into a single string
    process.StartInfo.UseShellExecute = false;
    process.StartInfo.CreateNoWindow = true;
    process.Start();
}
Console.WriteLine("Running Smapi in Silent mode...");

