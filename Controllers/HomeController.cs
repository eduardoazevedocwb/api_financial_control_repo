using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace api_financial_control.Controllers
{
    public class HomeController : Controller
    {
        public void Index()
        {
            ViewBag.Title = "Home Page";
        }
    }
}
