using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{

    public class SepetController : Controller
    {
        [Authorize(Roles ="3")]
        public IActionResult UrunEkle(int UrunNo)
        {
            int KullaniciNo = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(f => f.Type == "No").Value);
            Business.SepetService.SepeteUrunEkle(KullaniciNo, UrunNo);
            return RedirectToAction("Index", "Home");
        }

      
    }
}
