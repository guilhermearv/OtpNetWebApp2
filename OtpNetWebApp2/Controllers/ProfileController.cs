using OtpNetWebApp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtpNetWebApp2.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Error()
        {
            ViewBag.state = "Error";
            return View("Index");
        }
    }
}