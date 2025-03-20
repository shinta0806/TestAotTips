using Microsoft.UI.Xaml.Controls;

using TestAotTips.ViewModels.MainWindows;

namespace TestAotTips.Views.MainWindows;

public sealed partial class MainPage : Page
{
	public MainViewModel ViewModel
	{
		get;
	}

	public MainPage()
	{
		ViewModel = new();
		InitializeComponent();
	}
}
