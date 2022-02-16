using System.ComponentModel;
using System.Runtime.CompilerServices;
using ArtworkManager.Windows;
using JetBrains.Annotations;

namespace ArtworkManager.ViewModels;

public class MainWindowBaseViewModel : BaseViewModel
{
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
}