using System;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SierraLauncher.Models;
using SierraLauncher.Services;

namespace SierraLauncher.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    internal readonly ConfigurationService _configService;
    internal readonly GameDatabaseService _gameService;
    private readonly GameLauncherService _launcherService;

    [ObservableProperty]
    private string _windowTitle = "Sierra Classics Launcher";

    [ObservableProperty]
    private ObservableCollection<string> _availableDatabases = new();

    [ObservableProperty]
    private string? _selectedDatabase;

    [ObservableProperty]
    private GameDatabase? _currentDatabase;

    [ObservableProperty]
    private ObservableCollection<GameInfo> _games = new();

    [ObservableProperty]
    private GameInfo? _hoveredGame;

    [ObservableProperty]
    private string? _currentArtworkPath;

    [ObservableProperty]
    private Bitmap? _currentArtwork;

    [ObservableProperty]
    private bool _isDatabaseVisible = true;

    [ObservableProperty]
    private bool _isManualAvailable;

    [ObservableProperty]
    private bool _closeAfterLaunch;

    [ObservableProperty]
    private string _statusMessage = string.Empty;

    public event EventHandler? RequestClose;
    public event EventHandler? RequestShowPreferences;
    public event EventHandler? RequestShowAbout;

    public MainWindowViewModel(
        ConfigurationService configService,
        GameDatabaseService gameService,
        GameLauncherService launcherService)
    {
        _configService = configService;
        _gameService = gameService;
        _launcherService = launcherService;

        Initialize();
    }

    private void Initialize()
    {
        // Load settings
        IsDatabaseVisible = !_configService.Configuration.HideDatabase;

        // Load available databases
        RefreshDatabaseList();

        // Select startup database
        SelectStartupDatabase();
    }

    private void RefreshDatabaseList()
    {
        var databases = _gameService.GetAvailableDatabases();
        AvailableDatabases = new ObservableCollection<string>(databases);
    }

    private void SelectStartupDatabase()
    {
        if (AvailableDatabases.Count == 0)
        {
            StatusMessage = "No game databases found";
            return;
        }

        var config = _configService.Configuration;
        string? dbToLoad = null;

        switch (config.StartupDatabase.ToLowerInvariant())
        {
            case "first":
                dbToLoad = AvailableDatabases.FirstOrDefault();
                break;

            case "last":
                dbToLoad = AvailableDatabases.LastOrDefault();
                break;

            case "random":
                var random = new Random();
                dbToLoad = AvailableDatabases[random.Next(AvailableDatabases.Count)];
                break;

            default:
                // Specific database name
                if (config.StartupDatabase.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
                {
                    dbToLoad = AvailableDatabases.FirstOrDefault(
                        d => d.Equals(config.StartupDatabase, StringComparison.OrdinalIgnoreCase));
                }
                dbToLoad ??= AvailableDatabases.FirstOrDefault();
                break;
        }

        if (dbToLoad != null)
        {
            SelectedDatabase = dbToLoad;
        }
    }

    partial void OnSelectedDatabaseChanged(string? value)
    {
        if (string.IsNullOrEmpty(value)) return;

        LoadDatabase(value);
    }

    private void LoadDatabase(string fileName)
    {
        CurrentDatabase = _gameService.LoadDatabase(fileName);

        if (CurrentDatabase == null)
        {
            StatusMessage = $"Failed to load database: {fileName}";
            Games.Clear();
            return;
        }

        Games = new ObservableCollection<GameInfo>(CurrentDatabase.Games);
        IsManualAvailable = !string.IsNullOrEmpty(CurrentDatabase.ManualPath);

        // Update window title
        UpdateWindowTitle();

        // Load collection artwork
        LoadArtwork(CurrentDatabase.CollectionArtworkPath);

        StatusMessage = $"Loaded: {CurrentDatabase.Name}";
    }

    private void UpdateWindowTitle()
    {
        var format = _configService.Configuration.TitleWindowFormat;
        var title = format
            .Replace("%APP", "Sierra Classics Launcher", StringComparison.OrdinalIgnoreCase)
            .Replace("%VER", "2.0.0", StringComparison.OrdinalIgnoreCase)
            .Replace("%GAME", CurrentDatabase?.Name ?? "", StringComparison.OrdinalIgnoreCase);

        WindowTitle = title;
    }

    private void LoadArtwork(string? path)
    {
        CurrentArtworkPath = path;

        if (string.IsNullOrEmpty(path) || !System.IO.File.Exists(path))
        {
            CurrentArtwork = null;
            return;
        }

        try
        {
            CurrentArtwork = new Bitmap(path);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading artwork: {ex.Message}");
            CurrentArtwork = null;
        }
    }

    [RelayCommand]
    private void LaunchGame(GameInfo? game)
    {
        if (game == null || CurrentDatabase == null) return;

        StatusMessage = $"Launching: {game.Name}";

        if (_launcherService.LaunchGame(game, CurrentDatabase))
        {
            if (CloseAfterLaunch)
            {
                RequestClose?.Invoke(this, EventArgs.Empty);
            }
        }
        else
        {
            StatusMessage = $"Failed to launch: {game.Name}";
        }
    }

    [RelayCommand]
    private void OpenManual()
    {
        if (CurrentDatabase == null || string.IsNullOrEmpty(CurrentDatabase.ManualPath)) return;

        StatusMessage = "Opening manual...";
        if (!_launcherService.OpenManual(CurrentDatabase.ManualPath))
        {
            StatusMessage = "Failed to open manual";
        }
    }

    [RelayCommand]
    private void GameMouseEnter(GameInfo? game)
    {
        if (game == null || !_configService.Configuration.ShowGameArtOnHover) return;

        if (!string.IsNullOrEmpty(game.ArtworkPath))
        {
            HoveredGame = game;
            LoadArtwork(game.ArtworkPath);
        }
    }

    [RelayCommand]
    private void GameMouseLeave()
    {
        if (!_configService.Configuration.ShowGameArtOnHover) return;

        HoveredGame = null;

        // Restore collection artwork
        if (CurrentDatabase != null)
        {
            LoadArtwork(CurrentDatabase.CollectionArtworkPath);
        }
    }

    [RelayCommand]
    private void ReloadDatabases()
    {
        _configService.LoadConfiguration();
        RefreshDatabaseList();

        if (SelectedDatabase != null && AvailableDatabases.Contains(SelectedDatabase))
        {
            LoadDatabase(SelectedDatabase);
        }
        else
        {
            SelectStartupDatabase();
        }

        StatusMessage = "Databases reloaded";
    }

    [RelayCommand]
    private void ShowPreferences()
    {
        RequestShowPreferences?.Invoke(this, EventArgs.Empty);
    }

    [RelayCommand]
    private void ShowAbout()
    {
        RequestShowAbout?.Invoke(this, EventArgs.Empty);
    }

    [RelayCommand]
    private void Exit()
    {
        // Save last database if configured
        if (_configService.Configuration.RememberLastDatabase && SelectedDatabase != null)
        {
            _configService.Configuration.StartupDatabase = SelectedDatabase;
            _configService.SaveConfiguration();
        }

        RequestClose?.Invoke(this, EventArgs.Empty);
    }
}
