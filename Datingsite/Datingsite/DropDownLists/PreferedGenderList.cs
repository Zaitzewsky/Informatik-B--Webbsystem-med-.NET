
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Datingsite.DropDownLists
{
    public static class PreferedGenderList
    {
        public static IEnumerable<PreferedGender> preferedGenderList = new List<PreferedGender>
            {
                new PreferedGender
                {
                    PreferedGenderID = 1,
                    PreferedGenderName = "Man"
                },
                new PreferedGender
                {
                    PreferedGenderID = 2,
                    PreferedGenderName = "Kvinna"
                },
                new PreferedGender
                {
                    PreferedGenderID = 3,
                    PreferedGenderName = "Män och kvinnor"
                }
              
            };
    }
}