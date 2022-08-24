using BiofarmaAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json.Serialization;

namespace BiofarmaAssignment.Controllers
{
    public class UserController : Controller
    {
        Uri baseAddress = new Uri("https://gorest.co.in/public/v2");
        HttpClient client;
        public UserController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        public IActionResult Index()
        {
            List<UserViewModel> modelList = new List<UserViewModel>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress+"/users").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                modelList = JsonConvert.DeserializeObject<List<UserViewModel>>(data);
            }
            return View(modelList);
        }

        #region API CALLS
        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    var productList = UserController.
        //}
        #endregion
    }
}
