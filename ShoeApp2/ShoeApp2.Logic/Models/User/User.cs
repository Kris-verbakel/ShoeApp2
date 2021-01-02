using System;
using System.Collections.Generic;
using System.Text;
using ShoeApp2.Interface; 

namespace ShoeApp2.Logic.Models.User
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }

        public User(UserDTO userDTO)
        {
            this.Id = userDTO.Id;
            this.Email = userDTO.Email;
            this.Password = userDTO.Password;
            this.Username = userDTO.Username;
        }
    }
}
