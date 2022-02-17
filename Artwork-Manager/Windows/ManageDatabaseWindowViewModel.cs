using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using ArtworkManager.Database.Entities;
using ArtworkManager.Windows;
using Avalonia;
using Avalonia.Controls;

namespace ArtworkManager.ViewModels;

public class ManageDatabaseWindowViewModel : BaseViewModel
{
    private ObservableCollection<object> _tableData;
    private ObservableCollection<string> _tables;
    private object _selectedDatabaseEntry;

    public ObservableCollection<object> TableData
    {
        get => _tableData;
        set
        {
            _tableData = value; 
            OnPropertyChanged();
        }
    }

    public ObservableCollection<string> Tables
    {
        get => _tables;
        set
        {
            _tables = value; 
            OnPropertyChanged();
        }
    }

    public object SelectedDatabaseEntry
    {
        get => _selectedDatabaseEntry;
        set
        {
            _selectedDatabaseEntry = value; 
            OnPropertyChanged();
        }
    }

    public void EditDatabaseEntry()
    { 
        if (SelectedDatabaseEntry is Artwork)
        {
            var window = new EditArtworkWindow((Artwork) SelectedDatabaseEntry);
            window.Show();
        }
        
        if (SelectedDatabaseEntry is Artist)
        {
            
        }
        
        if (SelectedDatabaseEntry is Collection)
        {
            
        }
    }
    
    public void OpenFileInExplorer()
    {
        var artwork = (Artwork) SelectedDatabaseEntry;

        using (var p = new Process())
        {
            p.StartInfo.FileName = artwork.Filepath;
            p.StartInfo.UseShellExecute = true;
            p.Start();
        }
        
        // Process.Start(x);
    }

    public void OpenFullscreen()
    {
       var artwork = (Artwork) SelectedDatabaseEntry;
       
       new FullscreenArtworkWindow(artwork.Filepath).Show();
    }
}