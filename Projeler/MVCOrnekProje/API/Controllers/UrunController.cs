using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrunController : ControllerBase
    {
        [HttpGet("UrunListele")]
        public IActionResult UrunListele() {

            var Cevap = Business.UrunService.UrunListele();
            return Ok(Cevap);
;
        }


        [HttpGet("UrunListeleGet")]
        public IActionResult UrunListeleGet()
        {

            var Cevap = Business.UrunService.UrunListele();
            return Ok(Cevap);
            
        }

        [HttpPost]
        public IActionResult UrunListelePost()
        {

            var Cevap = Business.UrunService.UrunListele();
            return Ok(Cevap);
            
        }

        [HttpGet("UcuzUrunGetir")]
        public IActionResult UcuzUrunGetir(int Limit) { 
            var Cevap = Business.UrunService.UcuzUurnListele(Limit); 
            return Ok(Cevap);
        
        }

    }
}
