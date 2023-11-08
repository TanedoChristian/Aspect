using Microsoft.AspNetCore.Components;

namespace AspectUI.Components
{
    public partial class EmptyCart
    {
        [Parameter]
        public string Message {  get; set; }


        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }
    }
}
