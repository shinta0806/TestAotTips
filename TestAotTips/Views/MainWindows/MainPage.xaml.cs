using Microsoft.UI.Xaml.Controls;

using TestAotTips.ViewModels.MainWindows;

namespace TestAotTips.Views.MainWindows;

internal sealed partial class MainPage : Page
{
	public MainPage()
	{
		ViewModel = new();
		InitializeComponent();

		// MVVM バインド Binding 用
		DataContext = ViewModel;
	}

	public MainPageViewModel ViewModel
	{
		get;
	}
}
