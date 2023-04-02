using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Nein.Base;

namespace ArtworkManager.Windows;

public partial class FullscreenWindow : ReactiveWindow<FullscreenWindowViewModel>
{
    public FullscreenWindow()
    {
        
    }
    
    public FullscreenWindow(string artworkPath)
    {
        ViewModel = new FullscreenWindowViewModel(artworkPath);

        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}