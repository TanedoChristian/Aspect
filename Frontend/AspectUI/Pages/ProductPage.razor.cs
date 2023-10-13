using AspectUI.Components;
using AspectUI.Models;
using AspectUI.Services.ProductService;
using Microsoft.AspNetCore.Components;

namespace AspectUI.Pages
{
    public partial class ProductPage
    {
        [Parameter]
        public string Id { get; set; }
        public Product Product { get; set; }

        public string MainImage { get; set; }

        public int Quantity { get; set; } = 1;

       


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
            MainImage = Product.Photos[0].PhotoUrl;

        }

        private void ChangeMainImage(string photo)
        {

            MainImage = photo;
        }

        private void HandleQuantity(string action)
        {
            if(action == "increase")
            {
                Quantity++;
            } else
            {
                Quantity--;
            }
        }


    }
}
