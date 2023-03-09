using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesDemo.Pages
{
    public class ContactMeModel : PageModel
    {
        [BindProperty]
        public string ContactName { get; set; }
        [BindProperty]
        public string ContactEmail { get; set; }
        [BindProperty]
        public string ContactComments { get; set; }
        [BindProperty]
        public void OnGet()
        {
        }
    }
}
