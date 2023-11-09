using Blazored.LocalStorage;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AspectUI.Components
{
    public partial class Header
    {


        [Inject]
        ILocalStorageService localStorageService { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }

        [Inject]
        SweetAlertService Swal {  get; set; }

        public bool IsEmpty { get; set; }



        private string value = "";

        [Parameter]
        public EventCallback<string> OnSearchChange { get; set; }

      

        private async Task HandleChange(ChangeEventArgs e)
        {
            value = e.Value.ToString();
            await OnSearchChange.InvokeAsync(value);
        }


       

        protected override async Task OnInitializedAsync()
        {

          


            string type = await localStorageService.GetItemAsync<string>("type");


            
           


            if (type == null)
            {
                IsEmpty = true;
            } else
            {
                if (type == "admin")
                {
                    NavigationManager.NavigateTo("/admin/products");
                }
                IsEmpty = false;
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
