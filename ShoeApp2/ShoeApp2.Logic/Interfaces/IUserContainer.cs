using ShoeApp2.Interface;
using ShoeApp2.Logic.Models.User;
using System;
using System.Collections.Generic;
using System.Text;


namespace ShoeApp2.Logic.Interfaces
{
    public interface IUserContainer
    {
        public User GetUserByEmail(string email);
        public bool ComparePasswords(string emailAdress, string password);
        public User GetUserById(string id);
        //public User UpdateProfile(string email, string password, string name); 
    }
}
