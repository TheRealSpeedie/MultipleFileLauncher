using System.Text.Json.Serialization;

namespace MultipleFileLauncher.Models;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
[JsonDerivedType(typeof(LaunchFolder), "folder")]
[JsonDerivedType(typeof(LaunchFile), "file")]
public abstract class LaunchItem
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; } = "";
}

public sealed class LaunchFolder : LaunchItem
{
    public List<LaunchItem> Children { get; set; } = [];
}

public sealed class LaunchFile : LaunchItem
{
    public string Path { get; set; } = "";
    public bool Enabled { get; set; } = true;
}
