using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DAL;

namespace Datingsite.Models.UserProfileModel
{
    public class UserProfileModel
    {
        public User User { get; set; }

        public User LoggedInUser { get; set; }
        //variabel för att visa antalet friendrequests
        public int countFriendRequests { get; set; }

        [Required(ErrorMessage = "Meddelande rutan får inte lämnas tom!")]
        public string Comment { get; set; }

        public List<FriendRequest> FriendRequests { get; set; }

        public Image Image { get; set; }
     }

}