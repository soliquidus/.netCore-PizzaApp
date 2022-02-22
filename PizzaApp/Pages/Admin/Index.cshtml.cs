using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace PizzaApp.Pages.Admin
{
    public class Index : PageModel
    {
        public bool DisplayInvalidAccountMessage = false;
        private IConfiguration _iConfiguration;
        public Index(IConfiguration configuration)
        {
            this._iConfiguration = configuration;
        }
        public IActionResult OnGet()
        {
            if (HttpContext.User.Identity is {IsAuthenticated: true})
            {
                return Redirect("/Admin/Pizzas");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string username, string password, string returnUrl)
        {
           var authSection = _iConfiguration.GetSection("Auth");

           var adminLogin = authSection["AdminLogin"];
           var adminPassword = authSection["AdminPassword"];

           if (username == adminLogin && password == adminPassword)
           {
               DisplayInvalidAccountMessage = false;
               var claims = new List<Claim>()
               {
                   new Claim(ClaimTypes.Name, username)
               };
               var claimsIdentity = new ClaimsIdentity(claims, "Login");
               await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                   new ClaimsPrincipal(claimsIdentity));
               return Redirect(returnUrl ?? "/Admin/Pizzas");
           }

           DisplayInvalidAccountMessage = true;
           return Page();

        }

        public async Task<IActionResult> OnGetLogout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Admin");
        }
    }
}