using System.Globalization;

namespace ControleFinanceiro.Domain.Extensions
{
    public static class StringExtensions
	{
		public static bool IsEmpty(this string value)
		{
			return string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);
		}

		public static string ToCurrencyString(this decimal value)
		{
            var systemCulture = CultureInfo.CurrentCulture;
            return value.ToString("C", systemCulture);
        }
    }
}

