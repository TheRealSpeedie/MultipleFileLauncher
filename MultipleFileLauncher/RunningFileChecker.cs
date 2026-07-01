using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MultipleFileLauncher;

public static class RunningFileChecker
{
    private const int ErrorSuccess = 0;
    private const int ErrorMoreData = 234;

    public static bool IsAlreadyOpen(string path)
    {
        if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
            return false;

        path = Path.GetFullPath(path);
        var ext = Path.GetExtension(path).ToLowerInvariant();

        if (ext is ".exe" or ".bat" or ".cmd" or ".com")
            return IsExecutableRunning(path);

        if (IsFileUsedByAnotherProcess(path))
            return true;

        return IsExecutableRunning(path);
    }

    private static bool IsExecutableRunning(string fullPath)
    {
        var name = Path.GetFileNameWithoutExtension(fullPath);
        foreach (var process in Process.GetProcessesByName(name))
        {
            try
            {
                if (process.MainModule?.FileName is string exePath &&
                    string.Equals(Path.GetFullPath(exePath), fullPath, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            catch
            {
            }
            finally
            {
                process.Dispose();
            }
        }

        return false;
    }

    private static bool IsFileUsedByAnotherProcess(string fullPath)
    {
        uint session = 0;
        var key = Guid.NewGuid().ToString();
        var result = RmStartSession(out session, 0, key);
        if (result != ErrorSuccess)
            return false;

        try
        {
            string[] files = [fullPath];
            result = RmRegisterResources(session, 1, files, 0, IntPtr.Zero, 0, IntPtr.Zero);
            if (result != ErrorSuccess)
                return false;

            uint count = 0;
            uint reason = 0;
            result = RmGetList(session, out _, ref count, null, ref reason);
            if (result == ErrorSuccess)
                return false;

            if (result != ErrorMoreData || count == 0)
                return false;

            var infos = new RM_PROCESS_INFO[count];
            result = RmGetList(session, out _, ref count, infos, ref reason);
            return result == ErrorSuccess && count > 0;
        }
        finally
        {
            RmEndSession(session);
        }
    }

    [DllImport("rstrtmgr.dll", CharSet = CharSet.Unicode)]
    private static extern int RmStartSession(out uint pSessionHandle, int dwSessionFlags, string strSessionKey);

    [DllImport("rstrtmgr.dll", CharSet = CharSet.Unicode)]
    private static extern int RmRegisterResources(
        uint pSessionHandle,
        uint nFiles,
        string[] rgsFileNames,
        uint nApplications,
        IntPtr rgApplications,
        uint nServices,
        IntPtr rgsServiceNames);

    [DllImport("rstrtmgr.dll")]
    private static extern int RmGetList(
        uint dwSessionHandle,
        out uint pnProcInfoNeeded,
        ref uint pnProcInfo,
        [In, Out] RM_PROCESS_INFO[]? rgAffectedApps,
        ref uint lpdwRebootReasons);

    [DllImport("rstrtmgr.dll")]
    private static extern int RmEndSession(uint pSessionHandle);

    [StructLayout(LayoutKind.Sequential)]
    private struct RM_PROCESS_INFO
    {
        public RM_UNIQUE_PROCESS Process;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string strAppName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string strServiceShortName;
        public int ApplicationType;
        public uint AppStatus;
        public uint TSSessionId;
        [MarshalAs(UnmanagedType.Bool)]
        public bool bRestartable;
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct RM_UNIQUE_PROCESS
    {
        public int dwProcessId;
        public long ProcessStartTime;
    }
}
