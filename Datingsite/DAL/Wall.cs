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
    
    public partial class Wall
    {
        public int WallID { get; set; }
        public int WallOwnerID { get; set; }
        public int SenderID { get; set; }
        public string Comment { get; set; }
        public System.DateTime Date { get; set; }
    
        public virtual User WallSender { get; set; }
        public virtual User WallOwner { get; set; }
    }
}
