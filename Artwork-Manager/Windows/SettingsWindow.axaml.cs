using System.Reflection;
using ArtworkManager.Database.Contexts;
using ArtworkManager.Database.Entities;
using ArtworkManager.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace ArtworkManager.Windows;

public class SettingsWindow : Window
{
    public SettingsWindow()
    {
        InitializeComponent();
        DataContext = new SettingsWindowBaseViewModel();

#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void Window_OnActivated(object? sender, EventArgs e)
    {
        var vm = (SettingsWindowBaseViewModel) DataContext;
        
        vm.DbLocationText = Assembly.GetExecutingAssembly().Location + "\\artwork-manager.db";
    }
}