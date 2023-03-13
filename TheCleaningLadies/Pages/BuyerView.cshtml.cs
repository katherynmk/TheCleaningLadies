using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using RazorPagesUser.Models;
using RazorPagesUser.Services;

namespace RazorPagesUser.Pages
{
    public class BuyerViewModel : PageModel
    {   
        public List<User> users = new();


        public void OnGet()
        {
            //users = UserService.GetAll();
            
            
            //NewUser = userService.Get("Test");
            
        }

        public void OnPost(string nlocation)
        {
            
            UserService userService = new UserService();
            users = userService.GetList(nlocation);
        }

        
    }

}
