using System.Globalization;
using ControleFinanceiro.Domain.Extensions;
using ControleFinanceiro.Domain.Models;

namespace ControleFinanceiro.MAUI.Converters
{
    public class TransactionValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return 0m.ToCurrencyString();

            var transaction = (Transaction)value;
            var isIncome = transaction.Category == TransactionCategory.Income;

            var transactionValue = isIncome ? transaction.Value : transaction.Value * -1;
            return transactionValue.ToCurrencyString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class TransactionColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var defaultColor = "red";

            if (value == null || Application.Current.Resources.MergedDictionaries.Count <= 0)
                return defaultColor;

            foreach (var resource in Application.Current.Resources.MergedDictionaries)
            {
                if (!resource.TryGetValue("Tertiary", out object tertiary))
                    return defaultColor;

                if (!resource.TryGetValue("DarkRed", out object darkRed))
                    return defaultColor;

                var transaction = (Transaction)value;
                var isIncome = transaction.Category == TransactionCategory.Income;

                return isIncome ? tertiary : darkRed;
            }

            return defaultColor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

