using ControleFinanceiro.Domain.Models;
using ControleFinanceiro.Domain.Repositories;
using LiteDB;

namespace ControleFinanceiro.Infra.Repositories
{
    public class TransactionLiteDbRepository : ITransactionRepository
    {
        private readonly LiteDatabase _database;
        private const string collectionName = nameof(Transaction);

        public TransactionLiteDbRepository(LiteDatabase database)
        {
            _database = database;
        }

        public void Create(Transaction transaction)
        {
            var collection = _database.GetCollection<Transaction>(collectionName);

            collection.Insert(transaction);

            collection.EnsureIndex(x => x.Date);
        }

        public void Delete(long Id)
        {
            _database
                .GetCollection<Transaction>(collectionName)
                .Delete(Id);
        }

        public List<Transaction> List()
        {
            return _database
                       .GetCollection<Transaction>(collectionName)
                       .Query()
                       .OrderByDescending(x => x.Date)
                       .ToList();
        }

        public void Update(Transaction transaction)
        {
            _database
               .GetCollection<Transaction>(collectionName)
               .Update(transaction);
        }
    }
}

