﻿using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class RequestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // Query String
        public IActionResult QueryStringOrnegi(string Ad)
        {
            ViewBag.Mesaj =Ad;
            return View("/Views/Request/Request.cshtml");
        }

        public IActionResult QueryStringOrnegiCoklu(string Ad,string Soyad)
        {
            ViewBag.Mesaj = Ad +" "+Soyad ;
            return View("/Views/Request/Request.cshtml");
        }

        public IActionResult QueryStringOrnegiModel(Kullanici Veri)
        {
            ViewBag.Mesaj = Veri.Ad + " " + Veri.Soyad;
            return View("/Views/Request/Request.cshtml");
        }

        public IActionResult QueryStringYakalama()
        {
            ViewBag.Mesaj = Request.Query["Ad"].ToString() ;
            return View("/Views/Request/Request.cshtml");
        }


        //Routing 
        public IActionResult DefaulRouting(string Id)
        {
            ViewBag.Mesaj = Id;
            return View("/Views/Request/Request.cshtml");
        }

        [HttpGet]
        [Route("KendiRotan/{Ad?}/{Soyad?}")]
        public IActionResult Routing(string Ad, string Soyad)
        {
            ViewBag.Mesaj = Ad + " " + Soyad;
            return View("/Views/Request/Request.cshtml");
        }

        //Form
        public IActionResult FormAc()
        {
            return View("/Views/Request/Form.cshtml");
        }

        public IActionResult FormdanVeriAl(string Ad, string Soyad)
        {
            ViewBag.Mesaj = Ad + " " + Soyad;
            return View("/Views/Request/Request.cshtml");
        }
        public IActionResult FormdanModelAl(Kullanici Veri)
        {
            ViewBag.Mesaj = Veri.Ad + " " + Veri.Soyad;
            return View("/Views/Request/Request.cshtml");
        }

        public IActionResult FormAcModelIle()
        {
            Kullanici Nesne = new Kullanici() { No = 1, Ad = "Ugur", Soyad = "TALAS" };
            return View("/Views/request/doluform.cshtml", Nesne);
        }


        // Ajax
        public IActionResult AjaxViewAc()
        {
            return View("/Views/Request/Ajax.cshtml");
        }


        public IActionResult AjaxModelAl(Kullanici Veri)
        {
            ViewBag.Mesaj = Veri.Ad + " " + Veri.Soyad;
            return View("/Views/Request/Ajax.cshtml");
        }


        public IActionResult AjaxModelGetir()
        {
            Kullanici Nesne = new Kullanici() { No = 1, Ad = "Ugur", Soyad = "TALAS" };
            return Json(Nesne);
        }
    }
}
