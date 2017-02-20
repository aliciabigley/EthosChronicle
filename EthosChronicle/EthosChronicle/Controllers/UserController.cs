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
        private ApplicationDbContext db = new ApplicationDbContext();
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
        public ActionResult PricingPackages()
        {
            var pricing = new Pricing() { };
            return View(pricing);
        }
        public ActionResult DoItYourself()
        {
            return View();
        }
    }
}