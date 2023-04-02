using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Nein.Base;

namespace ArtworkManager.Views;

public partial class AddCharacterView : ReactiveControl<AddCharacterViewModel>
{
    public AddCharacterView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void Save_OnClick(object? sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }
}