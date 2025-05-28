using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserManager.Application.Auth.SignUp;

namespace UserManager.Presentation.Pages.Auth;

public class SignUpModel(IMediator mediator) : PageModel
{
    [BindProperty]
    public SignUpRequestDto user { get; set; }
    

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var result = await mediator.Send(new SignUpCommand(user));

        HttpContext.Session.SetString("Username",result.Username);

        return RedirectToPage("/Auth/Login");

    }
}   