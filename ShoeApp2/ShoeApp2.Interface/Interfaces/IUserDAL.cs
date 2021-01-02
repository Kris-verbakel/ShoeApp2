using System;
using System.Collections.Generic;
using System.Text;
using ShoeApp2.Interface.DTO;

namespace ShoeApp2.Interface.Interfaces
{
    public interface IUserDAL
    {
        public UserDTO GetUserByEmail(string email);
        public bool ComparePasswords(string emailAdress, string password);
        public UserDTO GetUserById(string id);

    }
}
