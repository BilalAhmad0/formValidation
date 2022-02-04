using BasicAuthentication.Model;
using formsValidation.Manager;
using formsValidation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;


namespace formsValidation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult display_page(User usr)
        {
            return View(usr);
        }
       
        [HttpPost]
        public IActionResult CheckValidationBehind([Bind] User usr)
        {
            display_page(usr);
            AuthenticateModel user_data = new AuthenticateModel();
            user_data.Username = usr.username;
            user_data.Password = usr.password;
            try
            {
                AuthenticationManger mg = new AuthenticationManger();
                var check= mg.Authenticate(user_data);
                if (check)
                {
                    return RedirectToAction("display_page");
                }
                else
                {
                    return RedirectToAction("Error");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
