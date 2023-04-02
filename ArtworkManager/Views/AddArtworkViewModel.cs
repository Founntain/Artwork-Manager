using System;
using System.Collections;
using System.Collections.Generic;
using ArtworkManager.Data.Enums;
using Nein.Base;
using ReactiveUI;

namespace ArtworkManager.Views;

public class AddArtworkViewModel : BaseViewModel
{
    private string _artworkFilePath;
    private string _name;
    private string _description;
    private ArtworkType _artworkType;
    private ArtworkAcquiredType _artworkAcquiredType;
    private bool _isNsfw;

    public bool IsNsfw
    {
        get => _isNsfw;
        set => this.RaiseAndSetIfChanged(ref _isNsfw, value);
    }

    public string Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }

    public string Description
    {
        get => _description;
        set => this.RaiseAndSetIfChanged(ref _description, value);
    }

    public string ArtworkFilePath
    {
        get => _artworkFilePath;
        set => this.RaiseAndSetIfChanged(ref _artworkFilePath, value);
    }

    public ArtworkType ArtworkType
    {
        get => _artworkType;
        set => this.RaiseAndSetIfChanged(ref _artworkType, value);
    }

    public ArtworkAcquiredType ArtworkAcquiredType
    {
        get => _artworkAcquiredType;
        set => this.RaiseAndSetIfChanged(ref _artworkAcquiredType, value);
    }

    public IEnumerable<ArtworkType> ArtworkTypes => Enum.GetValues<ArtworkType>();
    public IEnumerable<ArtworkAcquiredType> ArtworkAcquiredTypes => Enum.GetValues<ArtworkAcquiredType>();

    public AddArtworkViewModel()
    {
        Activator = new ViewModelActivator();
    }
}