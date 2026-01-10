using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using SierraLauncher.Views;
using SierraLauncher.ViewModels;
using SierraLauncher.Services;

namespace SierraLauncher;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var configService = new ConfigurationService();
            var gameService = new GameDatabaseService(configService);
            var launcherService = new GameLauncherService(configService);

            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(configService, gameService, launcherService)
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}
