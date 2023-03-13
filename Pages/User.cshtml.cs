using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using RazorPagesUser.Models;
using RazorPagesUser.Services;

namespace RazorPagesUser.Pages
{
    public class UserModel : PageModel
    {
        public List<User> users = new();

        [BindProperty]
        public User NewUser { get; set; } = new();

        public void OnGet()
        {
            //users = UserService.GetAll();
            UserService userService = new UserService();

            //NewUser = userService.Get("Test");
            users = userService.GetList("palos");
        }

        public IActionResult OnPost(string nusername, string npassword, string nlocation)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            User addUser = new User(){
                username = nusername,
                password = npassword,
                location = nlocation
            };
            UserService userService = new UserService();
            userService.Create(addUser);
            return RedirectToAction("Get");
        }

        public IActionResult OnPostDelete(string username)
        {
            return RedirectToAction("Get");
        }
    }

}
