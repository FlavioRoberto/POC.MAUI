using ControleFinanceiro.Domain.Repositories;
using ControleFinanceiro.Infra.Repositories;
using LiteDB;

namespace ControleFinanceiro.Infra
{
    public static class IoC
	{
		public static IServiceCollection AddInfra(this IServiceCollection services)
        {
			services.AddSingleton(options => 
				new LiteDatabase($"Filename={AppSettings.getDirectory()}/database.db;Connection=Shared")
			);
			services.AddSingleton<ITransactionRepository, TransactionLiteDbRepository>();

			return services;
		}
	}
}

