using System.Collections;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserManager.Application.UserMediator.DeleteUser;
using UserManager.Application.UserMediator.GetUsers;

namespace UserManager.Presentation.Pages.Users
{
    public class UsersPageModel(IMediator mediator) : PageModel, IEnumerable
    {


      
        public IList<UserDto> Users { get; set; }

        public async Task OnGetAsync()
        {

            Users = await mediator.Send(new GetUsersQuery());

        }

        public async Task<IActionResult> OnPostDeleteSelectedAsync([FromForm] int[] selectedUserIds)
        {
            foreach (var id in selectedUserIds)
            {
                await mediator.Send(new DeleteUserCommand(id));
            }

            return RedirectToPage();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
