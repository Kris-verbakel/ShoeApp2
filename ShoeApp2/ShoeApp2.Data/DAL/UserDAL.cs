using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using ShoeApp2.Interface; 
using Dapper;
using System.Linq;
using ShoeApp2.Interface.Interfaces;

namespace ShoeApp2.Data.DAL
{
    public class UserDAL : IUserDAL 
    {
        public bool ComparePasswords(string emailAdress, string password)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                var parameters = new { EmailAdress = emailAdress, Password = password };
                var query = "SELECT COUNT(1) FROM [dbo].[Customer] WHERE UserEmail = @EmailAdress AND UserPassword = @Password";

                bool isTheSame = connection.ExecuteScalar<bool>(query, parameters);

                return isTheSame;
            }
        }

        public UserDTO GetUserByEmail(string emailAdress)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                var parameters = new { EmailAdress = emailAdress };
                var query = "SELECT * FROM [dbo].[Customer] WHERE UserEmail = @EmailAdress";

                return connection.Query<UserDTO>(query, parameters).FirstOrDefault();
            }
        }

        public UserDTO GetUserById(string id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                var parameters = new { Id = id };
                var query = "SELECT * FROM [dbo].[Customer] WHERE ID = @Id";

                return connection.Query<UserDTO>(query, parameters).FirstOrDefault(); 
            }
        }
    }
}
