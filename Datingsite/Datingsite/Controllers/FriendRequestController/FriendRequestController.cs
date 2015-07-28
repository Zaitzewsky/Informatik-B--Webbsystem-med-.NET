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

namespace Datingsite.Controllers.FriendRequestController
{
    [Authorize] //Om användaren inte är inloggad så öppnas sidan för att logga in!
    //Kolla i Web.config --> system.web --> authentication
    public class FriendRequestController : Controller
    {
        public ActionResult FriendRequests(int userID)
        {
            var model = new FriendsListModel();
            model.LoggedInUser = GetLoggedInUser();
            model.User = UserRepository.GetUser(userID);
            model.FriendRequests = FriendRequestRepository.FriendRequests(userID);
            return View("FriendRequest", model);
        }

        //Skickar med id:et på den som har skickat friendrequesten(userID) och den som svarar på 
        //förfrågan (user.UserID) samt svaret på frågan
        public ActionResult AnswerFriendRequest(int userID, int answer)
        {
            var user = GetLoggedInUser();
            FriendRequestRepository.AnswerFriendRequest(userID, user.UserID, answer);
            return RedirectToAction("ProfileStart", "UserProfile");
        }

        //Metod för att lägga till vän som användaren(user) skickar
        // GET: FriendRequest
        public ActionResult AddFriend(int friendID)
        {
            var user = GetLoggedInUser();
            FriendRequestRepository.AddFriend(user.UserID, friendID);
            return RedirectToAction("ProfileStart", "UserProfile");
        }
        //hämtar användaren som är inloggad
        private User GetLoggedInUser()
        {
            var username = User.Identity.Name;
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
                return View("FriendRequest");

            string searchQuery = model.Search.Substring(0, 1);
            return RedirectToAction("ReturnSearchResult", "Search", new { searchQuery });
            //                      Metoden                Controllern   Parametern
        }
    }
}