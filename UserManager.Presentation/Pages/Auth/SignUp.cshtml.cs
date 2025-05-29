using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Npgsql;
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


        try
        {
            var result = await mediator.Send(new SignUpCommand(user));

            HttpContext.Session.SetString("Username", result.Username);

            return RedirectToPage("/Auth/Login");
        }
        catch (PostgresException ex) when (ex.SqlState == "23505" && ex.ConstraintName == "IX_Users_Email")
        {
            ModelState.AddModelError("User.Email", "Bu email allaqachon ro'yxatdan o'tgan!");
            return Page();
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", "Xatolik yuz berdi. Iltimos, qayta urinib ko'ring.");
            return Page();
        }




    }
}   