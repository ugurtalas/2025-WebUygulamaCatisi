using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Diagnostics;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var Response = Business.UrunService.TumUrunListele();
            
            return View(Response);
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult IlkMetot()
        {
            return View();
        }

        public IActionResult FarkliViewAc()
        {
            return View("IkinciView");
        }

        public IActionResult FarkliKlasordenViewAc()
        {
            return View("/Views/Ornek/OrnekView.cshtml");
        }

        public IActionResult ModelKullananMetot()
        {
            Models.IlkModel Nesne = new IlkModel();
            Nesne.Ad = "Osman";
            Nesne.Soyad = "Hasan";
            _logger.LogInformation("Nesne  baþarýlý þekilde oluþtu.");
            return View("ModelKullananView",Nesne);
        }

        //ilk controller
        //ilk view
        //farklý view
        //logger
        //ilk model
        // view de model kullanýmý
        // Nesne yada liste örneði


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
