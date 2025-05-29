using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MVC.Filters;

public class MaskelemeResultFilter : IResultFilter
{
    public void OnResultExecuting(ResultExecutingContext viewResult)
    {
        if (viewResult.Result is ViewResult result)
        {
            var Model = result.Model as List<DTO.Response.Urun.UrunOzetBilgi>;

            foreach (var item in Model)
            {

                if (item.Fiyat < 100)
                    item.Ad = item.Ad + "   indirimli Ürün ";
            }
        }

    }
    public void OnResultExecuted(ResultExecutedContext viewResult)
    {

    }
}
