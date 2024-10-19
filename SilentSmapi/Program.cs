using System.Diagnostics;
namespace SilentSmapi {
    class Program {
        static string[] programArguments = Environment.GetCommandLineArgs();
        static string[] smapiArguments = programArguments.Skip(1)
            .Concat(new[] { "--developer-mode-off", "--no-terminal" })
            .ToArray();
        public static bool IsSMAPIRunning() {
            return Process.GetProcesses()
                .Any(p => p.MainWindowTitle.Contains("running SMAPI", StringComparison.OrdinalIgnoreCase));
        }
        static void Main(string[] args) {
            Console.Title = "SilentSmapi";
            using (var process = new Process()) {
                process.StartInfo.FileName = "StardewModdingAPI.exe";
                process.StartInfo.Arguments = string.Join(" ", smapiArguments);
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                try {
                    process.Start();
                    Console.Write("Starting SMAPI in \"Silent\" mode...\n");
                    while (true) {
                        Thread.Sleep(100);
                            if (IsSMAPIRunning() == true) {
                                Thread.Sleep(1000);
                                Console.WriteLine("StardewModdingAPI.exe has finished loading! Hiding...");
                                Thread.Sleep(2500);
                                Environment.Exit(0); 
                            }
                    }
                }
                catch (Exception ex) {
                    Console.WriteLine("Error starting or monitoring SMAPI process: " + ex.Message + " (make sure this is in the root Stardew directory)");
                }
            }
        }
    }
}