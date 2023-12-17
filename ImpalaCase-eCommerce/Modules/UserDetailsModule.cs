using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImpalaCase_eCommerce.Modules
{
    public class UserDetailsModule
    {
        public int Id { get; set; }
        public int LoginId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }

        // Constructor
        public UserDetailsModule(int id, int loginId, string firstName, string middleName,
            string lastName, DateTime dateOfBirth, string address)
        {
            Id = id;
            LoginId = loginId;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Address = address;
        }
    }

}