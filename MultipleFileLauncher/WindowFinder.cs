using System.Runtime.InteropServices;

namespace MultipleFileLauncher;

public static class WindowFinder
{
    public static List<IntPtr> GetMainWindowsForProcess(int processId)
    {
        var result = new List<IntPtr>();

        EnumWindows((hWnd, _) =>
        {
            GetWindowThreadProcessId(hWnd, out uint windowProcessId);

            if (windowProcessId == processId &&
                IsWindowVisible(hWnd) &&
                GetWindowTextLength(hWnd) > 0)
            {
                result.Add(hWnd);
            }

            return true;
        }, IntPtr.Zero);

        return result;
    }

    private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

    [DllImport("user32.dll")]
    private static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);

    [DllImport("user32.dll")]
    private static extern bool IsWindowVisible(IntPtr hWnd);

    [DllImport("user32.dll")]
    private static extern int GetWindowTextLength(IntPtr hWnd);

    [DllImport("user32.dll")]
    private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);
}
