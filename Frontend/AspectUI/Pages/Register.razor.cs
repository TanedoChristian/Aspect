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

        IEnumerable<User> Users { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        public string Error = "";
        public string ErrorPhone = "";
        public User UserToCompare { get; set; }
        public User UserToComparePhone { get; set; }


        protected override async Task OnInitializedAsync()
        {
            Users = await _userService.GetAll();
            await base.OnInitializedAsync();
        }

        public async Task RegisterUser()
        {


            if(string.IsNullOrEmpty(User.FirstName) || string.IsNullOrEmpty(User.LastName) || string.IsNullOrEmpty(User.Email) || string.IsNullOrEmpty(User.Username) || string.IsNullOrEmpty(User.Street) || string.IsNullOrEmpty(User.Phone))
            {
                await Swal.FireAsync(new SweetAlertOptions
                {
                    Title = "Incomplete Form",
                    Icon = SweetAlertIcon.Warning,
                });
            } else
            {
                UserToCompare = Users.FirstOrDefault(user => user.Email == User.Email);
                UserToComparePhone = Users.FirstOrDefault(user => user.Phone == User.Phone);

                if (UserToComparePhone != null)
                {
                    ErrorPhone = "Phone Number is already in use";
                }
                else if (UserToCompare != null)
                {
                    Error = "Email address is already in use";
                }
                else
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

         

    }
}
