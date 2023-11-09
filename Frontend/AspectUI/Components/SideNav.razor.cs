using Blazored.LocalStorage;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
namespace AspectUI.Components
{
	public partial class SideNav
	{
		[Inject]
		ILocalStorageService localStorageService { get; set; }
		[Inject]
		NavigationManager NavigationManager { get; set; }

		[Inject]
		SweetAlertService Swal { get; set; }


        protected override async Task OnInitializedAsync()
        {




            string type = await localStorageService.GetItemAsync<string>("type");

            if (type != "admin")
            {
                NavigationManager.NavigateTo("/shop/all");
            }
            


            await base.OnInitializedAsync();
        }

        public async Task HandleLogin()
		{
			string type = await localStorageService.GetItemAsync<string>("type");

			if (type == null)
			{
				NavigationManager.NavigateTo("/login");
			}
			else
			{
				SweetAlertResult result = await Swal.FireAsync(new SweetAlertOptions
				{
					Title = "Logout?",
					Icon = SweetAlertIcon.Warning,
					ShowCancelButton = true,
					ConfirmButtonText = "Yes",
					CancelButtonText = "No"

				});

				if (!string.IsNullOrEmpty(result.Value))
				{
					await localStorageService.ClearAsync();
					NavigationManager.NavigateTo("/");
				}

			}
		}
	}
}