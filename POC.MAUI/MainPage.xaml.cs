using ControleFinanceiro.Domain.Models;
using ControleFinanceiro.Domain.Repositories;

namespace POC.MAUI;

public partial class MainPage : ContentPage
{
	int count = 0;
//	private readonly ITransactionRepository _transactionRepository;

    public MainPage()
    {
        InitializeComponent();
		//    _transactionRepository = transactionRepository;

		//_transactionRepository.Create(new Transaction {
		//	Category = TransactionCategory.Expenses,
		//	Date = DateTimeOffset.Now,
		//	Description = "Teste",
		//	Value = 10
		//});
    }

    private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

//		var teste = _transactionRepository.List();

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time {teste.FirstOrDefault()?.Description}";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}


