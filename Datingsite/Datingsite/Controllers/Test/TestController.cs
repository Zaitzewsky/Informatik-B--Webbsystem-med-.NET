using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Datingsite.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult TestException()
        {
            throw new Exception("Woops!");
        }
    }
}