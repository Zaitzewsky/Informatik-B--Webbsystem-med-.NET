using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class FriendRequestRepository
    {
        //Kollar så inte personerna redan är vänner eller har en friendrequest som väntar på svar
        public static FriendRequest ValidateFriendRequest(int userID, int friendID)
        {
            using (var context = new DatabaseEntities())
            {
                    return context.FriendRequests.FirstOrDefault(x =>
                    x.UserID.Equals(userID) &&
                    x.FriendID.Equals(friendID) ||
                    x.UserID.Equals(friendID) &&
                    x.FriendID.Equals(userID));
            }
        }

        //Beroende på ifall användaren accepterar vänförfrågan eller nekar så blir dom vänner eller icke då statusen uppdateras.
        public static void AnswerFriendRequest(int userID, int friendID, int answer)
        {
            using (var context = new DatabaseEntities())
            {
                    FriendRequest friendRequest = context.FriendRequests.FirstOrDefault(x => x.UserID == userID && x.FriendID == friendID);
                    friendRequest.Status = answer;
                    context.SaveChanges();
            }
        }
        
        //Listar alla vänförfrågningar som är obesvarade som alltså har status 3.
        public static List<FriendRequest> FriendRequests(int userID)
        {
            using (var context = new DatabaseEntities())
            {

                var result = context.FriendRequests
                    .Include(x => x.User1)
                    .Where(x => x.FriendID == userID &&
                                x.Status == 3)
                    .ToList();
                return result;
            }
        }
        
        //När man klickar på lägg till vän symbolen så uppdateras statusen till 3 som betyder att den 
        //som man skickat vänförfrågan till kommer kunna accpetera eller neka vänförfrågan 
        public static void AddFriend(int userID, int friendID)
        {
            using (var context = new DatabaseEntities())
            {
                FriendRequest fr = new FriendRequest
                {
                    UserID = userID,
                    FriendID = friendID,
                    Status = 3,
                };
                context.FriendRequests.Add(fr);
                context.SaveChanges();
              }
        }

    }
}
