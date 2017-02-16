using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EthosChronicle.Models;

namespace EthosChronicle.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Videographer()
        {
            var videographerInfo = new VideographerInfo() { };
            return View(videographerInfo);
        }
        public ActionResult DoItYourself()
        {
            return View();
        }
    }
}