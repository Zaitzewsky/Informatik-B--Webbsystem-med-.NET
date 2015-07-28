using System.Web.Mvc;
using System.Web.Security;
using DAL;
using DAL.Repositories;
using Datingsite.Models;

namespace Datingsite.Controllers.SearchResult
{
    [Authorize] //Om användaren inte är inloggad så öppnas sidan för att logga in!
                //Kolla i Web.config --> system.web --> authentication
    public class SearchController : Controller
    {
        // GET: Search

        public ActionResult ReturnSearchResult(string searchQuery)
        {
            var users = UserRepository.GetAllUsers(searchQuery);
            var model = new SearchModel();

            model.Users = users;
            model.User = GetLoggedInUser();

            return View(model);
        }




        /// <summary>
        /// Renderar en partial view som inkluderas i vyn "ReturnSearchResult".
        /// </summary>
        /// <returns></returns>
        public ViewResult _SearchFieldPartialViewForSearchResult()
        {
            return View("_SearchFieldPartialViewForSearchResult");
        }




        /// <summary>
        /// Tar första bokstaven i strängen och skickar den vidare
        /// till metoden "ReturnSearchResult" i kontrollern "Search".
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SearchResult(SearchModel model)
        {
            if (!ModelState.IsValid)
                return View("ReturnSearchResult");

            string searchQuery = model.Search.Substring(0, 1);

            return RedirectToAction("ReturnSearchResult", "Search", new { searchQuery });
            //                      Metoden                Controllern   Parametern
        }



        /// <summary>
        /// Returnerar den användare som är inloggad
        /// </summary>
        /// <returns></returns>
        private User GetLoggedInUser()
        {
            var username = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
            var user = UserRepository.GetUser(username);
            return user;
        }
    }
}