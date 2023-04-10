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

        public void OnPost(string nlocation, string ncnumber, string ncdate, string nccvv, string mondayStart, string mondayEnd, string tuesdayStart, string tuesdayEnd,
                   string wednesdayStart, string wednesdayEnd, string thursdayStart, string thursdayEnd,
                   string fridayStart, string fridayEnd, string saturdayStart, string saturdayEnd,
                   string sundayStart, string sundayEnd)
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

                    
                    if (ncnumber != null && ncnumber != "")
                    {
                        theUser.cnumber = ncnumber;
                        userService.Update(theUser.username, theUser);
                    }

                    
                    if (ncdate != null && ncdate!= "")
                    {
                        theUser.cdate = ncdate;
                        userService.Update(theUser.username, theUser);
                    }

                    
                    if (nccvv != null && nccvv != "")
                    {
                        theUser.ccvv = nccvv;
                        userService.Update(theUser.username, theUser);
                    }

                    if (mondayStart != null && mondayStart != "")
                    {
                        theUser.mondayStart = TimeSpan.Parse(mondayStart);
                        userService.Update(theUser.username, theUser);
                    }

                    if (mondayEnd != null && mondayEnd != "")
                    {
                        theUser.mondayEnd = TimeSpan.Parse(mondayEnd);
                        userService.Update(theUser.username, theUser);
                    }

                    if (tuesdayStart != null && tuesdayStart != "")
                    {
                        theUser.tuesdayStart = TimeSpan.Parse(tuesdayStart);
                        userService.Update(theUser.username, theUser);
                    }

                    if (tuesdayEnd != null && tuesdayEnd != "")
                    {
                        theUser.tuesdayEnd = TimeSpan.Parse(tuesdayEnd);
                        userService.Update(theUser.username, theUser);
                    }

                    if (wednesdayStart != null && wednesdayStart != "")
                    {
                        theUser.wednesdayStart = TimeSpan.Parse(wednesdayStart);
                        userService.Update(theUser.username, theUser);
                    }

                    if (wednesdayEnd != null && wednesdayEnd != "")
                    {
                        theUser.wednesdayEnd = TimeSpan.Parse(wednesdayEnd);
                        userService.Update(theUser.username, theUser);
                    }

                    if (thursdayStart != null && thursdayStart != "")
                    {
                        theUser.thursdayStart = TimeSpan.Parse(thursdayStart);
                        userService.Update(theUser.username, theUser);
                    }

                    if (thursdayEnd != null && thursdayEnd != "")
                    {
                        theUser.thursdayEnd = TimeSpan.Parse(thursdayEnd);
                        userService.Update(theUser.username, theUser);
                    }

                    if (fridayStart != null && fridayStart != "")
                    {
                        theUser.fridayStart = TimeSpan.Parse(fridayStart);
                        userService.Update(theUser.username, theUser);
                    }

                    if (fridayEnd != null && fridayEnd != "")
                    {
                        theUser.fridayEnd = TimeSpan.Parse(fridayEnd);
                        userService.Update(theUser.username, theUser);
                    }

                    if (saturdayStart != null && saturdayStart != "")
                    {
                        theUser.saturdayStart = TimeSpan.Parse(saturdayStart);
                        userService.Update(theUser.username, theUser);
                    }

                    if (saturdayEnd != null && saturdayEnd != "")
                    {
                        theUser.saturdayEnd = TimeSpan.Parse(saturdayEnd);
                        userService.Update(theUser.username, theUser);
                    }

                    if (sundayStart != null && sundayStart != "")
                    {
                        theUser.sundayStart = TimeSpan.Parse(sundayStart);
                        userService.Update(theUser.username, theUser);
                    }

                    if (sundayEnd != null && sundayEnd != "")
                    {
                        theUser.sundayEnd = TimeSpan.Parse(sundayEnd);
                        userService.Update(theUser.username, theUser);
                    }
                }
            }
        }
    }
}
