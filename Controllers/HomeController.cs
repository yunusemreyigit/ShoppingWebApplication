using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using ShoppingApp.Data;
using ShoppingApp.Models;
using System.Diagnostics;

namespace ShoppingApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ShoppingApp.Data.Repository _repository;

        public HomeController(ILogger<HomeController> logger, ShoppingApp.Data.Repository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index()
        {
            ViewBag.productList = _repository.Products.ToList();
            return View();
        }
        public IActionResult Admin()
        {
            TempData["preURL"] = Request.Headers["Referer"];
            ViewBag.productList = _repository.Products.ToList();
            ViewBag.productTypeList = _repository.Types.ToList();
            return View();
        }
        public IActionResult GoBack()
        {
            if (TempData["preURL"] == null) return View(Index);

            var preURL = TempData["preURL"].ToString();
            return Redirect(preURL);
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