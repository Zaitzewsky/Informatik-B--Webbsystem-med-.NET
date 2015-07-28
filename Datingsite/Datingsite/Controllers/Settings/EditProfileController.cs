
using System.IO;
using System.Reflection.Emit;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using DAL;
using DAL.Repositories;
using Datingsite.Models;
using Datingsite.Models.UserProfileModel;

namespace Datingsite.Controllers.UserProfile
{
    [Authorize] //Om användaren inte är inloggad så öppnas sidan för att logga in!
    //Kolla i Web.config --> system.web --> authentication
    public class EditProfileController : Controller
    {
        //GET: UserProfile
        public ActionResult EditProfile()
        {
            var model = new HomeIndexViewModel();
            model.User = GetLoggedInUser();
            model.Image = UserRepository.GetImage(model.User.UserID);
            model.FriendRequests = FriendRequestRepository.FriendRequests(model.User.UserID);
            model.Login = GetLoggedLogin();

            return View(model);
        }

        
        [HttpPost]
        public ActionResult EditProfile(HomeIndexViewModel model)
        {
            model.User = GetLoggedInUser();
            model.Login = GetLoggedLogin();
            model.FriendRequests = FriendRequestRepository.FriendRequests(model.User.UserID);
            if (ModelState.IsValid)
            {
                var newUsername = RegistrationRepository.ValidateUsername(model.LoginName);
                //validerar ifall användarnamet finns i databasen eller ifall användarnamnet är samma som det nuvarande, 
                //om det är null finns den inte och användarnamnet kan läggas till
                if (model.Login.LoginName == model.LoginName || newUsername == null)
                {
                    EditProfileRepository.EditUser(model.Login.LoginID, model.User.UserID,
                    model.FirstName, model.LastName, model.Phone,
                    model.Age, model.Gender, model.Email, model.ProfileStatus, model.City, model.PreferedGender,
                    model.LoginName, model.Password);
                    FormsAuthentication.SetAuthCookie(model.LoginName, false);
                    return RedirectToAction("ProfileStart", "UserProfile");
                }
                    //Ifall det redan finns måste man skriva in ett annat och får felmeddelandet nedan
                    ModelState.AddModelError("", "Användarnamnet måste vara unikt");
                    return View(model);
             }
            return View(model);
        }
        
        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                // string pic = Path.GetFileName(file.FileName);
                //ifall man ändrar sig och vill spara bildens genväg istället
                //string path = Path.Combine(
                //                  Server.MapPath("~/ProfileImages"), pic);
                //file.SaveAs(path);
                
                // bilden sparas some byte[] och läggs till i visa AddProfileImage
                using (MemoryStream ms = new MemoryStream())
                {
                    var user= GetLoggedInUser();
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                    //ifall null returneras har användaren ingen profilbild och bilden läggs till
                    if (UserRepository.GetImage(user.UserID) == null)
                    {
                        EditProfileRepository.AddProfileImage(user.UserID, array);
                        return RedirectToAction("EditProfile", "EditProfile");
                    }
                    //annars om användaren redan har en profilbild byts bilden ut
                    EditProfileRepository.EditProfileImage(user.UserID,array);
                    return RedirectToAction("EditProfile", "EditProfile");
                }

            }
            // användaren kommer tillbaka till editprofil
            return RedirectToAction("EditProfile", "EditProfile");
        }
        //returnerar den inloggade användaren
        private User GetLoggedInUser()
        {
            var username = User.Identity.Name;
            return UserRepository.GetUser(username);
        }
        //returnerar login för den inloggade användaren
        private DAL.Login GetLoggedLogin()
        {
            var username = User.Identity.Name;
            return UserRepository.GetLogin(username);
        }

   
        public ViewResult _SearchFieldPartialView()
        {
            return View("_SearchFieldPartialView");
        }

        /// <summary>
        /// Tar första bokstaven i strängen och skickar den vidare
        /// till metoden "ReturnSearchResult" i kontrollern "Search"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SearchResult(SearchModel model)
        {
            if (!ModelState.IsValid)
                return View("EditProfile");

            string searchQuery = model.Search.Substring(0, 1);
            return RedirectToAction("ReturnSearchResult", "Search", new { searchQuery });
            //                      Metoden                Controllern   Parametern
        }
    }
}