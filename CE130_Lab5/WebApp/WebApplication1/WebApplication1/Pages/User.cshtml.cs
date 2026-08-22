using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages;

public class UserModel : PageModel
{
    [BindProperty]
    public string Name { get; set; }

    [BindProperty]
    public string Email { get; set; }

    [BindProperty]
    public string Contact { get; set; }

    [BindProperty]
    public string Gender { get; set; }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        HttpContext.Session.SetString("Name", Name);
        HttpContext.Session.SetString("Email", Email);
        HttpContext.Session.SetString("Contact", Contact);
        HttpContext.Session.SetString("Gender", Gender);

        return RedirectToPage("/Result");
    }
}