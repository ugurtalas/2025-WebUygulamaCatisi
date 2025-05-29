using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MVC.Components
{
    public class MenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            int RolNo = -1;
            if (HttpContext.User.Claims.FirstOrDefault(f => f.Type == "No") != null)
            {
                var RolList = HttpContext.User.FindAll(ClaimTypes.Role).ToList();
                if(RolList.Count >0)
                    RolNo = Convert.ToInt32(RolList.FirstOrDefault().Value);
            }
            return View("/Views/components/Menu.cshtml",RolNo);
        }
    }
}
