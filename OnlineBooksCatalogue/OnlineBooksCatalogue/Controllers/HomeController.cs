using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OnlineBooksCatalogue.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBooksCatalogue.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _cofiguration;
        private readonly string apiBaseUrl;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _cofiguration = configuration;
            apiBaseUrl = _cofiguration.GetValue<string>("WebAPIBaseUrl");
        }

        [HttpGet]
        public ActionResult Profile()
        {
            UserInfo user = JsonConvert.DeserializeObject<UserInfo>(Convert.ToString(TempData["Profile"]));
            return View(user);
        }

       
        [HttpGet]
        public ActionResult Index()
        {
            UserInfo user = new UserInfo();
            return View(user);
        }
        
        [HttpPost]
        public async Task<IActionResult> Index(UserInfo user)
        {
            using (HttpClient client = new HttpClient())
            {

             StringContent content = new StringContent(JsonConvert.SerializeObject(user),
                    Encoding.UTF8, "application/json");
                string endpoint = apiBaseUrl; 
                using (var Response = await client.PostAsync(endpoint, content))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        TempData["Profile"] = JsonConvert.SerializeObject(user);
                        return RedirectToAction("Profile");
                    }
                    else
                    {
                        ModelState.Clear();
                        ModelState.AddModelError(string.Empty, "User is not registared");
                        return View();
                    }
                }
            }
        }

       
        [HttpGet]
        public ActionResult Signup()
        {
            UserInfo user = new UserInfo();
            return View(user);
        }
        
        [HttpPost]

        public async Task<IActionResult> Signup(UserInfo user)

        {
            List<UserInfo> list = new List<UserInfo>();
            using (HttpClient client = new HttpClient())
            {
            StringContent content = new StringContent(JsonConvert.SerializeObject(user),
                    Encoding.UTF8, "application/json");
                string endpoint = apiBaseUrl + "/SignUp";
                using (var Response = await client.PostAsync(endpoint, content))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        TempData["Profile"] = JsonConvert.SerializeObject(user);
                        return RedirectToAction("Index");
                    }
                    else if (Response.StatusCode == System.Net.HttpStatusCode.Conflict)
                    {
                        ModelState.Clear();
                        ModelState.AddModelError("Username", "Username Already Exist");
                        return View();
                    }
                    else
                    {
                        return View();
                    }
                }
            }
        }
    }
}
