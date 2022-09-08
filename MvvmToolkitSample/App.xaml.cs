using System;
using System.Windows;
using MvvmToolkitSample.Models;
using MvvmToolkitSample.Services;
using MvvmToolkitSample.ViewModels;
using MvvmToolkitSample.Views;
using Microsoft.Extensions.DependencyInjection;

namespace MvvmToolkitSample;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private IServiceProvider? _services;

    private static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddSingleton<IDataService<Customer>, DataService<Customer>>();
        services.AddTransient<MainViewModel>();

        return services.BuildServiceProvider();
    }

    private void Application_Startup(object sender, StartupEventArgs e)
    {
        _services = ConfigureServices();

        Current.MainWindow = new MainWindow
        {
            DataContext = _services?.GetService<MainViewModel>()
        };
        Current.MainWindow.Show();
    }
}
