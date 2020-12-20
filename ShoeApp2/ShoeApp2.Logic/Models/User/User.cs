using System;
using System.Collections.Generic;
using System.Text;
using ShoeApp2.Interface; 

namespace ShoeApp2.Logic.Models.User
{
    class User
    {
        public int Id { get; }
        public string Email { get; }
        public string Password { get; }
        public string Username { get; }

        public User(UserDTO userDTO)
        {
            this.Id = userDTO.Id;
            this.Email = userDTO.Email;
            this.Password = userDTO.Password;
            this.Username = userDTO.Username;
        }
    }
}
