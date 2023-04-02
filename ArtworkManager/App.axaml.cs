using System.IO;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Splat;

namespace ArtworkManager
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            Directory.CreateDirectory("data/files");
            
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = Locator.Current.GetService<Windows.MainWindow>();
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}