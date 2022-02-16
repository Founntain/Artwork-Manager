using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ArtworkManager.Windows;

public class MessageBoxWindow : Window
{
    public MessageBoxWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}