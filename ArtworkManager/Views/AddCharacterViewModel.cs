using Nein.Base;
using ReactiveUI;

namespace ArtworkManager.Views;

public class AddCharacterViewModel : BaseViewModel
{
    private string _name;

    public string Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }

    private string _description;

    public string Description
    {
        get => _description;
        set => this.RaiseAndSetIfChanged(ref _description, value);
    }

    public AddCharacterViewModel()
    {
        Activator = new ViewModelActivator();
    }
}