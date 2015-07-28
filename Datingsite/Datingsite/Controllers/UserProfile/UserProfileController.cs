using System.Web.Mvc;
using System.Web.Security;
using DAL;
using DAL.Repositories;
using Datingsite.Models;
using Datingsite.Models.UserProfileModel;

namespace Datingsite.Controllers.UserProfile
{
    [Authorize] //Om användaren inte är inloggad så öppnas sidan för att logga in!
                //Kolla i Web.config --> system.web --> authentication
    public class UserProfileController : Controller
    {
        // GET: UserProfile

        public ActionResult ProfileStart()
        {
            var model = new UserProfileModel();

            model.User = GetLoggedInUser();
            model.LoggedInUser = GetLoggedInUser();
            model.Image = UserRepository.GetImage(model.User.UserID);
            model.FriendRequests = FriendRequestRepository.FriendRequests(model.User.UserID);
            return View(model);
        }
        public ActionResult ProfileStartForOtherUser(int userID)
        {
            var model = new UserProfileModel();

            model.User = UserRepository.GetUser(userID);
            model.LoggedInUser = GetLoggedInUser();
            model.FriendRequests = FriendRequestRepository.FriendRequests(model.LoggedInUser.UserID);
            model.Image = UserRepository.GetImage(userID);
            return View("ProfileStart", model);
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
                return View("ProfileStart");

            string searchQuery = model.Search.Substring(0, 1);

            return RedirectToAction("ReturnSearchResult", "Search", new { searchQuery });
            //                      Metoden                Controllern   Parametern

        }
        /// <summary>
        /// Returnerar den inloggade användaren.
        /// </summary>
        /// <returns></returns>
        private User GetLoggedInUser()
        {
            var username = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
            return UserRepository.GetUser(username);
        }
    }
}