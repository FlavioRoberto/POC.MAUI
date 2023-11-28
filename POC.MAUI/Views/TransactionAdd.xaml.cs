namespace POC.MAUI.Views;

public partial class TransactionAdd : ContentPage
{
	public TransactionAdd()
	{
        InitializeComponent();
	}

    void OnClosePageClicked(System.Object sender, System.EventArgs e)
    {
		App.Current.MainPage = new TransactionList();
    }
}
