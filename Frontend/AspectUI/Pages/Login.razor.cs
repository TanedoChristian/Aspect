using AspectUI.Models;
using AspectUI.Services.UserService;
using Microsoft.AspNetCore.Components;

namespace AspectUI.Pages
{
    public partial class Login
    {

        public IEnumerable<User> Users {get; set;}

        [Inject]
        public IUserService UserService { get; set; }

        protected override async Task OnInitializedAsync()
        {

            Users = await UserService.GetAll();

            await base.OnInitializedAsync();
        }

    }
}
