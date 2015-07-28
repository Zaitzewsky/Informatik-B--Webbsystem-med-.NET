using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Datingsite.Resources.Views;

namespace Datingsite.Models.LoginModel
{
    public class LoginModel
    {

        [Display(Name = "LoginNameLabel",
        ResourceType = typeof(LoginStrings))]
        [Required(ErrorMessageResourceName = "MissingLoginName",
        ErrorMessageResourceType = typeof(LoginStrings))]
        public string Username { get; set; }
        
        [Display(Name = "PasswordLabel", 
        ResourceType = typeof(LoginStrings))]
        [Required(ErrorMessageResourceName = "MissingPassword",
        ErrorMessageResourceType = typeof(LoginStrings))]
        public string Password { get; set; }
     }
}