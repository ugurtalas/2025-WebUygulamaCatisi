using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MVC.Controllers
{
    [Filters.LogActionFilter]
    public class OturumController : Controller
    {
        public IActionResult LoginAc()
        {
            return View("Views/Oturum/Login.cshtml");
        }

    

        public IActionResult Login(string KullaniciAd , string Parola)
        {
            ViewBag.Mesaj = "";
            DTO.Response.kullanici.KullaniciOturumBilgileri Kullanici =  Business.LoginService.KullaniciDogrula(KullaniciAd, Parola);
            if (Kullanici == null)
            {
                ViewBag.Mesaj = "Kullancı ad veya Parolanız hatalıdır.";
                return View("Views/Oturum/Login.cshtml");
            }

            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim("No", Kullanici.No.ToString()));
            claims.Add(new Claim("Ad", Kullanici.Ad));
            claims.Add(new Claim("Soyad", Kullanici.Soyad));
            claims.Add(new Claim(ClaimTypes.Role ,Kullanici.RolNo.ToString()));

            ClaimsIdentity identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);

            AuthenticationProperties authenticationProperties = new AuthenticationProperties();

            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authenticationProperties);

            return  RedirectToAction("Index", "Home");
        }
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync();
            return View("Views/Oturum/Login.cshtml");
        }
    }
}
