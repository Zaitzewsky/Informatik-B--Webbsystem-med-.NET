using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class EditProfileRepository
    {
        /// <summary>
        /// Ändrar användarens uppgifter beroende på vilka uppgifter som användaren valt att ändra.
        /// </summary>
        /// <returns></returns>
        public static void EditUser(int loginID, int userID, string firstname, string lastname,
        string phone, int age, int gender, string email, int privat, string city, int preferedeGender,string loginName, string password)
        {
            using (var context = new DatabaseEntities())
            {
                User user = context.Users.FirstOrDefault(x => x.UserID == userID);
                Login login = context.Logins.FirstOrDefault(x => x.LoginID == loginID);

                user.FirstName = firstname;
                user.LastName = lastname;
                user.Phone = phone;
                user.Age = age;
                user.Phone = phone;
                user.Age = age;
                user.Gender = gender;
                user.Email = email;
                user.Private = privat;
                user.City = city;
                user.PreferedGender = preferedeGender;
                login.LoginName = loginName;
                login.Password = password;
                context.SaveChanges();
            }
        }
        /// <summary>
        ///Lägger till en ny profilbilden för användaren.
        /// </summary>
        /// <param name="userID, profilImage"></param>
        /// <returns></returns>
        public static void AddProfileImage(int userID, byte[] profilImage)
        {
            using (var context = new DatabaseEntities())
            {
                
                 Image i = new Image
                {
                    UserID = userID,
                    Picture = profilImage
                };

                context.Images.Add(i);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Uppdaterar profilbilden till den som användaren valt att ändra till.
        /// </summary>
        /// <param name="userID, profilImage"></param>
        /// <returns></returns>
        public static void EditProfileImage(int userID, byte[] profilImage)
        {
            using (var context = new DatabaseEntities())
            {
                Image image = context.Images.FirstOrDefault(x => x.UserID == userID);
                image.Picture = profilImage;
                context.SaveChanges();
            }
        }
   
    }
}