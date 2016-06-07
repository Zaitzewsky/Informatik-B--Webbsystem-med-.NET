using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Web;
using DAL;

namespace Example.Web.Api.Models
{
    public class WallDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public User User { get; set; }
      
        public int WallOwnerID { get; set; }
        
        public int WallSenderID { get; set; }
       
        public string Comment { get; set; }
        
        public DateTime CommentDate { get; set; }

        public WallDto()
        {
        }


        public WallDto(Wall w)
        {
            this.WallOwnerID = w.WallOwnerID;
            this.WallSenderID = w.SenderID;
            this.Comment = w.Comment;
            this.CommentDate = w.Date;
            this.FirstName = w.User1.FirstName;
            this.LastName = w.User1.LastName;
        }
    }
}