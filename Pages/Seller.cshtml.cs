using Microsoft.AspNetCore.Mvc;
using RazorPagesUser.Models;
using RazorPagesUser.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesSeller.Pages
{
    public class SellerModel : PageModel
    {
        public void OnGet()
        {

        }
        public IActionResult OnPost(string username, string password)
        {
            UserService userService = new UserService();
            if(userService.LogIn(username, password)){

                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                var random = new Random();
                var theString = new string(Enumerable.Repeat(chars, 50)
                  .Select(s => s[random.Next(s.Length)]).ToArray());

                Response.Cookies.Append("sessionCookie", theString, new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddMinutes(30),
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict
                });

                userService.CreateLoginSession(theString, username, password);


                return RedirectToPage("/UpdateInformation");
            }
            return Page();
        }
    }


}
