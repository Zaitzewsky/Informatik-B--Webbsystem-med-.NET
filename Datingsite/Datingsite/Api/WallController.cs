using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using System.Web.UI.WebControls;
using DAL;
using DAL.Repositories;
using Datingsite.Models.UserProfileModel;
using Example.Web.Api.Models;

namespace Example.Web.Api
{
    
    public class WallController : ApiController
    {
        // tar in modellen som postats med kommentaren och skapar kommentaren i metoden där datum 
        // läggs till och använder som skickar kommentaren(sender)
        // POST api/wall
        [HttpPost]
        public void Post(WallDto model)
        {
            try
            {
            var sender = GetLoggedInUser();
            DateTime CommentDate = DateTime.Now;
            if (ModelState.IsValid)
            {
              WallRepository.AddWallComment(model.WallOwnerID, sender.UserID, model.Comment, CommentDate);
            }
            }
            catch (Exception) { }
        }

        //Tar fram användaren som är inloggad
        private User GetLoggedInUser()
        {
            var username = User.Identity.Name;
            return UserRepository.GetUser(username);
        }

        //Hämtar alla kommentarer för användarens profil(userID)
        [HttpGet]
        public List<WallDto> GetCommentsForUser(int userID)
        {
            var userWalls = WallRepository.GetCommentsForUser(userID);
            var userWallDtos = new List<WallDto>();
            
            foreach (var comments in userWalls)
            {
                var dto = new WallDto(comments);
                userWallDtos.Add(dto);
            }
            return userWallDtos;
        }
        
    }
}

