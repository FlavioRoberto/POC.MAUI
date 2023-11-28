namespace POC.MAUI.Views;

public partial class TransactionUpdate : ContentPage
{
	public TransactionUpdate()
	{
		InitializeComponent();
	}

    void OnClosePageClicked(System.Object sender, System.EventArgs e)
    {
        App.Current.MainPage = new TransactionList();
    }
}
