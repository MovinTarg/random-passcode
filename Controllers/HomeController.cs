using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
 
namespace random_passcode
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            int? passcodeCount = HttpContext.Session.GetInt32("passcodeCount");
            if(passcodeCount == null)
            {
                passcodeCount = 0;
            }
            passcodeCount += 1;
            ViewBag.passcodeCount = passcodeCount;
            HttpContext.Session.SetInt32("passcodeCount", (int)passcodeCount);

            string allowedChar = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?_-";
            string passCode = "";
            Random rand = new Random();
            for (int i = 0; i < 14; i++)
            {
            passCode = passCode + allowedChar[rand.Next(0, allowedChar.Length)];
            }
            ViewBag.passCode = passCode;
            return View();
            //OR
            // return View("Index");
            //Both of these returns will render the same view (You only need one!)
        }
    }
}