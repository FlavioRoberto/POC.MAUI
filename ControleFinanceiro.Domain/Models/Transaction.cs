using ControleFinanceiro.Domain.Exceptions;
using ControleFinanceiro.Domain.Extensions;

namespace ControleFinanceiro.Domain.Models
{
    public enum TransactionCategory
    {
        Income,
        Expenses
    }

    public class Transaction
    {
        public long Id { get; private set; }
        public TransactionCategory Category { get; private set; }
        public string Description { get; private set; }
        public DateTimeOffset Date { get; private set; }
        public decimal Value { get; private set; }

        public Transaction(string description, decimal value, DateTimeOffset date, TransactionCategory category)
        {
            Description = description;
            Value = value;
            Date = date;
            Category = category;

            IsValidTransaction();
        }

        private void IsValidTransaction()
        {
            if (Category == null)
                throw new DomainException("Campo categoria é obrigatório!");

            if (Description.IsEmpty())
                throw new DomainException("Campo descrição é obrigatório!");

            if (Date == DateTime.MinValue)
                throw new DomainException("Campo data é obrigatório!");

            if (Value <= 0)
                throw new DomainException("Campo valor é obrigatório!");
        }

    }
}

