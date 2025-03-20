using Microsoft.UI.Xaml.Controls;

using TestAotTips.ViewModels;

namespace TestAotTips.Views;

public sealed partial class MainPage : Page
{
    public MainViewModel ViewModel
    {
        get;
    }

    public MainPage()
    {
        ViewModel = App.GetService<MainViewModel>();
        InitializeComponent();
    }
}
