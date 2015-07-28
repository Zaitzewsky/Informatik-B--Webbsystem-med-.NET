using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace Datingsite.Models.FriendsListModel
{
    public class FriendsListModel
    {
        public User User { get; set; }

        public User LoggedInUser { get; set; }
        
        public List<FriendRequest> FriendList { get; set; }
        public List<FriendRequest> FriendList2 { get; set; }
        public List<FriendRequest> FriendRequests { get; set; }
        //variabel för att visa antalet friendrequests
        public int countFriendRequests { get; set; }
        
    }
}