using System;
using System.IO;
using System.Linq;
using ArtworkManager.Data.Contexts;
using ArtworkManager.Data.Entities;
using ArtworkManager.UI_Extensions;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Nein.Base;
using Nein.Extensions;
using Splat;

namespace ArtworkManager.Views;

public partial class AddArtworkView : ReactiveControl<AddArtworkViewModel>
{
    private readonly Windows.MainWindow _mainWindow;
    
    public AddArtworkView()
    {
        _mainWindow = Locator.Current.GetRequiredService<Windows.MainWindow>();
        
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private async void SelectArtwork_OnClick(object? sender, RoutedEventArgs e)
    {
        var dialog = new OpenFileDialog
        {
            Title = "Select your artwork file",
            AllowMultiple = false
        };
        
        var result = await dialog.ShowAsync(_mainWindow);

        if (result == default)
        {
            await MessageBox.ShowDialogAsync(_mainWindow, "Did you even selected a file?!");
            return;
        }

        var path = result.FirstOrDefault();

        if (path == null)
        {
            await MessageBox.ShowDialogAsync(_mainWindow, "Could not resolve filepath of your file");
            return;
        }

        ViewModel.ArtworkFilePath = path;
    }

    private async void Save_OnClick(object? sender, RoutedEventArgs e)
    {
        var databasePath = $"data/files/{Guid.NewGuid()}{Path.GetExtension(ViewModel.ArtworkFilePath)}";
        
        File.Copy(ViewModel.ArtworkFilePath, databasePath);

        var artwork = new Artwork()
        {
            Name = ViewModel.Name,
            Description = ViewModel.Description,
            Filepath = databasePath,
            IsNsfw = ViewModel.IsNsfw,
            ArtworkType = ViewModel.ArtworkType,
            ArtworkAcquiredType = ViewModel.ArtworkAcquiredType
        };

        await using (var context = new DatabaseContext())
        {
            context.Add(artwork);

            var saveChanges = await context.SaveChangesAsync();

            if (saveChanges != 1)
            {
                await MessageBox.ShowDialogAsync(_mainWindow, "Changes could not be saved");
            }
            else
            {
                await MessageBox.ShowDialogAsync(_mainWindow, "Artwork successfully saved into the database");
            }
        }
    }
}