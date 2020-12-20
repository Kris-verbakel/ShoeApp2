using System;

namespace ShoeApp2.Data
{
    public class ConnectionString
    {
        private static string connectionString = "Data Source = LAPTOP - M87NBEN5; Initial Catalog = Users; Integrated Security = True";

        public static string GetConnectionString()
        {
            return connectionString;
        }
    }
}
