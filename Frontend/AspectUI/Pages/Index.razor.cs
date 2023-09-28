using AspectUI.Models;
using AspectUI.Services.ProductService;
using Microsoft.AspNetCore.Components;
using System.Text.Json;

namespace AspectUI.Pages
{
    public partial class Index
    {
        [Inject]
        public IProductService _productService { get; set; }

        public IEnumerable<Product> Products { get; set; }


     
        protected override async Task OnInitializedAsync()
        {

            Products = await _productService.GetAll();
            await base.OnInitializedAsync();
        }



    }
}
