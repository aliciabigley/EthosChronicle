using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EthosChronicle.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            //ViewBag.Message = "Save Family Stories";

            return View();
        }

        public ActionResult HowItWorks()
        {
            ViewBag.Message = "How It Works ";

            return View();
        }
        public ActionResult Contact()

        {
            ViewBag.Message = "Contact Us.";

            return View();
        }
        public ActionResult Samples()

        {
            ViewBag.Message = "Videos we've done in the past";

            return View();
        }
    }
    }
