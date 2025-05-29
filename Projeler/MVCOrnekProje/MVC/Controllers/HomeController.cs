using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using MVC.Filters;
using MVC.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMemoryCache _cache;
        private readonly string CacheKey;

        public HomeController(ILogger<HomeController> logger, IMemoryCache memoryCache)
        {
            _logger = logger;
            _cache = memoryCache;
            CacheKey = "UrunList";
        }

        [Filters.LogActionFilter]
        [ServiceFilter(typeof(MaskelemeResultFilter))]
        public IActionResult Index()
        {

            List<DTO.Response.Urun.UrunOzetBilgi> Cevap = new List<DTO.Response.Urun.UrunOzetBilgi>();
            var ResponseCache = _cache.Get<List<DTO.Response.Urun.UrunOzetBilgi>>(CacheKey);
            ViewBag.Kaynak = "Cache";

            if (ResponseCache == null)
            {
                Cevap = Business.UrunService.TumUrunListele();
                _cache.Set(CacheKey, Cevap);
                ViewBag.Kaynak = "Data Base";
                return View(Cevap);
            }


            return View(ResponseCache);
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
