namespace ControleFinanceiro.Domain.Models
{
	public enum TransactionCategory
	{
		Income,
		Expenses
	}

	public class Transaction
	{
		public long  Id { get; set; }
		public TransactionCategory Category { get; set; }
		public string Description { get; set; }
		public DateTimeOffset Date { get; set; }
		public decimal Value { get; set; }
	}
}

