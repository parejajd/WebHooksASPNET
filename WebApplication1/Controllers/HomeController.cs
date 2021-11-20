using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebHookReceiver.Models;
using WebHookReceiver.Services;

namespace WebHookReceiver.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGithubHandler _handler;

        public HomeController(IGithubHandler handler)
        { 
            _handler = handler;
        }

        public async Task<IActionResult> Index()
        {
            var list = await this._handler.ViewCommit();
            return View(list);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
