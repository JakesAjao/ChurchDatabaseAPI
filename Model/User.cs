using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChurchDatabaseAPI.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; } //Active
        public string Message { get; set; }
    }
    public class UserFilter
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string  Message { get; set; }
    }
}
