using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class SiparisController : Controller
    {
        public IActionResult SiparisTamamla()
        {
            int KullaniciNo = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(f => f.Type == "No").Value);
            Business.SiparisService.SiparisTamamla(KullaniciNo);
            return View("/Views/Siparis/SiparisGoster.cshtml", Business.SiparisService.SiparisListele(KullaniciNo));
        }
        public IActionResult SiparisGoster()
        {
            int KullaniciNo = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(f => f.Type == "No").Value);
            return View("/Views/Siparis/SiparisGoster.cshtml", Business.SiparisService.SiparisListele(KullaniciNo));
        }
    }
}
