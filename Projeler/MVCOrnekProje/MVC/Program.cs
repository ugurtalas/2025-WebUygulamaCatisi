using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using MVC.Filters;
using MVC.Middlewares;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "Oturum";
        options.LoginPath = "/oturum/loginac";
        options.AccessDeniedPath = "/Home/Index";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    });


builder.Services.AddMemoryCache();
builder.Services.AddScoped<LogActionFilter>();
builder.Services.AddScoped<MaskelemeResultFilter> ();


var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
   
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.UseErrorHandlerMiddleware();
app.UsePerformanceMeterMiddleware();
app.UseRateLimitMiddleware();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
