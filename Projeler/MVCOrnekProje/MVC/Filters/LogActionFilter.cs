using Microsoft.AspNetCore.Mvc.Filters;

namespace MVC.Filters;

public class LogActionFilter : ActionFilterAttribute
{
    private readonly string _path;

    public LogActionFilter() {

        _path = Path.Combine(Directory.GetCurrentDirectory(), "LogDosyasi.txt");
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {

        var Request = context.HttpContext.Request;
        var  ip = Request.HttpContext.Connection.RemoteIpAddress;
        var  path  = Request.Path;
        var User = Request.HttpContext.User.Identity.IsAuthenticated ?
            Request.HttpContext.User.Claims.FirstOrDefault(f => f.Type == "Ad").Value.ToString() : "Oturum yok. ";

        string LogBilgi =$"[{DateTime.Now}] ip : {ip}, Kullanici = {User} , Metot = {path} ";
        LogYAz(LogBilgi);
        base.OnActionExecuting(context);
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        //Console.WriteLine("Filter  çalıştı 2 ");
        base.OnActionExecuted(context);
    }

    public void LogYAz(string LogBilgisi)
    {
        try
        {
            File.AppendAllText(_path, LogBilgisi);
        }
        catch 
        {

         
        }
    }

}
