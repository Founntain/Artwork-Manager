namespace ArtworkManager.ViewModels;

public class FullscreenArtworkWindowViewModel : BaseViewModel
{
    private string _filepath;

    public string Filepath
    {
        get => _filepath;
        set
        {
            _filepath = value; 
            OnPropertyChanged();
        }
    }
}