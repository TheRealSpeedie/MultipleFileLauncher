namespace MultipleFileLauncher
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            ApplicationConfiguration.Initialize();

            if (args.Contains("--startup", StringComparer.OrdinalIgnoreCase))
            {
                var settings = AppSettings.Load();
                FileLauncher.LaunchAll(settings);
                return;
            }

            Application.Run(new Form1());
        }
    }
}
