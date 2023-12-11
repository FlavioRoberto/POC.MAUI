using ControleFinanceiro.Domain.Repositories;
using ControleFinanceiro.MAUI.Views.Controls;

namespace ControleFinanceiro.MAUI.Views;

public partial class TransactionAdd : TransactionPage
{
    private readonly ITransactionRepository _repository;
    private TransactionPageControl _control;
    RadioButton TransactionPage.TransactionIncome => TransactionIncome;
    DatePicker TransactionPage.TransactionDate => TransactionDate;
    Entry TransactionPage.TransactionDescription => TransactionDescription;
    Entry TransactionPage.TransactionValue => TransactionValue;
    Label TransactionPage.TransactionError => TransactionError;
    INavigation TransactionPage.Navigation => Navigation;

    public TransactionAdd(ITransactionRepository repository)
    {
        InitializeComponent();
        _repository = repository;
        _control = new TransactionPageControl(this);
    }

    void OnClosePageClicked(object sender, TappedEventArgs e)
    {
        Navigation.PopModalAsync();
    }

    void OnSaveButtonClicked(object sender, EventArgs e)
    {
        _control.Save(_repository.Create);
    }
}
