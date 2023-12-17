using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImpalaCase_eCommerce.Modules
{
    public class LoginModule
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }

        // Constructor
        public LoginModule(int id, string email, string password, string userType)
        {
            Id = id;
            Email = email;
            Password = password;
            UserType = userType;
        }
    }

}