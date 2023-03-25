using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesUser.Models;
using RazorPagesUser.Services;

namespace TheCleaningLadies.Pages
{
    public class CreateAccountModel : PageModel
    {
        [TempData]
        public string? StatusMessage { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost(string username, string password)
        {
            UserService userService = new UserService();
            if (userService.CreateAccount(username, password)) {
                return RedirectToPage("/LoginOut");
            }
            else {
                return Page();
            }
        }
    }
}
