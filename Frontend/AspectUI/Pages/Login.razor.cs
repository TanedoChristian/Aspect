using AspectUI.Models;
using AspectUI.Services.UserService;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;

namespace AspectUI.Pages
{
    public partial class Login
    {
        public string Email {  get; set; }
        public string Password { get; set; }

        [Inject]
        ILocalStorageService localStorageService { get; set; }

        public string Error = "";


        [Inject]
        public NavigationManager NavigationManager { get; set; }
        
        [Inject]

        private IUserService _userService {  get; set; }

        public async Task LoginUser()
        {
            var user = await _userService.Login(Email, Password);

            if (user == null)
            {
                Error = "Wrong Credentials";
            }
            else
            {

                if(user.Type == "admin")
                {
                    NavigationManager.NavigateTo("/admin/products");
                    await localStorageService.SetItemAsync<string>("type", user.Type);
                } else
                {
                    await localStorageService.SetItemAsync<string>("type", user.Type);
                    await localStorageService.SetItemAsync<string>("user", user.FirstName);
                    await localStorageService.SetItemAsync<string>("username", user.Username);
                    await localStorageService.SetItemAsync<int>("userid", user.Id);
                    NavigationManager.NavigateTo("/shop/all");
                }

                
            }


        }

    }
}

      

    

