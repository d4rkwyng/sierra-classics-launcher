using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using SierraLauncher.Models;
using SierraLauncher.ViewModels;

namespace SierraLauncher.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    protected override void OnLoaded(RoutedEventArgs e)
    {
        base.OnLoaded(e);

        if (DataContext is MainWindowViewModel vm)
        {
            vm.RequestClose += (_, _) => Close();
            vm.RequestShowPreferences += OnShowPreferences;
            vm.RequestShowAbout += OnShowAbout;
        }
    }

    private void OnShowPreferences(object? sender, System.EventArgs e)
    {
        var preferencesWindow = new PreferencesWindow();
        if (DataContext is MainWindowViewModel mainVm)
        {
            preferencesWindow.DataContext = new PreferencesWindowViewModel(
                mainVm._configService,
                mainVm._gameService);
        }
        preferencesWindow.ShowDialog(this);
    }

    private void OnShowAbout(object? sender, System.EventArgs e)
    {
        var aboutWindow = new AboutWindow();
        aboutWindow.ShowDialog(this);
    }

    private void OnGamePointerEntered(object? sender, PointerEventArgs e)
    {
        if (sender is Border border && border.DataContext is GameInfo game)
        {
            if (DataContext is MainWindowViewModel vm)
            {
                vm.GameMouseEnterCommand.Execute(game);
            }
        }
    }

    private void OnGamePointerExited(object? sender, PointerEventArgs e)
    {
        if (DataContext is MainWindowViewModel vm)
        {
            vm.GameMouseLeaveCommand.Execute(null);
        }
    }
}
