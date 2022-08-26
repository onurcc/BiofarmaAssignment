using AjaxPostContacts.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System;
using Newtonsoft.Json.Linq;

namespace AjaxPostContacts.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public ActionResult AddContact(string name, DateTime recorddate, int age, string city)
        {
            var contact = new ContactModel();

            contact.Name = name;
            contact.RecordDate = recorddate;
            contact.Age = age;
            contact.City = city;

            return new JsonResult(new { data = contact });
        }
    }
}
