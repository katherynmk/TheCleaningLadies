using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesUser.Services;

namespace TheCleaningLadies.Pages
{
    public class LoginOutModel : PageModel
    {
        public IActionResult OnGet()
        {
            UserService userService = new UserService();
            string cookieValue = Request.Cookies["sessionCookie"];
            if (cookieValue != null)
            {
                if (userService.CheckCookie(cookieValue))
                {
                    Response.Cookies.Delete("sessionCookie");
                    userService.LogOut(cookieValue);
                    return RedirectToPage("/Index");
                }
            }
            return RedirectToPage("/Seller");
        }
    }
}
