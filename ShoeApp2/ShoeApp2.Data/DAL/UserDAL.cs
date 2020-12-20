using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using ShoeApp2.Interface; 
using Dapper;
using System.Linq;

namespace ShoeApp2.Data.DAL
{
    class UserDAL
    {
        public bool ComparePasswords(string emailAdress, string password)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                var parameters = new { EmailAdress = emailAdress, Password = password };
                var query = "Select COUNT(1) FROM dbo.User WHERE EmailAddress = @EmailAdress AND Password = @Password";

                bool isTheSame = connection.ExecuteScalar<bool>(query, parameters);

                return isTheSame;
            }
        }

        public UserDTO GetUserByEmail(string emailAdress)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                var parameters = new { EmailAdress = emailAdress };
                var query = "SELECT * FROM dbo.User WHERE EmailAdress = @EmailAdress";

                return connection.Query<UserDTO>(query, parameters).FirstOrDefault(); 
            }
        }

    }
}
