using System.Collections;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
