using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesUser.Services;
using RazorPagesUser.Models;

namespace RazorPagesScheduleAppointment.Pages
{
    public class ScheduleAppointmentModel : PageModel
    {

        public User theUser;
        public void OnGet()
        {
            string id = Request.Query["id"];

            UserService userService = new UserService();
            theUser = userService.Get(id);
        }
    }
}
