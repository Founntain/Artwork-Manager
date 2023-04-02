using System;
using System.Diagnostics;
using System.IO;
using ArtworkManager.Data.Contexts;
using ArtworkManager.Data.Entities;
using ArtworkManager.Data.Enums;
using ArtworkManager.UI_Extensions;
using ArtworkManager.Windows;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Nein.Base;
using Nein.Extensions;
using Splat;

namespace ArtworkManager.Views;

public partial class HomeView : ReactiveControl<HomeViewModel>
{
    public HomeView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void AddArtwork_OnClick(object? sender, RoutedEventArgs e)
    {
        var mainWindow = Locator.Current.GetService<Windows.MainWindow>();

        if (mainWindow?.ViewModel == default) return;

        mainWindow.ViewModel.MainView = mainWindow.ViewModel.AddArtworkViewModel;
    }

    private async void Debug_OnClick(object? sender, RoutedEventArgs e)
    {
        var _mainWindow = Locator.Current.GetRequiredService<MainWindow>();
        
        var dialog = new OpenFolderDialog()
        {
            Title = "Select your artwork file",
        };
        
        var result = await dialog.ShowAsync(_mainWindow);

        if (result == default)
        {
            await MessageBox.ShowDialogAsync(_mainWindow, "Did you even selected a directory?!");
            return;
        }

        var files = Directory.GetFiles(result, "*.*", SearchOption.AllDirectories);

        await using (var context = new DatabaseContext())
        {
            foreach (var file in files)
            {
                var databasePath = $"data/files/{Guid.NewGuid()}{Path.GetExtension(file)}";
                
                File.Copy(file, databasePath);

                var artwork = new Artwork()
                {
                    Name = Path.GetFileNameWithoutExtension(file),
                    ArtworkType = ArtworkType.Image,
                    ArtworkAcquiredType = ArtworkAcquiredType.Commission,
                    Filepath = databasePath,
                };

                await context.AddAsync(artwork);
            }

            var saveChanges = await context.SaveChangesAsync();
            
            Debug.WriteLine("ENTRIES IMPORTED: " + saveChanges);
        }
    }

    private void AddCharacter_OnClick(object? sender, RoutedEventArgs e)
    {
        var mainWindow = Locator.Current.GetService<Windows.MainWindow>();

        if (mainWindow?.ViewModel == default) return;

        mainWindow.ViewModel.MainView = mainWindow.ViewModel.AddCharacterViewModel;
    }
}