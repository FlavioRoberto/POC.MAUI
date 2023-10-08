using ControleFinanceiro.Domain.Models;
using LiteDB;

namespace ControleFinanceiro.Infra.Mapping
{
    public class LiteDbMapping
	{
		public LiteDbMapping()
		{
            var mapper = BsonMapper.Global;

            mapper.Entity<Transaction>()
                  .Id(x => x.Id);
        }
    }
}

