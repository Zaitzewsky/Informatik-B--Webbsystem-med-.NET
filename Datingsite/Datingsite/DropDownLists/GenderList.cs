
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Datingsite.DropDownLists
{
    public static class GenderList
    {
        public static IEnumerable<Gender> genderList = new List<Gender>
            {
                new Gender
                {
                    GenderID = 1,
                    GenderName = "Man"
                },
                new Gender
                {
                    GenderID = 2,
                    GenderName = "Kvinna"
                }
            };
    }
}