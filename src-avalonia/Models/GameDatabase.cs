using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SierraLauncher.Models;

/// <summary>
/// Represents a game collection/database loaded from an XML file.
/// </summary>
public partial class GameDatabase : ObservableObject
{
    [ObservableProperty]
    private string _name = string.Empty;

    [ObservableProperty]
    private string _fileName = string.Empty;

    [ObservableProperty]
    private string _defaultPath = string.Empty;

    [ObservableProperty]
    private string _manualPath = string.Empty;

    [ObservableProperty]
    private string _collectionArtworkPath = string.Empty;

    [ObservableProperty]
    private List<GameInfo> _games = new();

    public int GameCount => Games.Count;
}
