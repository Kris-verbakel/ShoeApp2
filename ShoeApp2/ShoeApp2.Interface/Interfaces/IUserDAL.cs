using System;
using System.Collections.Generic;
using System.Text;
using ShoeApp2.Interface.DTO;

namespace ShoeApp2.Interface.Interfaces
{
    public interface IUserDAL
    {
        public UserDTO GetUserByEmail(string email);
        public bool ComparePasswords(string email, string password);
        public UserDTO GetUserById(string id);
        public void UpdateProfile(string userName, string emailAdress, int id);
        public List<UserDTO> GetAllUsers();
        public void CreateUser(string userName, string userEmail, string password);
    }
}
