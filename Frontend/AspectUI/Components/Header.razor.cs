using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace AspectUI.Components
{
    public partial class Header
    {
       


        public bool IsEmpty { get; set; } = false;

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
           

            await base.OnInitializedAsync();
        }
    }
}
