using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL;

namespace DAL.Repositories
{
    public class WallRepository
    {
   
        //Returnerar en lista på alla kommentarer som användaren(wallOwnerID) har 
        //och listar i ordning på senaste kommentarerna
        public static List<Wall> GetCommentsForUser(int wallOwnerID)
        {
            using (var context = new DatabaseEntities())
            {
            var result = context.Walls
                    .Include(x => x.WallSender)
                    .Include(x => x.WallOwner)
                    .Where(x => x.WallOwnerID == wallOwnerID)
                    .OrderByDescending(x => x.Date)
                    .ToList();

                return result;
            }
        }

        //Lägger till kommentaren som användaren(senderID) kommenteraren(comment) på personens(wallOwnerID) wall
        public static void AddWallComment(int wallOwnerID, int senderID, string comment, DateTime date)
        {
            using (var context = new DatabaseEntities())
            {
                Wall w = new Wall
                {
                    WallOwnerID = wallOwnerID,
                    SenderID = senderID,
                    Comment = comment,
                    Date = date
                };
                context.Walls.Add(w);
                context.SaveChanges();
            }
        }


    }


}
