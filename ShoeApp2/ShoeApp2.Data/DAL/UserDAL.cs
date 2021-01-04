using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using ShoeApp2.Interface; 
using Dapper;
using System.Linq;
using ShoeApp2.Interface.Interfaces;
using ShoeApp2.Interface.DTO;

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
                var userDTO  = connection.Query<UserDTO>(query, parameters).FirstOrDefault();
                return userDTO; 
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

        public void UpdateProfile(string userName, string emailAdress, int id)
        {
            using(SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                var parameters = new { UserName = userName, EmailAdress = emailAdress, Id = id };
                var query = "UPDATE [dbo].[Customer] SET UserEmail = @EmailAdress, UserName = @UserName WHERE ID = @Id";
                
                connection.Query(query, parameters); 
            }
        }

        public List<UserDTO> GetAllUsers()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                var query = "SElECT UserName FROM [dbo].[Customer]";

                return connection.Query<UserDTO>(query).ToList();
            }
        }

        public void CreateUser(string userName, string userEmail, string password)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                var parameters = new { UserName = userName, UserEmail = userEmail, Password = password };
                var query = "INSERT INTO [dbo].[Customer] (UserName, UserEmail, Password) VALUES (@UserName, @UserEmail, @Password)";

                connection.Query(query, parameters); 
            }
        }
    }
}
