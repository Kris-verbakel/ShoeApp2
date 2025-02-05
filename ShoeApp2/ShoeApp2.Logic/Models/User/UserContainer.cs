﻿using ShoeApp2.Interface.Interfaces;
using ShoeApp2.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoeApp2.Logic.Models.User
{
    public class UserContainer : IUserContainer
    {
        private readonly IUserDAL _userDAL;

        public UserContainer(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }

        public User GetUserByEmail(string email)
        {
            var userDTO = _userDAL.GetUserByEmail(email);
            return new User(userDTO); 
        }

        public User GetUserById(string id)
        {
            var userDTO = _userDAL.GetUserById(id);
            return new User(userDTO);
        }

        public bool ComparePasswords(string emailAddress, string password)
        {
           return _userDAL.ComparePasswords(emailAddress, password);       
        }

        public void UpdateProfile(string userName, string emailAdress, int id)
        {
            _userDAL.UpdateProfile(userName, emailAdress, id); 
        }

        public List<User> GetAllUsers()
        {
            var userDTOs = _userDAL.GetAllUsers();
            var users = new List<User>(); 
 
            foreach (var userDTO in userDTOs)
            {
                users.Add(new User(userDTO));
            }
            return users;
        }

        public void CreateUser(string userName, string userEmail, string password)
        {
            _userDAL.CreateUser(userName, userEmail, password);
        }
    }
}
