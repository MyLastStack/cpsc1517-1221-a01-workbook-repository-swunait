using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesDemo.Pages
{
    public class ContactMeModel : PageModel
    {
        [BindProperty]
        public string? ContactName { get; set; }
        [BindProperty]
        public string? ContactEmail { get; set; }
        [BindProperty]
        public string? ContactComments { get; set; }
        [BindProperty]
        public Boolean SubscribeToMail { get; set; } = true;
        public string InfoMessage { get; set; }
        public string ErrorMessage { get; set; }
        public void OnPostSendMessage()
        {
            string subscribetomail = (SubscribeToMail == true) ? "Yes" : "No";
            InfoMessage = $"Name: {ContactName} <br />" +
                $"Email: {ContactEmail} <br />" +
                $"Comments: {ContactComments} <br />" +
                $"Subscribe to mail: {subscribetomail}";
        }

        public IActionResult OnPostClear()
        {
            ContactName = null;
            ContactEmail = null;
            ContactComments = null;
            SubscribeToMail = false;
            return RedirectToPage();
        }

        public void OnGet()
        {
        }
    }
}
