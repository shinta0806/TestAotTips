// ============================================================================
// 
// メインページの ViewModel
// 
// ============================================================================

// ----------------------------------------------------------------------------
// 
// ----------------------------------------------------------------------------

using System.Text.Json;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using TestAotTips.Models.Json;

using WinRT;

namespace TestAotTips.ViewModels.MainWindows;

[GeneratedBindableCustomProperty]
internal partial class MainPageViewModel : ObservableRecipient
{
	// ====================================================================
	// コンストラクター
	// ====================================================================

	/// <summary>
	/// メインコンストラクター
	/// </summary>
	public MainPageViewModel()
	{
		// コマンド
		ButtonJsonClickedCommand = new(ButtonJsonClicked);
		ButtonJsonCcClickedCommand = new(ButtonJsonCcClicked);
	}

	// ====================================================================
	// public プロパティー
	// ====================================================================

	// --------------------------------------------------------------------
	// View 通信用のプロパティー
	// --------------------------------------------------------------------

	/// <summary>
	/// テスト用数値
	/// </summary>
	private Int32 _testInt32 = 99;
	public Int32 TestInt32
	{
		get => _testInt32;
		set => SetProperty(ref _testInt32, value);
	}

	/// <summary>
	/// テスト用リスト
	/// </summary>
	public List<Person> TestList
	{
		get;
	} =
	[
		new ("太郎", 20),
		new ("次郎", 15),
		new ("三郎", 12),
	];

	/// <summary>
	/// テスト用リストで選択された人の名前
	/// </summary>
	private String? _selectedPersonName;
	public String? SelectedPersonName
	{
		get => _selectedPersonName;
		set => SetProperty(ref _selectedPersonName, value);
	}

	// --------------------------------------------------------------------
	// コマンド
	// --------------------------------------------------------------------

	#region JSON ボタンの制御
	public RelayCommand ButtonJsonClickedCommand
	{
		get;
	}

	private async void ButtonJsonClicked()
	{
		try
		{
			// JSON へシリアライズ
			AddressBook addressBook = new()
			{
				BookName = "My address book",
				People = TestList
			};
			String json = JsonSerializer.Serialize(addressBook, MyJsonSerializerContext.Default.AddressBook);
			await App.MainWindow.ShowMessageDialogAsync("シリアライズ：\n" + json);

			// JSON からデシリアライズ
			AddressBook addressBook2 = JsonSerializer.Deserialize(json, MyJsonSerializerContext.Default.AddressBook) ?? throw new Exception("デシリアライズ失敗");
			await App.MainWindow.ShowMessageDialogAsync("デシリアライズ：\n" + addressBook2.People[0]);
		}
		catch (Exception ex)
		{
			await App.MainWindow.ShowMessageDialogAsync(ex.Message);
		}
	}
	#endregion

	#region JSON（カスタムコンバーター）ボタンの制御
	public RelayCommand ButtonJsonCcClickedCommand
	{
		get;
	}

	private async void ButtonJsonCcClicked()
	{
		try
		{
			// JSON へシリアライズ
			// Rgba のシリアライズにはカスタムコンバーター不要なので、MyJsonSerializerContext を使用する
			Rgba rgba = new(0.2f, 0.4f, 0.6f, 0.8f);
			String json = JsonSerializer.Serialize(rgba, MyJsonSerializerContext.Default.Rgba);
			await App.MainWindow.ShowMessageDialogAsync("シリアライズ：\n" + json);

			// JSON からデシリアライズ
			// Rgba のデシリアライズにはカスタムコンバーターが必要なので、RgbaReadJsonSerializerContext を使用する
			Rgba rgba2 = JsonSerializer.Deserialize(json, RgbaReadJsonSerializerContext.Default.Rgba) ?? throw new Exception("デシリアライズ失敗");
			await App.MainWindow.ShowMessageDialogAsync($"デシリアライズ：\nR={rgba2.R}, G={rgba2.G}, B={rgba2.B}, A={rgba2.A}");
		}
		catch (Exception ex)
		{
			await App.MainWindow.ShowMessageDialogAsync(ex.Message);
		}
	}
	#endregion
}
