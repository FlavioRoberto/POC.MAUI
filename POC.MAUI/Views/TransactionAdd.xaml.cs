using POC.MAUI.Base;

namespace POC.MAUI.Views;

public partial class TransactionAdd : ContentPage
{
	public TransactionAdd()
	{
        InitializeComponent();
	}

    void OnClosePageClicked(object sender, TappedEventArgs e)
    {
        this.OnClosePageClicked();
    }
}
