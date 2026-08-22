using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages;

public class ResultModel : PageModel
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Contact { get; set; }
    public string Gender { get; set; }

    public void OnGet()
    {
        Name = HttpContext.Session.GetString("Name");
        Email = HttpContext.Session.GetString("Email");
        Contact = HttpContext.Session.GetString("Contact");
        Gender = HttpContext.Session.GetString("Gender");
    }
}