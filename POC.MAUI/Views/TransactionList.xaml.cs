using CommunityToolkit.Mvvm.Messaging;
using ControleFinanceiro.Domain.Extensions;
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
        LoadValues();
        OnRegisterTransaction();
    }

    //Loading transactions on load screen
    //protected override void OnAppearing()
    //{
    //    base.OnAppearing();
    //    ListTransactions();
    //}

    private void OnAddTransactionButtonClicked(object sender, EventArgs e)
    {
        this.PushModal<TransactionAdd>();
    }

    void OnUpdateTransactionButtonClicked(object sender, TappedEventArgs e)
    {
        var gestureRecognizers = ((Grid)sender).GestureRecognizers.First();
        var gesture = (TapGestureRecognizer)gestureRecognizers;
        var transaction = (Transaction)gesture.CommandParameter;
        this.PushModal<TransactionUpdate, Transaction>(transaction);
    }

    private void LoadValues()
    {
        var transactions = _repository.List().OrderByDescending(t => t.Date);
        CollectionViewTransactions.ItemsSource = transactions;

        CalculateWalletValues(transactions);
    }

    private void CalculateWalletValues(IEnumerable<Transaction> transactions)
    {
        var incomes = SumTransactions(transactions, TransactionCategory.Income);
        var expenses = SumTransactions(transactions, TransactionCategory.Expenses);

        WalletIncome.Text = incomes.ToCurrencyString();
        WalletExpenses.Text = expenses.ToCurrencyString();
        WalletBalance.Text = (incomes - expenses).ToCurrencyString();
    }

    private decimal SumTransactions(IEnumerable<Transaction> transactions, TransactionCategory category)
    {
        return transactions.Where(x => x.Category == category).Sum(x => x.Value);
    }

    private void OnRegisterTransaction()
    {
        WeakReferenceMessenger.Default.Register<Transaction>(this, (e, transaction) =>
            LoadValues());
    }


}
