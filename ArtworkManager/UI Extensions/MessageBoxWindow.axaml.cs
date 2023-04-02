using Avalonia;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;

namespace ArtworkManager.UI_Extensions;

public partial class MessageBoxWindow : ReactiveWindow<MessageBoxViewModel>
{
    public MessageBoxWindow()
    {
        InitializeComponent();

        ViewModel = new MessageBoxViewModel();

#if DEBUG
        this.AttachDevTools();
#endif
    }

    public MessageBoxWindow(string text, string? title)
    {
        InitializeComponent();

        ViewModel = new MessageBoxViewModel(this, text, title);
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        this.WhenActivated(_ => { });

        AvaloniaXamlLoader.Load(this);
    }
}