using Nein.Base;
using ReactiveUI;

namespace ArtworkManager.Windows;

public class FullscreenWindowViewModel : BaseViewModel
{
    private string _artworkFilePath;

    public FullscreenWindowViewModel(string artworkFilePath)
    {
        ArtworkFilePath = artworkFilePath;
        
        Activator = new ViewModelActivator();
    }

    public string ArtworkFilePath
    {
        get => _artworkFilePath;
        set => this.RaiseAndSetIfChanged(ref _artworkFilePath, value);
    }
}