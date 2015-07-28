
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Datingsite.DropDownLists
{
    public class ProfileStatusList
    {
        public static IEnumerable<ProfileStatus> profileStatusList = new List<ProfileStatus>
            {
                new ProfileStatus
                {
                    ProfileID = 1,
                    Status = "Upptäckbar profil"
                },
                new ProfileStatus
                {
                    ProfileID = 2,
                    Status = "Privat profil"
                }
            };
    }
}