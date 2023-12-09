using ControleFinanceiro.MAUI.Views;

namespace ControleFinanceiro.MAUI;

public partial class App : Application
{
	public App(TransactionList transactionList)
	{
		Current.UserAppTheme = AppTheme.Light;

        InitializeComponent();

		MainPage = new NavigationPage(transactionList);
	}
}

