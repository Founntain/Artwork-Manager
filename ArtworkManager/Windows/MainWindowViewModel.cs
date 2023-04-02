using System.Collections.ObjectModel;
using ArtworkManager.Views;
using Avalonia.Media;
using Nein.Base;
using ReactiveUI;

namespace ArtworkManager.Windows;

public class MainWindowViewModel : BaseWindowViewModel
{
    private BaseViewModel? _mainView;
    private ExperimentalAcrylicMaterial? _panelMaterial;
    private ObservableCollection<MainWindowNavigationItem> _mainWindowNavigationItems;
    private bool _isPaneOpen;

    public HomeViewModel HomeView { get; set; }
    public ArtworkBrowserViewModel ArtworkBrowserViewModel { get; set; }
    public AddArtworkViewModel AddArtworkViewModel { get; set; }
    public AddCharacterViewModel AddCharacterViewModel { get; set; }

    public bool IsPaneOpen
    {
        get => _isPaneOpen;
        set => this.RaiseAndSetIfChanged(ref _isPaneOpen, value);
    }

    public ObservableCollection<MainWindowNavigationItem> MainWindowNavigationItems
    {
        get => _mainWindowNavigationItems;
        set => this.RaiseAndSetIfChanged(ref _mainWindowNavigationItems, value);
    }

    public ExperimentalAcrylicMaterial? PanelMaterial
    {
        get => _panelMaterial;
        set => _panelMaterial = value;
    }

    public BaseViewModel? MainView
    {
        get => _mainView;
        set => this.RaiseAndSetIfChanged(ref _mainView, value);
    }

    public MainWindowViewModel()
    {
        HomeView = new();
        ArtworkBrowserViewModel = new();
        AddArtworkViewModel = new();
        AddCharacterViewModel = new();
    }
}