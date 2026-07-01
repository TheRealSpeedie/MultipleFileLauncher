using System.Diagnostics;
using System.Runtime.InteropServices;
using MultipleFileLauncher.Models;

namespace MultipleFileLauncher;

public static class FileLauncher
{
    public static void LaunchAll(AppSettings settings)
    {
        foreach (var file in settings.GetAllFiles())
            LaunchFile(file, settings.LaunchWindowState);
    }

    public static void LaunchFile(LaunchFile file, string windowState)
    {
        if (!file.Enabled || string.IsNullOrWhiteSpace(file.Path) || !File.Exists(file.Path))
            return;

        if (RunningFileChecker.IsAlreadyOpen(file.Path))
            return;

        try
        {
            var processHandle = ShellLauncher.Open(file.Path, windowState);
            if (processHandle != IntPtr.Zero)
                ScheduleWindowStateFallback(processHandle, file.Path, windowState);
        }
        catch
        {
            Process.Start(new ProcessStartInfo(file.Path)
            {
                UseShellExecute = true,
                WindowStyle = windowState == "Minimized"
                    ? ProcessWindowStyle.Minimized
                    : windowState == "Maximized"
                        ? ProcessWindowStyle.Maximized
                        : ProcessWindowStyle.Normal
            });
        }
    }

    private static void ScheduleWindowStateFallback(IntPtr processHandle, string filePath, string windowState)
    {
        if (windowState == "Normal")
        {
            CloseHandle(processHandle);
            return;
        }

        var showCommand = WindowStateTexts.ToShowCommand(windowState);
        var processId = (int)GetProcessId(processHandle);

        CloseHandle(processHandle);

        Task.Run(async () =>
        {
            try
            {
                for (var i = 0; i < 20; i++)
                {
                    var windows = WindowFinder.GetMainWindowsForProcess(processId);

                    foreach (var hwnd in windows)
                        ShowWindowAsync(hwnd, showCommand);

                    if (windows.Count > 0)
                        break;

                    await Task.Delay(250);
                }
            }
            catch
            {
            }
        });
    }

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern uint GetProcessId(IntPtr hProcess);

    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool CloseHandle(IntPtr hObject);

    [DllImport("user32.dll")]
    private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
}
