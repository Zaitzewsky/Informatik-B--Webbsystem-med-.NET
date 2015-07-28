
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security;
using DAL;

namespace Datingsite.Models
{
    public class HomeIndexViewModel
    {

        public User User { get; set; }

        public User LoggedInUser { get; set; }

        public Image Image { get; set; }

        public Login Login { get; set; }

        public int LoginId { get; set; }

        public List<FriendRequest> FriendRequests { get; set; }
        //variabel för att visa antalet friendrequests
        public int countFriendRequests { get; set; }

        [Display(Name = "Förnamn: ")]
        [Required(ErrorMessage = "Du måste fylla i ett förnamn!")]
        public string FirstName { get; set; }

        [Display(Name = "Efternamn: ")]
        [Required(ErrorMessage = "Du måste fylla i ett efternamn!")]
        public string LastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Telefonnumret måste vara mellan 6 till 30 tecken!")]
        [Display(Name = "Telefonnummer: ")]
        [Required(ErrorMessage = "Du måste fylla i ett telefonnummer!")]
        public string Phone { get; set; }

        [Display(Name = "Ålder: ")]
        [Required(ErrorMessage = "Du måste fylla i ålder!")]
        public int Age { get; set; }

        [Display(Name = "Kön: ")]
        [Required(ErrorMessage = "Du måste välja kön!")]
        public int Gender { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email: ")]
        [Required(ErrorMessage = "Du måste fylla i en Email!")]
        public string Email { get; set; }

        [Display(Name = "Profil status: ")]
        [Required(ErrorMessage = "Du måste välja ifall din profil ska vara privat!")]
        public int ProfileStatus { get; set; }

        [Display(Name = "Stad: ")]
        [Required(ErrorMessage = "Du måste fylla i en stad!")]
        public string City { get; set; }

        [Display(Name = "Söker: ")]
        [Required(ErrorMessage = "Du måste fylla i vilket kön du söker!")]
        public int PreferedGender { get; set; }

        [StringLength(30, MinimumLength = 6, ErrorMessage = "Användarnamnet måste vara mellan 6 till 30 tecken!")]
        [Display(Name = "Användarnamn: ")]
        [Required(ErrorMessage = "Du måste registrera ett användarnamn!")]
        public string LoginName { get; set; }

        [DataType(DataType.Password)]
        [StringLength(255, MinimumLength = 8, ErrorMessage = "Lösenordet måste minst vara 8 tecken långt!")]
        [Display(Name = "Lösenord: ")]
        [Required(ErrorMessage = "Fältet måste vara ifyllt!")]
        [MembershipPassword()]
        public string Password { get; set; }

        [Compare("Password")]
        [DataType(DataType.Password)]
        [StringLength(255, MinimumLength = 8, ErrorMessage = "Lösenordet måste minst vara 8 tecken långt och stämma överens med lösenordet ovan!")]
        [Display(Name = "Bekräfta lösenord: ")]
        [Required(ErrorMessage = "Fältet måste vara ifyllt!")]
        [MembershipPassword()]
        public string ConfirmPassword { get; set; }

        public HttpPostedFileBase ProfileImage { get; set; }
    }
}
