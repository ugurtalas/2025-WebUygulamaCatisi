using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Net.Security;

namespace MVC.Controllers
{
    public class ResponseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewBagOrnegi()
        {
            ViewBag.Ad = "Bilecik";
            return View("/Views/Reponse/ResponseView.cshtml");
        }


        public IActionResult ViewDataOrnegi()
        {
            ViewData["Veri"] = "Bilecik";
            return View("/Views/Reponse/ResponseView.cshtml");
        }

        public IActionResult ViewDataBagOrnegi()
        {
            ViewBag.Ad = "Bilecik";
            ViewData["Veri"] = "BŞEÜ";
            return View("/Views/Reponse/ResponseView.cshtml");
        }

        public IActionResult TempDataOrnegi()
        {
            TempData["TempVeri"]= "Bilecik";
            return View("/Views/Reponse/ResponseView.cshtml");
        }

        public IActionResult TempDataModelOrnegi()
        {
            Kullanici Nesne =new Kullanici();
            Nesne.No = 5;
            Nesne.Ad = "uğur";
            Nesne.Soyad = "Talaş";
            TempData["TempModel"] = Nesne;
            return View("/Views/Reponse/ResponseView.cshtml");
        }

        public IActionResult NesneOrnegi()
        {
            Kullanici Nesne = new Kullanici() { No=1,Ad="Ugur",Soyad="TALAS"};
            return View("/Views/Reponse/ResponseNesne.cshtml",Nesne);
        }

        public IActionResult ListeOrnegi()
        {
            List<Kullanici> Liste = new List<Kullanici>();
            Liste.Add(new Kullanici { Ad="İkra", Soyad="TALAŞ" });
            Liste.Add(new Kullanici { Ad="Beyazıd", Soyad="TALAŞ" });
            Liste.Add(new Kullanici { Ad="Uğur", Soyad="TALAŞ" });
            return View("/Views/Reponse/ResponseListe.cshtml", Liste);
        }
        public IActionResult TupleOrnegi()
        {
            Kullanici Nesne = new Kullanici() { No = 1, Ad = "Ugur", Soyad = "TALAS" };
            IlkModel Nesne2 = new IlkModel() { No = 1, Ad = "İkra", Soyad = "TALAS" };
            var Cevap = (Nesne, Nesne2);
            return View("/Views/Reponse/ResponseTuple.cshtml", Cevap);
        }

    }
}
