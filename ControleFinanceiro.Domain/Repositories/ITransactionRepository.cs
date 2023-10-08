using ControleFinanceiro.Domain.Models;

namespace ControleFinanceiro.Domain.Repositories
{
    public interface ITransactionRepository
	{
		void Create(Transaction transaction);
		List<Transaction> List();
		void Update(Transaction transaction);
		void Delete(long Id);
	}
}

