namespace MultipleFileLauncher;

public static class WindowStateTexts
{
    public const string Minimized = "Minimiert";
    public const string Maximized = "Maximiert";
    public const string Normal = "Normal";

    private const int SwShowNormal = 1;
    private const int SwMinimize = 6;
    private const int SwShowMaximized = 3;

    public static string ToDisplay(string stored) => stored switch
    {
        "Maximized" => Maximized,
        "Normal" => Normal,
        _ => Minimized
    };

    public static string ToStored(string display) => display switch
    {
        Maximized => "Maximized",
        Normal => "Normal",
        _ => "Minimized"
    };

    public static int ToShowCommand(string stored) => stored switch
    {
        "Maximized" => SwShowMaximized,
        "Normal" => SwShowNormal,
        _ => SwMinimize
    };
}
