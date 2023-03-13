using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using RazorPagesUser.Models;
using RazorPagesUser.Services;

namespace RazorPagesUser.Pages
{
    public class KatiesButtonModel : PageModel
    {   
        public List<User> users = new();


        public void OnGet()
        {
            //users = UserService.GetAll();
            
            
            
        }

        public void OnPost(string nlocation)
        {
            
            UserService userService = new UserService();
            users = userService.GetList(nlocation);
        }

        
    }

}
