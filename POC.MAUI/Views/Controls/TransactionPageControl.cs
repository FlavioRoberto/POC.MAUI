using System;
using CommunityToolkit.Mvvm.Messaging;
using ControleFinanceiro.Domain.Models;

namespace ControleFinanceiro.MAUI.Views.Controls
{
    public interface TransactionPage
    {
        RadioButton TransactionIncome { get; }
        DatePicker TransactionDate { get; }
        Entry TransactionDescription { get; }
        Entry TransactionValue { get; }
        Label TransactionError { get; }
        INavigation Navigation { get; }
    }

    public partial class TransactionPageControl
    {
        private readonly TransactionPage _page;

        public TransactionPageControl(TransactionPage page)
        {
            _page = page;
        }

        public void Save(Action<Transaction> saveAction)
        {
            var transaction = GetTransaction();

            if (transaction == null)
                return;

            _page.TransactionError.IsVisible = false;

            saveAction(transaction);

            WeakReferenceMessenger.Default.Send(transaction);

            _page.Navigation.PopModalAsync();
        }

        private Transaction GetTransaction()
        {
            Transaction transaction = null;

            try
            {
                transaction = new Transaction(_page.TransactionDescription.Text,
                                              GetTransactionValue(),
                                              _page.TransactionDate.Date,
                                              GetCategory());
            }
            catch (Exception e)
            {
                ShowError(e.Message);
            }

            return transaction;
        }


        private decimal GetTransactionValue()
        {
            decimal transactionValue;

            if (!decimal.TryParse(_page.TransactionValue.Text, out transactionValue))
                throw new Exception("O compo valor precisa ser decimal!");

            return transactionValue;
        }

        private TransactionCategory GetCategory()
        {
            if (_page.TransactionIncome.IsChecked)
                return TransactionCategory.Income;

            return TransactionCategory.Expenses;
        }

        private void ShowError(string errorMessage)
        {
            _page.TransactionError.IsVisible = true;
            _page.TransactionError.Text = errorMessage;
        }
    }

}

