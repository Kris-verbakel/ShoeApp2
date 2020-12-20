using System;
using System.Collections.Generic;
using System.Text;
using ShoeApp2.Interface.DTO;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using ShoeApp2.Interface.Interfaces; 

namespace ShoeApp2.Data.DAL { 
    public class ShoeDAL : IShoeDAL
    {
        public ShoeDTO GetShoeByName(string name)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                var parameters = new { Name = name };
                var query = "SELECT * FROM [dbo].[Shoe] WHERE Name = @Name";

                return connection.Query<ShoeDTO>(query, parameters).FirstOrDefault();
            }
        }

        public ShoeDTO GetShoeById(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                var parameters = new { Id = id };
                var query = "SELECT COUNT(1) FROM [dbo].[Shoe] WHERE ID = @Id";

                return connection.Query<ShoeDTO>(query, parameters).FirstOrDefault(); 
                    
            }
        }

        public List<ShoeDTO> GetAllShoes()
        {
            using(SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                var query = "SELECT * FROM [dbo].[Shoe]";

                return connection.Query<ShoeDTO>(query).ToList(); 
            }
        }

        public List<ShoeDTO> GetShoesByBrand(string brand)
        {
            using(SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                var parameters = new { Brand = brand };
                var query = "SELECT * FROM [dbo].[Shoe] WHERE Brand = @Brand";

                return connection.Query<ShoeDTO>(query, parameters).ToList(); 
            }
        }
            
    }
}
