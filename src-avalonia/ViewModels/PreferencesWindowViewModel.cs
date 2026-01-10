using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SierraLauncher.Models;
using SierraLauncher.Services;

namespace SierraLauncher.ViewModels;

public partial class PreferencesWindowViewModel : ViewModelBase
{
    private readonly ConfigurationService _configService;
    private readonly GameDatabaseService _gameService;

    // Configuration Settings
    [ObservableProperty]
    private string _dosBoxPath = string.Empty;

    [ObservableProperty]
    private string _scummVMPath = string.Empty;

    [ObservableProperty]
    private string _xmlDatabasePath = string.Empty;

    [ObservableProperty]
    private string _gameArtPath = string.Empty;

    [ObservableProperty]
    private string _titleWindowFormat = string.Empty;

    [ObservableProperty]
    private ObservableCollection<string> _startupOptions = new()
    {
        "First", "Last", "Random", "Custom"
    };

    [ObservableProperty]
    private string _selectedStartupOption = "First";

    [ObservableProperty]
    private string _customStartupDatabase = string.Empty;

    [ObservableProperty]
    private bool _isCustomStartupVisible;

    [ObservableProperty]
    private bool _closeOnSave;

    [ObservableProperty]
    private bool _hideDatabase;

    [ObservableProperty]
    private bool _rememberLastDatabase;

    [ObservableProperty]
    private bool _showGameArtOnHover;

    // Database Editing
    [ObservableProperty]
    private ObservableCollection<string> _availableDatabases = new();

    [ObservableProperty]
    private string? _selectedDatabase;

    [ObservableProperty]
    private GameDatabase? _currentDatabase;

    [ObservableProperty]
    private int _currentGameIndex;

    [ObservableProperty]
    private GameInfo? _currentGame;

    [ObservableProperty]
    private string _databaseName = string.Empty;

    [ObservableProperty]
    private int _numberOfGames = 1;

    [ObservableProperty]
    private string _defaultPath = string.Empty;

    [ObservableProperty]
    private string _manualPath = string.Empty;

    [ObservableProperty]
    private string _collectionArtPath = string.Empty;

    public event EventHandler? RequestClose;

    public PreferencesWindowViewModel(ConfigurationService configService, GameDatabaseService gameService)
    {
        _configService = configService;
        _gameService = gameService;

        LoadSettings();
        LoadDatabases();
    }

    private void LoadSettings()
    {
        var config = _configService.Configuration;

        DosBoxPath = config.DosBoxPath;
        ScummVMPath = config.ScummVMPath;
        XmlDatabasePath = config.XmlDatabasePath;
        GameArtPath = config.GameArtPath;
        TitleWindowFormat = config.TitleWindowFormat;
        CloseOnSave = config.CloseOnSave;
        HideDatabase = config.HideDatabase;
        RememberLastDatabase = config.RememberLastDatabase;
        ShowGameArtOnHover = config.ShowGameArtOnHover;

        // Determine startup option
        var startup = config.StartupDatabase.ToLowerInvariant();
        if (startup == "first" || startup == "last" || startup == "random")
        {
            SelectedStartupOption = char.ToUpper(startup[0]) + startup[1..];
            IsCustomStartupVisible = false;
        }
        else
        {
            SelectedStartupOption = "Custom";
            CustomStartupDatabase = config.StartupDatabase;
            IsCustomStartupVisible = true;
        }
    }

    private void LoadDatabases()
    {
        var databases = _gameService.GetAvailableDatabases();
        AvailableDatabases = new ObservableCollection<string>(databases);

        if (AvailableDatabases.Count > 0)
        {
            SelectedDatabase = AvailableDatabases[0];
        }
    }

    partial void OnSelectedStartupOptionChanged(string value)
    {
        IsCustomStartupVisible = value == "Custom";
    }

    partial void OnSelectedDatabaseChanged(string? value)
    {
        if (string.IsNullOrEmpty(value)) return;

        CurrentDatabase = _gameService.LoadDatabase(value);
        if (CurrentDatabase != null)
        {
            DatabaseName = CurrentDatabase.Name;
            NumberOfGames = CurrentDatabase.Games.Count;
            DefaultPath = CurrentDatabase.DefaultPath;
            ManualPath = CurrentDatabase.ManualPath;
            CollectionArtPath = CurrentDatabase.CollectionArtworkPath;

            CurrentGameIndex = 0;
            LoadCurrentGame();
        }
    }

    private void LoadCurrentGame()
    {
        if (CurrentDatabase == null || CurrentDatabase.Games.Count == 0)
        {
            CurrentGame = null;
            return;
        }

        if (CurrentGameIndex >= 0 && CurrentGameIndex < CurrentDatabase.Games.Count)
        {
            CurrentGame = CurrentDatabase.Games[CurrentGameIndex];
        }
    }

    [RelayCommand]
    private void NextGame()
    {
        if (CurrentDatabase == null) return;

        if (CurrentGameIndex < CurrentDatabase.Games.Count - 1)
        {
            CurrentGameIndex++;
            LoadCurrentGame();
        }
    }

    [RelayCommand]
    private void PreviousGame()
    {
        if (CurrentGameIndex > 0)
        {
            CurrentGameIndex--;
            LoadCurrentGame();
        }
    }

    [RelayCommand]
    private void Save()
    {
        // Save configuration
        var config = _configService.Configuration;
        config.DosBoxPath = DosBoxPath;
        config.ScummVMPath = ScummVMPath;
        config.XmlDatabasePath = XmlDatabasePath;
        config.GameArtPath = GameArtPath;
        config.TitleWindowFormat = TitleWindowFormat;
        config.CloseOnSave = CloseOnSave;
        config.HideDatabase = HideDatabase;
        config.RememberLastDatabase = RememberLastDatabase;
        config.ShowGameArtOnHover = ShowGameArtOnHover;

        config.StartupDatabase = SelectedStartupOption == "Custom"
            ? CustomStartupDatabase
            : SelectedStartupOption;

        _configService.SaveConfiguration();

        // Save current database if modified
        if (CurrentDatabase != null && !string.IsNullOrEmpty(SelectedDatabase))
        {
            CurrentDatabase.Name = DatabaseName;
            CurrentDatabase.DefaultPath = DefaultPath;
            CurrentDatabase.ManualPath = ManualPath;
            CurrentDatabase.CollectionArtworkPath = CollectionArtPath;

            _gameService.SaveDatabase(CurrentDatabase);
        }

        if (CloseOnSave)
        {
            RequestClose?.Invoke(this, EventArgs.Empty);
        }
    }

    [RelayCommand]
    private void Close()
    {
        RequestClose?.Invoke(this, EventArgs.Empty);
    }

    [RelayCommand]
    private void NewDatabase()
    {
        // Create a new empty database
        var newDb = new GameDatabase
        {
            FileName = "NewDatabase.xml",
            Name = "New Database",
            Games = new System.Collections.Generic.List<GameInfo>
            {
                new GameInfo { Name = "Game 1" }
            }
        };

        _gameService.SaveDatabase(newDb);
        LoadDatabases();
        SelectedDatabase = newDb.FileName;
    }

    [RelayCommand]
    private void DeleteDatabase()
    {
        if (string.IsNullOrEmpty(SelectedDatabase)) return;

        if (_gameService.DeleteDatabase(SelectedDatabase))
        {
            LoadDatabases();
            if (AvailableDatabases.Count > 0)
            {
                SelectedDatabase = AvailableDatabases[0];
            }
        }
    }
}
