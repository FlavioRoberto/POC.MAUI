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
				new LiteDatabase($"Filename={AppSettings.DatabasePath}/database.db;Connection=Shared")
			);
			services.AddTransient<ITransactionRepository, TransactionLiteDbRepository>();

			return services;
		}
	}
}

