using AspectUI.Models;
using AspectUI.Services.UserService;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;

namespace AspectUI.Pages
{
    public partial class Register
    {

        public User User { get; set; } = new User();

        [Inject]
        private IUserService _userService {  get; set; }

        [Inject]
        private SweetAlertService Swal {  get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }



        public async Task RegisterUser()
        {

            await _userService.Create(User);


            await Swal.FireAsync(new SweetAlertOptions
            {
                Title = "Done",
                Icon = SweetAlertIcon.Success,
            });

            NavigationManager.NavigateTo("/login");



        }
    }
}
