using ControleFinanceiro.MAUI.Views;

namespace ControleFinanceiro.MAUI
{
    public static class IoC
	{
        public static IServiceCollection AddViews(this IServiceCollection services)
        {
            services.AddTransient<TransactionAdd>();
            services.AddTransient<TransactionUpdate>();
            services.AddTransient<TransactionList>();
  
            return services;
        }

    }
}

