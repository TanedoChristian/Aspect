using AspectUI.Models;
using AspectUI.Services.ProductService;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspectUI.Pages
{
    public partial class Shop
    {
        [Inject]
        public IProductService _productService { get; set; }

        [Parameter]
        public string Category { get; set; }



        protected async Task HandleChange(string text)
        {
            if(text == "")
            {
                FilteredProducts = await _productService.GetAll();
            } else
            {
                FilteredProducts = FilteredProducts.Where(c => c.Gender.ToLower().StartsWith(text.ToLower()));
            }
        }

      
        public IEnumerable<Product> FilteredProducts { get; set; } = new List<Product>();


        protected override async Task OnParametersSetAsync()
        {
            
            await base.OnParametersSetAsync();

            if (Category != "all")
            {
                FilteredProducts = await _productService.GetAll();
                FilteredProducts = FilteredProducts
                    .Where(c => c.Gender.ToLower() == Category.ToLower())
                    .ToList();
            }
            else
            {
                FilteredProducts = await _productService.GetAll();
            }
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }
    }
}
