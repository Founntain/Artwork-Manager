using Avalonia.Markup.Xaml;
using Nein.Base;
using ReactiveUI;

namespace ArtworkManager.Views;

public class HomeViewModel : BaseViewModel
{
    public HomeViewModel()
    {
        Activator = new ViewModelActivator();
    }
}