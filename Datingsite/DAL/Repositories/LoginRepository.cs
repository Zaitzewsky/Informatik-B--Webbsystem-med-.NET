using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class LoginRepository
    {
        public static Login ValidateLogin(string username, string password)
        {
            using (var context = new DatabaseEntities())
            {
                return context.Logins.FirstOrDefault(x =>
                    x.LoginName.Equals(username) &&
                    x.Password.Equals(password));
            }
        }
    }
}
