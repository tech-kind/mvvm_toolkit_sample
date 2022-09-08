using System.Windows;
using MvvmToolkitSample.ViewModels;

namespace MvvmToolkitSample.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        if (DataContext is ILoadable vm)
        {
            await vm.LoadAsync();
        }
    }
}
