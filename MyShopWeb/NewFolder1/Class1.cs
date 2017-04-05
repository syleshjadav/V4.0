using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyShopWeb.NewFolder1
{

    public static class Repository
    {
        static List<User> users = new List<User>() {

        new User() { Email = "sylesh@gmail.com",Roles = "Admin,Editor",Password = "jadav" },
        new User() { Email = "xyz@gmail.com",Roles = "Editor",Password = "xyzeditor" }
    };

        public static User GetUserDetails(User user)
        {
            return users.Where(u => u.Email.ToLower() == user.Email.ToLower() &&
            u.Password == user.Password).FirstOrDefault();
        }
    }
    public class User
    {
        public string Email { get; set; }
        public string Roles { get; set; }
        public string Password { get; set; }
    }
}