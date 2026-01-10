using CommunityToolkit.Mvvm.ComponentModel;

namespace SierraLauncher.Models;

/// <summary>
/// Represents a single game entry in a game database.
/// </summary>
public partial class GameInfo : ObservableObject
{
    [ObservableProperty]
    private string _name = string.Empty;

    [ObservableProperty]
    private string _program = string.Empty;  // "dosbox", "scummvm", or empty for custom

    [ObservableProperty]
    private string _path = string.Empty;

    [ObservableProperty]
    private string _executable = string.Empty;

    [ObservableProperty]
    private string _commandLine = string.Empty;

    [ObservableProperty]
    private string _artworkPath = string.Empty;

    public GameInfo() { }

    public GameInfo(string name, string program, string path, string executable, string commandLine, string artworkPath)
    {
        Name = name;
        Program = program;
        Path = path;
        Executable = executable;
        CommandLine = commandLine;
        ArtworkPath = artworkPath;
    }
}
