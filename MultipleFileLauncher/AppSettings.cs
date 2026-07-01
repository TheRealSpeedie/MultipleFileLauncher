using System.Text.Json;
using System.Text.Json.Serialization;
using MultipleFileLauncher.Models;

namespace MultipleFileLauncher;

public sealed class AppSettings
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    public List<LaunchItem> RootItems { get; set; } = [];
    public bool StartWithWindows { get; set; }
    public string LaunchWindowState { get; set; } = "Minimized";

    public List<string>? FilePaths { get; set; }

    public static string SettingsPath =>
        Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "MultipleFileLauncher",
            "settings.json");

    public static AppSettings Load()
    {
        if (!File.Exists(SettingsPath))
            return new AppSettings();

        try
        {
            var json = File.ReadAllText(SettingsPath);
            var settings = JsonSerializer.Deserialize<AppSettings>(json, JsonOptions) ?? new AppSettings();
            settings.MigrateLegacyPaths();
            return settings;
        }
        catch
        {
            return new AppSettings();
        }
    }

    public void Save()
    {
        FilePaths = null;
        var dir = Path.GetDirectoryName(SettingsPath)!;
        Directory.CreateDirectory(dir);
        File.WriteAllText(SettingsPath, JsonSerializer.Serialize(this, JsonOptions));
    }

    private void MigrateLegacyPaths()
    {
        if (FilePaths is not { Count: > 0 })
            return;

        foreach (var path in FilePaths)
        {
            if (string.IsNullOrWhiteSpace(path))
                continue;

            RootItems.Add(new LaunchFile
            {
                Name = Path.GetFileNameWithoutExtension(path),
                Path = path
            });
        }

        FilePaths = null;
        Save();
    }

    public IEnumerable<LaunchFile> GetAllFiles()
    {
        foreach (var item in RootItems)
        {
            foreach (var file in CollectFiles(item))
                yield return file;
        }
    }

    private static IEnumerable<LaunchFile> CollectFiles(LaunchItem item)
    {
        if (item is LaunchFile file)
        {
            if (file.Enabled)
                yield return file;
            yield break;
        }

        if (item is LaunchFolder folder)
        {
            foreach (var child in folder.Children)
            {
                foreach (var f in CollectFiles(child))
                    yield return f;
            }
        }
    }

    public LaunchItem? FindById(string id) => FindById(RootItems, id);

    private static LaunchItem? FindById(List<LaunchItem> items, string id)
    {
        foreach (var item in items)
        {
            if (item.Id == id)
                return item;

            if (item is LaunchFolder folder)
            {
                var found = FindById(folder.Children, id);
                if (found != null)
                    return found;
            }
        }

        return null;
    }

    public LaunchFolder? FindParentFolder(string id) => FindParentFolder(RootItems, id, null);

    private static LaunchFolder? FindParentFolder(List<LaunchItem> items, string id, LaunchFolder? parent)
    {
        foreach (var item in items)
        {
            if (item.Id == id)
                return parent;

            if (item is LaunchFolder folder)
            {
                var found = FindParentFolder(folder.Children, id, folder);
                if (found != null)
                    return found;
            }
        }

        return null;
    }

    public List<LaunchItem> GetTargetContainer(LaunchItem? selected)
    {
        if (selected is LaunchFolder folder)
            return folder.Children;

        if (selected != null)
        {
            var parent = FindParentFolder(selected.Id);
            if (parent != null)
                return parent.Children;
        }

        return RootItems;
    }

    public bool RemoveById(string id)
    {
        return RemoveFrom(RootItems, id);
    }

    private static bool RemoveFrom(List<LaunchItem> items, string id)
    {
        for (var i = 0; i < items.Count; i++)
        {
            if (items[i].Id == id)
            {
                items.RemoveAt(i);
                return true;
            }

            if (items[i] is LaunchFolder folder && RemoveFrom(folder.Children, id))
                return true;
        }

        return false;
    }

    public bool MoveItem(string id, LaunchFolder? targetFolder, int targetIndex)
    {
        var item = FindById(id);
        if (item == null)
            return false;

        var sourceList = FindParentFolder(id)?.Children ?? RootItems;
        if (!sourceList.Remove(item))
            return false;

        var dest = targetFolder?.Children ?? RootItems;
        targetIndex = Math.Clamp(targetIndex, 0, dest.Count);
        dest.Insert(targetIndex, item);
        return true;
    }
}
