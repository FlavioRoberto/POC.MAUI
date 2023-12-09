using ControleFinanceiro.Domain.Models;
using ControleFinanceiro.Domain.Repositories;
using ControleFinanceiro.MAUI.Extensions;

namespace ControleFinanceiro.MAUI.Views;

public partial class TransactionList : ContentPage
{
    private readonly ITransactionRepository _repository;
    public List<Transaction> Transactions { get; private set; }

    public TransactionList(ITransactionRepository repository)
    {
        _repository = repository;
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ListTransactions();
    }

    private void OnAddTransactionButtonClicked(object sender, EventArgs e)
    {
        this.PushModal<TransactionAdd>();
    }

    private void OnUpdateTransactionButtonClicked(object sender, EventArgs e)
    {
        this.PushModal<TransactionUpdate>();
    }

    private void ListTransactions()
    {
        CollectionViewTransactions.ItemsSource = _repository.List();
    }
}
