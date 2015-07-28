using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class FriendsListRepository
    {
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

        /// <summary>
        /// Returnerar en lista på vänner baserat på det UserID som skickats in
        /// så hämtas listan baserat på UserID == användaren(userID) och status är 1
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static List<FriendRequest> FriendsList(int userID)
        {
            using (var context = new DatabaseEntities())
            {

                var result = context.FriendRequests
                    .Include(x => x.User)
                    .Where(x => x.UserID == userID &&
                                x.Status == 1)
                    .ToList();
                    return result;
            }
        }

        /// <summary>
        /// Returnerar en lista på vänner baserat på det UserID som skickats in
        /// så hämtas listan baserat på FriendID == användaren(userID) och status är 1
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static List<FriendRequest> FriendsList2(int userID)
        {
            using (var context = new DatabaseEntities())
            {

                var result = context.FriendRequests
                    .Include(x => x.User1)
                    .Where(x => x.FriendID == userID &&
                                x.Status == 1)
                    .ToList();
                return result;
            }
        }
        
        }
}

