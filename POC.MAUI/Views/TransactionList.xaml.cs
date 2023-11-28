using ControleFinanceiro.Domain.Models;

namespace POC.MAUI.Views;

public partial class TransactionList : ContentPage
{
	public List<Transaction> Transactions { get; private set; }

	public TransactionList()
	{
		Transactions = new List<Transaction>();

        InitializeComponent();
	}

    private void OnAddTransactionButtonClicked(Object sender, EventArgs e)
    {
		App.Current.MainPage = new TransactionAdd();
    }
}
