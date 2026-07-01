using Microsoft.Win32;

namespace MultipleFileLauncher;

public static class StartupManager
{
    private const string RunKeyPath = @"Software\Microsoft\Windows\CurrentVersion\Run";
    private const string ValueName = "MultipleFileLauncher";

    public static bool IsEnabled()
    {
        using var key = Registry.CurrentUser.OpenSubKey(RunKeyPath);
        return key?.GetValue(ValueName) is string;
    }

    public static void Enable()
    {
        var path = $"\"{Application.ExecutablePath}\" --startup";
        using var key = Registry.CurrentUser.CreateSubKey(RunKeyPath, true);
        key?.SetValue(ValueName, path);
    }

    public static void Disable()
    {
        using var key = Registry.CurrentUser.OpenSubKey(RunKeyPath, true);
        key?.DeleteValue(ValueName, false);
    }
}
