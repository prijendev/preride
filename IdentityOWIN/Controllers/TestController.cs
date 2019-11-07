using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityOWIN.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        [Authorize]
        public ActionResult Index()
        {
            return Content("You are authorized");
        }
    }
}