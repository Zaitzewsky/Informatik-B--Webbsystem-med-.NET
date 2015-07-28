//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.FriendRequests = new HashSet<FriendRequest>();
            this.Images = new HashSet<Image>();
            this.Walls = new HashSet<Wall>();
            this.Walls1 = new HashSet<Wall>();
            this.Visiteds = new HashSet<Visited>();
            this.FriendRequests1 = new HashSet<FriendRequest>();
        }
    
        public int UserID { get; set; }
        public int LoginID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public int Gender { get; set; }
        public string Email { get; set; }
        public int Private { get; set; }
        public string City { get; set; }
        public int PreferedGender { get; set; }
    
        public virtual ICollection<FriendRequest> FriendRequests { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual Login Login { get; set; }
        public virtual ICollection<Wall> Walls { get; set; }
        public virtual ICollection<Wall> Walls1 { get; set; }
        public virtual ICollection<Visited> Visiteds { get; set; }
        public virtual Visited Visited { get; set; }
        public virtual ICollection<FriendRequest> FriendRequests1 { get; set; }
    }
}
