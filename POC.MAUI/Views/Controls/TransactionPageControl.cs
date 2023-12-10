using System;
using CommunityToolkit.Mvvm.Messaging;
using ControleFinanceiro.Domain.Models;

namespace ControleFinanceiro.MAUI.Views.Controls
{
    public partial class TransactionPageControl
    {
        private readonly ContentPage _contentPage;
        private readonly RadioButton TransactionIncome;
        private readonly DatePicker TransactionDate;
        private readonly Entry TransactionDescription;
        private readonly Entry TransactionValue;
        private readonly Label TransactionError;

        public TransactionPageControl(ContentPage contentPage, RadioButton transactionIncome, DatePicker transactionDate, Entry transactionDescription, Entry transactionValue, Label transactionError)
        {
            _contentPage = contentPage;
            TransactionIncome = transactionIncome;
            TransactionDate = transactionDate;
            TransactionDescription = transactionDescription;
            TransactionValue = transactionValue;
            TransactionError = transactionError;
        }

        public void Save(Action<Transaction> saveAction)
        {
            var transaction = GetTransaction();

            if (transaction == null)
                return;

            TransactionError.IsVisible = false;

            saveAction(transaction);

            WeakReferenceMessenger.Default.Send(transaction);

            _contentPage.Navigation.PopModalAsync();
        }

        private Transaction GetTransaction()
        {
            Transaction transaction = null;

            try
            {
                transaction = new Transaction(TransactionDescription.Text,
                                              GetTransactionValue(),
                                              TransactionDate.Date,
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

}

