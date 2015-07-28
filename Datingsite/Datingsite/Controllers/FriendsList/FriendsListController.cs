using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DAL;
using DAL.Repositories;
using Datingsite.Models;
using Datingsite.Models.FriendsListModel;
using Datingsite.Models.UserProfileModel;

namespace Datingsite.Controllers.FriendsList
{
    [Authorize] //Om användaren inte är inloggad så öppnas sidan för att logga in!
    //Kolla i Web.config --> system.web --> authentication
    public class FriendsListController : Controller
    {

       public ActionResult FriendsList(int userID)
        {
            var model = new FriendsListModel();
            
            model.User = UserRepository.GetUser(userID);
            model.LoggedInUser = GetLoggedInUser();
            //hämtar vänner där UserID == userID och status == 1
            model.FriendList = FriendsListRepository.FriendsList(userID);
            //hämtar vänner där friendID == userID och status == 1
            model.FriendList2 = FriendsListRepository.FriendsList2(userID);
            model.FriendRequests = FriendRequestRepository.FriendRequests(model.LoggedInUser.UserID);
            return View("FriendsList", model);
        }
        
        //hämtar den inloggade användaren
        private User GetLoggedInUser()
        {
            var username = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
            return UserRepository.GetUser(username);
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
                return View("FriendsList");

            string searchQuery = model.Search.Substring(0, 1);
            return RedirectToAction("ReturnSearchResult", "Search", new { searchQuery });
            //                      Metoden                Controllern   Parametern
        }
    }
}
