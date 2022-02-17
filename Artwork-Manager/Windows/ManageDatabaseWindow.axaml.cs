using System.Collections.ObjectModel;
using ArtworkManager.Database.Contexts;
using ArtworkManager.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ArtworkManager.Windows;

public class ManageDatabaseWindow : Window
{
    public ManageDatabaseWindow()
    {
        DataContext = new ManageDatabaseWindowViewModel();
        
        InitializeComponent();

#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void SelectingItemsControl_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        var vm = (ManageDatabaseWindowViewModel) DataContext;

        var value = ((ListBox) sender).SelectedItem as string;

        using (var ctx = new DatabaseContext())
        {
            switch (value)
            {
                case "Artists":
                    vm.TableData = new ObservableCollection<object>(ctx.Artists.ToList());

                    break;
                case "Artworks":
                    vm.TableData = new ObservableCollection<object>(ctx.Artworks.ToList());

                    break;
                case "Collections":
                    vm.TableData = new ObservableCollection<object>(ctx.Collections.ToList());

                    break;
            }
        }
    }

    private void Window_OnActivated(object? sender, EventArgs e)
    {
        var vm = (ManageDatabaseWindowViewModel) DataContext;

        vm.Tables = new ObservableCollection<string>(new[]
        {
            "Artworks",
            "Artists",
            "Collections"
        });

        using (var ctx = new DatabaseContext())
        {
            var x = new ObservableCollection<object>(ctx.Artworks.ToList());

            vm.TableData = x;
        }

        var grid = this.FindControl<DataGrid>("DataGridTest");
    }

    private void DataGrid_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        var vm = (ManageDatabaseWindowViewModel) DataContext;

        vm.SelectedDatabaseEntry = ((DataGrid) sender).SelectedItem;
    }
}