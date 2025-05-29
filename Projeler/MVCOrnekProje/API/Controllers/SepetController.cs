using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SepetController : ControllerBase
    {
        [HttpGet("SepetGoruntule")]
        public ActionResult SepetGoruntule(int KullaniciNo) {
            var SepetUrunler = Business.SepetService.SepetGoruntule(KullaniciNo);
            return Ok(SepetUrunler);
        }

        [HttpPost("SepetGoruntulePost")]
        public ActionResult SepetGoruntulePost(int KullaniciNo)
        {
            var SepetUrunler = Business.SepetService.SepetGoruntule(KullaniciNo);
            return Ok(SepetUrunler);
        }
    }
}
