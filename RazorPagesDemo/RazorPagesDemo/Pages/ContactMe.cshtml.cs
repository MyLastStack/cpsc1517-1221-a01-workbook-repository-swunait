using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Net.Mail;

namespace RazorPagesDemo.Pages
{
    public class ContactMeModel : PageModel
    {
        private readonly IConfiguration Configuration;

        public ContactMeModel(IConfiguration configuration)
        {
            Configuration = configuration;
        }

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

            SmtpClient sendMailClient = new();
            sendMailClient.Host = Configuration["SmtpHost"];
            sendMailClient.Port = int.Parse(Configuration["Port"]);
            sendMailClient.EnableSsl = bool.Parse(Configuration["EnableSsl"]);

            NetworkCredential mailCredential = new();
            mailCredential.UserName = Configuration["Username"];
            mailCredential.Password = Configuration["AppPassword"];
            sendMailClient.Credentials = mailCredential;

            string mailToAddress = ContactEmail;
            string mailFromAddress = Configuration["Email"];

            MailMessage mailMessage = new MailMessage(mailFromAddress, mailToAddress);
            mailMessage.Subject = "CPSC1517 new contact me form submission";
            mailMessage.Body = InfoMessage;

            try
            {
                sendMailClient.Send(mailMessage);
                ContactName = null;
                ContactEmail = null;
                ContactComments = null;
                InfoMessage = "Your message has been sent";
                SubscribeToMail = true;
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Error sending mail with exception: {ex.Message}";
            }
        }

        public IActionResult OnPostClear()
        {
            ContactName = null;
            ContactEmail = null;
            ContactComments = null;
            SubscribeToMail = true;
            return RedirectToPage();
        }

        public void OnGet()
        {
        }
    }
}
