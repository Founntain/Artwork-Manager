using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;

namespace ArtworkManager.Windows
{
    public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(MainWindowViewModel viewModel)
        {
            ViewModel = viewModel;
            
            InitializeComponent();
            
#if DEBUG
            this.AttachDevTools();
#endif
        }
        
        private void InitializeComponent()
        {
            this.WhenActivated(_ =>
            {
                if (ViewModel != null)
                    ViewModel.MainView = ViewModel.HomeView;
            });

            AvaloniaXamlLoader.Load(this);
        }

        private void Navigation_Clicked(object? sender, RoutedEventArgs e)
        {
            if (ViewModel == default) return;

            switch ((sender as Control)?.Name)
            {
                case "HomeNavigation":
                    ViewModel!.MainView = ViewModel.HomeView;
                    break;
                case "ArtworkBrowserNavigation":
                    ViewModel!.MainView = ViewModel.ArtworkBrowserViewModel;
                    break;

            }
        }

        private void SplitView_PointerEnter(object? sender, PointerEventArgs e)
        {
            var splitview = (SplitView) sender;

            // splitview.IsPaneOpen = true;
        }

        private void SplitView_PointerLeave(object? sender, PointerEventArgs e)
        {
            var splitview = (SplitView) sender;

            // splitview.IsPaneOpen = false;
        }

        private void Menu_OnClick(object? sender, PointerPressedEventArgs e)
        {
            if (ViewModel == default) return;
            
            ViewModel.IsPaneOpen = !ViewModel.IsPaneOpen;
        }
    }
}