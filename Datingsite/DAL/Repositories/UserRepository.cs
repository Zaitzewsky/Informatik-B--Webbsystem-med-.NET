using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepository
    {
        public static List<User> GetAllUsers()
        {
            using (var context = new DatabaseEntities())
            {
                return context.Users
                    .OrderBy(x => x.FirstName)
                    .ToList();
            }
        }

        /// <summary>
        /// Hämtar alla användare som har den första bokstaven
        /// i sökningen i sitt namn och de personer som har sin
        /// profil som "Upptäckbar profil".
        /// </summary>
        /// <param name="firstLetterInFirstName"></param>
        /// <returns></returns>
        public static List<User> GetAllUsers(string firstLetterInFirstName)
        {
            using (var context = new DatabaseEntities())
            {
                return context.Users
                    .Where(x => x.FirstName.Contains(firstLetterInFirstName)
                            && x.Private.Equals(1))
                    .OrderBy(x => x.FirstName)
                    .ToList();
            }
        }

        /// <summary>
        /// Returnerar en användare genom att matcha användarnamnet i tabellen "Login".
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static User GetUser(string username)
        {
            using (var context = new DatabaseEntities())
            {
                return context.Users.FirstOrDefault(x =>
                    x.Login.LoginName.Equals(username));
            }
        }

        /// <summary>
        /// Returnerar en login genom att matcha användarnamnet i tabellen "Login".
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static Login GetLogin(string username)
        {
            using (var context = new DatabaseEntities())
            {
                return context.Logins.FirstOrDefault(x =>
                    x.LoginName.Equals(username));
            }
        }

        /// <summary>
        /// Returnerar en profilbild genom att matcha användarid:et i tabellen "Images".
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static Image GetImage(int userID)
        {
            using (var context = new DatabaseEntities())
            {
                return context.Images.FirstOrDefault(x =>
                    x.UserID.Equals(userID));
            }
        }
        
        /// <summary>
        /// Returnerar en användare baserat på det UserID som skickas in.
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static User GetUser(int userID)
        {
            using (var context = new DatabaseEntities())
            {
                return context.Users.FirstOrDefault(x =>
                    x.UserID.Equals(userID));
            }
        }
        
    }
}
