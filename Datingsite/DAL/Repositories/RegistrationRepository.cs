using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class RegistrationRepository
    {
        //Den kollar ifall användarnamnet finns i databasen
        // ifall metoden returnerar null så finns inte användarnamnet i databasen.
        public static Login ValidateUsername(string username)
        {
            using (var context = new DatabaseEntities()) 
            {
                return context.Logins.FirstOrDefault(x =>
                    x.LoginName.Equals(username));
            }
        }

        //Vid registering läggs en ny login till
        public static void AddLogin(string username, string password)
        {
            using (var context = new DatabaseEntities())
            {
                Login e = new Login
                {
                    LoginName = username,
                    Password = password
                };

                context.Logins.Add(e);
                context.SaveChanges();

            }
        }

        //Vid registering lägg en ny User till
        public static void AddUser(string firstname, string lastname,
        string phone, int age, int gender, string email, int privat, string city, int preferedeGender)
        {
            using (var context = new DatabaseEntities())
            {
                int loginID = context.Logins.Max(x => x.LoginID);
                User u = new User
                {
                    LoginID = loginID,
                    FirstName = firstname,
                    LastName = lastname,
                    Phone = phone,
                    Age = age,
                    Gender = gender,
                    Email = email,
                    Private = privat,
                    City = city,
                    PreferedGender = preferedeGender
                };

                context.Users.Add(u);
                context.SaveChanges();

            }
        }
    }
}
