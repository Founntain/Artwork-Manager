using Avalonia;
using System;
using ArtworkManager.Windows;
using Avalonia.Platform;
using Avalonia.ReactiveUI;
using Nein.Extensions;
using Splat;

namespace ArtworkManager
{
    class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        [STAThread]
        public static void Main(string[] args)
        {
            var builder = BuildAvaloniaApp();

            Register(Locator.CurrentMutable, Locator.Current, builder.RuntimePlatform);
                
            builder.StartWithClassicDesktopLifetime(args);
        }

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToTrace()
                .UseReactiveUI()
                .With(new Win32PlatformOptions
                {
                    AllowEglInitialization = true,
                    UseWindowsUIComposition = true
                });
        
        private static void Register(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver, IRuntimePlatform platform)
        {
            services.Register(() =>  new MainWindowViewModel());
            
            services.RegisterLazySingleton(() => new Windows.MainWindow(
                resolver.GetRequiredService<MainWindowViewModel>()));
        }
    }
}