using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class UrunController : Controller
    {
        public IActionResult UrunDetayGetir(DTO.Request.BaseRequest request)
        {
            var ResponseUrun =  Business.UrunService.UruNDetayGetir(request);
            
            
            DTO.Request.BaseRequest Baserequest = new DTO.Request.BaseRequest();
            Baserequest.No = ResponseUrun.KategoriNo;
            var ResponseKategoriyeBagliUrun = Business.UrunService.KategoriyeaitUrunListele(Baserequest);

            //ResponseKategoriyeBagliUrun = ResponseKategoriyeBagliUrun.Where(q => q.No != ResponseUrun.No).ToList();
            
            var Cevap = (ResponseUrun, ResponseKategoriyeBagliUrun);


            return View("/Views/Urun/urundetay.cshtml", Cevap);
        }
    }
}
