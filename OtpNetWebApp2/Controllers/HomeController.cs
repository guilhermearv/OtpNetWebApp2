using OtpNet;
using OtpNetWebApp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtpNetWebApp2.Controllers
{
    public class HomeController : Controller
    {
        public Totp totp { get; set; }
        
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            if (loginViewModel.Username == "Admin" && loginViewModel.Password == "Admin123")
            {
                if (loginViewModel.Verify2FA)
                {
                    return RedirectToAction("VerifyAuth");
                }
                return RedirectToAction("Index", "Profile");
            }
            else
            {
                return View();
            }
        }

        public ActionResult VerifyAuth()
        {            
            int timeStep = 180;
            var base32Secret = KeyGeneration.GenerateRandomKey(20);
            this.totp = new Totp(base32Secret, step: timeStep);
            TempData["totp"] = this.totp;

            ViewBag.totpCode = totp.ComputeTotp(DateTime.UtcNow);
            return View();
        }

        [HttpPost]
        public ActionResult VerifyAuth(VerifyAuthViewModel verifyAuthViewModel)
        {
            this.totp = (Totp)TempData["totp"];
            TempData.Keep("totp");
            var token = verifyAuthViewModel.Passcode;
            //VerificationWindow verificationWindow = new VerificationWindow(previous: 1, future: 1);
            long timeStepMatched;
            bool isValid = totp.VerifyTotp(token, out timeStepMatched, window: null);

            if (isValid)
            {
                Session["id"] = 12500;
                Session["username"] = "Admin";
                TempData.Remove("totp");
                return RedirectToAction("Index","Profile");
            }
            return View("VerifyAuth");
        }
    }
}