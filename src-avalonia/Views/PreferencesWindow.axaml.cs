using Avalonia.Controls;
using Avalonia.Interactivity;
using SierraLauncher.ViewModels;

namespace SierraLauncher.Views;

public partial class PreferencesWindow : Window
{
    public PreferencesWindow()
    {
        InitializeComponent();
    }

    protected override void OnLoaded(RoutedEventArgs e)
    {
        base.OnLoaded(e);

        if (DataContext is PreferencesWindowViewModel vm)
        {
            vm.RequestClose += (_, _) => Close();
        }
    }
}
