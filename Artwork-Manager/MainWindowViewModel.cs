using System.ComponentModel;
using System.Runtime.CompilerServices;
using ArtworkManager.Windows;
using Avalonia.Controls;
using JetBrains.Annotations;

namespace ArtworkManager.ViewModels;

public class MainWindowBaseViewModel : BaseViewModel
{
    private readonly Window _window;
    
    public MainWindowBaseViewModel()
    {
        
    }

    public MainWindowBaseViewModel(Window window)
    {
        _window = window;
    }
    
    public void OpenArtworkBrowser()
    {
        var settingsWindow = new ArtworkBrowser();
        settingsWindow.Show();
    }
    
    public void OpenManageDatabaseWindow()
    {
        var manageDatabaseWindow = new ManageDatabaseWindow();
        manageDatabaseWindow.Show();
    }
    
    public void OpenSettingsWindow()
    {
        var settingsWindow = new SettingsWindow();
        settingsWindow.Show();
    }

    public async void AddNewArtworkCommand()
    {
        var dialog = new OpenFileDialog();

        dialog.AllowMultiple = false;

        var result = await dialog.ShowAsync(_window);

        var path = result.FirstOrDefault();

        await new EditArtworkWindow(path).ShowDialog(_window);
    }
}