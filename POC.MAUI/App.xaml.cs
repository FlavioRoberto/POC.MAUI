using POC.MAUI.Views;

namespace POC.MAUI;

public partial class App : Application
{
	public App()
	{
		Current.UserAppTheme = AppTheme.Light;

        InitializeComponent();

		MainPage = new NavigationPage(new TransactionList());
	}
}

