using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DAL;

namespace Datingsite.Models
{
    public class SearchModel
    {
        [Display(Name = "Sök: ")]
        [Required(ErrorMessage = "Du måste fylla i ett användarnamn!")]
        public string Search { get; set; }

        public List<User> Users { get; set; }

        public User User { get; set; }
    }
}