using ControleFinanceiro.Domain.Models;
using ControleFinanceiro.Domain.Repositories;
using ControleFinanceiro.MAUI.Extensions;

namespace ControleFinanceiro.MAUI.Views;

public partial class TransactionAdd : ContentPage
{
    private readonly ITransactionRepository _repository;
    private Transaction transaction;

    public TransactionAdd(ITransactionRepository repository)
    {
        InitializeComponent();
        _repository = repository;
    }

    void OnClosePageClicked(object sender, TappedEventArgs e)
    {
        this.OnClosePageClicked();
    }

    void OnSaveButtonClicked(object sender, EventArgs e)
    {
        if (!IsValidTransaction())
            return;

        TransactionError.IsVisible = false;

        _repository.Create(transaction);

        var count = _repository.List().Count();

        Navigation.PopModalAsync();
    }

    private bool IsValidTransaction()
    {
        var isValid = true;

        try
        {
            transaction = new Transaction(TransactionDescription.Text,
                                          GetTransactionValue(),
                                          TransactionDate.Date,
                                          GetCategory());
        }
        catch (Exception e)
        {
            isValid = false;
            ShowError(e.Message);
        }

        return isValid;
    }

    private decimal GetTransactionValue()
    {
        decimal transactionValue;

        if (!decimal.TryParse(TransactionValue.Text, out transactionValue))
            throw new Exception("O compo valor precisa ser decimal!");

        return transactionValue;
    }

    private TransactionCategory GetCategory()
    {
        if (TransactionIncome.IsChecked)
            return TransactionCategory.Income;

        return TransactionCategory.Expenses;
    }

    private void ShowError(string errorMessage)
    {
        TransactionError.IsVisible = true;
        TransactionError.Text = errorMessage;
    }
}
