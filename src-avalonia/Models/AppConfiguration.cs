using CommunityToolkit.Mvvm.ComponentModel;

namespace SierraLauncher.Models;

/// <summary>
/// Application configuration settings (loaded from config.xml).
/// </summary>
public partial class AppConfiguration : ObservableObject
{
    [ObservableProperty]
    private string _startupDatabase = string.Empty;

    [ObservableProperty]
    private string _dosBoxPath = string.Empty;

    [ObservableProperty]
    private string _scummVMPath = string.Empty;

    [ObservableProperty]
    private string _titleWindowFormat = "%APP - %GAME";

    [ObservableProperty]
    private string _xmlDatabasePath = string.Empty;

    [ObservableProperty]
    private string _gameArtPath = string.Empty;

    [ObservableProperty]
    private bool _closeOnSave = false;

    [ObservableProperty]
    private bool _hideDatabase = false;

    [ObservableProperty]
    private bool _rememberLastDatabase = true;

    [ObservableProperty]
    private bool _showGameArtOnHover = true;
}
