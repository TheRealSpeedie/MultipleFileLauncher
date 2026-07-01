using System.Runtime.InteropServices;

namespace MultipleFileLauncher;

public static class ShellLauncher
{
    private const uint SeeMaskNoCloseProcess = 0x00000040;
    private const uint SeeMaskFlagNoUi = 0x00000400;

    public static IntPtr Open(string path, string windowState)
    {
        var info = new ShellExecuteInfo
        {
            cbSize = Marshal.SizeOf<ShellExecuteInfo>(),
            fMask = SeeMaskNoCloseProcess | SeeMaskFlagNoUi,
            lpVerb = "open",
            lpFile = path,
            nShow = WindowStateTexts.ToShowCommand(windowState)
        };

        if (!ShellExecuteEx(ref info))
            throw new InvalidOperationException($"ShellExecuteEx failed for '{path}'.");

        return info.hProcess;
    }

    [DllImport("shell32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    private static extern bool ShellExecuteEx(ref ShellExecuteInfo lpExecInfo);

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    private struct ShellExecuteInfo
    {
        public int cbSize;
        public uint fMask;
        public IntPtr hwnd;
        public string lpVerb;
        public string lpFile;
        public string? lpParameters;
        public string? lpDirectory;
        public int nShow;
        public IntPtr hInstApp;
        public IntPtr lpIDList;
        public string? lpClass;
        public IntPtr hkeyClass;
        public uint dwHotKey;
        public IntPtr hMonitor;
        public IntPtr hProcess;
    }
}
