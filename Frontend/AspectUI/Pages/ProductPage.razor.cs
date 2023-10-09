using AspectUI.Components;
using AspectUI.Models;
using AspectUI.Services.ProductService;
using Microsoft.AspNetCore.Components;

namespace AspectUI.Pages
{
    public partial class ProductPage
    {
        [Parameter]
        public string Id {  get; set; }


        public Product Product { get; set; }

        [Inject]
        public IProductService _productService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadProduct(int.Parse(Id));
            await base.OnInitializedAsync();
        }

      
        
        private async Task LoadProduct(int id)
        {
            Product = await _productService.GetById(id);
        }



    }
}
