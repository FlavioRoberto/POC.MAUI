namespace ControleFinanceiro.Infra
{
    public class AppSettings
	{
		private static string DatabaseName = "database.db";
        private static string DatabaseDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
		private static string DatabasePath = Path.Combine(DatabaseDirectory, DatabaseName);

		public static string getDirectory()
		{
            // Ensure the database directory exists
            if (!Directory.Exists(DatabasePath))
            {
                Directory.CreateDirectory(DatabasePath);
            }

            return DatabasePath;
        }
	}
}

