using CommunityToolkit.Mvvm.Messaging;
using ControleFinanceiro.Domain.Models;
using ControleFinanceiro.Domain.Repositories;
using ControleFinanceiro.MAUI.Extensions;
using ControleFinanceiro.MAUI.Views.Controls;
using Microsoft.Maui.Controls;

namespace ControleFinanceiro.MAUI.Views;

public partial class TransactionAdd
{
    private readonly ITransactionRepository _repository;
    private TransactionPageControl _control;

    public TransactionAdd(ITransactionRepository repository)
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

    void OnClosePageClicked(object sender, TappedEventArgs e)
    {
        this.OnClosePageClicked();
    }

    void OnSaveButtonClicked(object sender, EventArgs e)
    {
        _control.Save(_repository.Create);
    }
}
