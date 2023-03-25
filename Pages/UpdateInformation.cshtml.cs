using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesUser.Models;
using RazorPagesUser.Services;

namespace TheCleaningLadies.Pages
{
    public class UpdateInformation : PageModel
    {
        [BindProperty]
        public User theUser { get; set; } = new();

        public IActionResult OnGet()
        {
            UserService userService = new UserService();
            string? cookieValue = Request.Cookies["sessionCookie"];

            if (cookieValue != null)
            {
                if (userService.CheckCookie(cookieValue))
                {
                    theUser = userService.GetUserBySessionID(cookieValue);
                    return Page();
                }
            }
            return RedirectToPage("/Seller");
        }

        public void OnPost(string nlocation)
        {

            UserService userService = new UserService();
            string? cookieValue = Request.Cookies["sessionCookie"];

            if (cookieValue != null)
            {
                if (userService.CheckCookie(cookieValue))
                {
                    theUser = userService.GetUserBySessionID(cookieValue);

                    if (nlocation != null && nlocation != "")
                    {
                        theUser.location = nlocation;
                        userService.Update(theUser.username, theUser);
                    }
                }
            }
        }
    }
}
