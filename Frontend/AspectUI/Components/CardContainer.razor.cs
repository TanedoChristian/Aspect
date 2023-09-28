using AspectUI.Models;
using AspectUI.Services.ProductService;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Text.Json;

namespace AspectUI.Components
{
    public partial class CardContainer
    {
        [Parameter]
        public IEnumerable<Product> Products { get; set; }


        protected override  async Task OnInitializedAsync()
        {
         
            
          
            await base.OnInitializedAsync();
        }



    }
}
