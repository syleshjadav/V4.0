using System.Collections.Generic;
using System.Linq;

namespace Authentication.DAL
{
    public static class Repository
    {
       static List<User> users = new List<User>() {

            new User() {Email="sylesh@gmail.com",Roles="Admin,Editor",Password="jadav" },
            new User() {Email="xyz@gmail.com",Roles="Editor",Password="xyzeditor" }
        };
      
        public static User GetUserDetails(User user)
        {
            return users.Where(u => u.Email.ToLower() == user.Email.ToLower() &&
            u.Password == user.Password).FirstOrDefault();
        }
    }
}