using Microsoft.AspNetCore.Mvc;

namespace MVC.Components
{
    public class SepetViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            int SepettekiUrunsayisi = 0;
            if (HttpContext.User.Claims.FirstOrDefault(f => f.Type == "No") != null)
            {
                int KullaniciNo = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(f => f.Type == "No").Value);
                SepettekiUrunsayisi = Business.SepetService.SepetteKacUrunVar(KullaniciNo);
            }
            
            return View("/Views/Components/Sepet.cshtml", SepettekiUrunsayisi);
        }
    }
}
