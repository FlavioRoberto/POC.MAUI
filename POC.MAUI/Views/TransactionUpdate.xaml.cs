using ControleFinanceiro.Domain.BuildingBlocks.Interfaces;
using ControleFinanceiro.Domain.Models;
using ControleFinanceiro.Domain.Repositories;
using ControleFinanceiro.MAUI.Extensions;
using ControleFinanceiro.MAUI.Views.Controls;

namespace ControleFinanceiro.MAUI.Views;

public partial class TransactionUpdate : ContentPage, ContentPageWithData<Transaction>
{
    private readonly ITransactionRepository _repository;
    private TransactionPageControl _control;
    private long transactionId;

    public TransactionUpdate(ITransactionRepository repository)
    {
        InitializeComponent();
        _repository = repository;
        _control = new TransactionPageControl(this,
                                              TransactionIncome,
                                              TransactionDate,
                                              TransactionDescription,
                                              TransactionValue,
                                              TransactionError);
    }

    public void SetData(Transaction data)
    {
        transactionId = data.Id;

        if (data.Category == TransactionCategory.Income)
            TransactionIncome.IsChecked = true;
        else
            TransactionExpense.IsChecked = true;

        TransactionDescription.Text = data.Description;
        TransactionValue.Text = data.Value.ToString();
        TransactionDate.Date = data.Date.UtcDateTime;
    }

    void OnClosePageClicked(object sender, TappedEventArgs e)
    {
        this.OnClosePageClicked();
    }

    void OnSaveButtonClicked(object sender, EventArgs e)
    {
        _control.Save( t => {
            t.SetId(transactionId);
            _repository.Update(t);
        });
    }
}
