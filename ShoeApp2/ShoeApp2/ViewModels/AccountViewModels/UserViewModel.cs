using ShoeApp2.Logic.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeApp2.ViewModels.AccountViewModels
{
    public class UserViewModel
    {
        public string UserName { get; set; }

        public UserViewModel(User user)
        {
            this.UserName = user.Username; 
        }
    }
}
