using ControleFinanceiro.MAUI.Extensions;

namespace ControleFinanceiro.MAUI.Views;

public partial class TransactionUpdate : ContentPage
{
	public TransactionUpdate()
	{
		InitializeComponent();
	}

    void OnClosePageClicked(object sender, TappedEventArgs e)
    {
        this.OnClosePageClicked();
    }
}
