using AspectUI.Dto;
using AspectUI.Models;
using AspectUI.Services.ProductService;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace AspectUI.Pages.admin
{
    public partial class ProductAdmin
    {
        [Inject]
        public IProductService _productService { get; set; }

        [Inject]
        HttpClient _httpClient { get; set; }

        IBrowserFile selectedFile;

        [Inject]
        private SweetAlertService Swal { get; set; }

        public IEnumerable<Product> Products { get; set; }

        public ProductDto Product { get; set; } = new ProductDto();

        

        protected override async Task OnInitializedAsync()
        {


            await LoadProductsAsync();

            await base.OnInitializedAsync();
        }

        private async Task LoadProductsAsync()
        {
            Products = await _productService.GetAll();
        }

      

        private void HandleSelection(InputFileChangeEventArgs eventArgs)
        {
            selectedFile = eventArgs.GetMultipleFiles().FirstOrDefault();
        }




        private async Task HandleSubmit()
        {

            var content = new StringContent(
                   JsonSerializer.Serialize(Product),
                   Encoding.UTF8,
                   "application/json"
               );
            var response = await _httpClient.PostAsync("http://localhost:5140/api/Product", content);

            var responseContent = await response.Content.ReadAsStringAsync();
            var uploadResponse = JsonSerializer.Deserialize<Product>(responseContent, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            if (selectedFile != null)
            {
                var formData = new MultipartFormDataContent();
                formData.Add(new StreamContent(selectedFile.OpenReadStream(selectedFile.Size)), "file", selectedFile.Name);
                formData.Add(new StringContent(uploadResponse.Id.ToString()), "id");

                var httpClient = new HttpClient();
                await _httpClient.PostAsync("http://localhost:5140/api/Photos", formData);

                await Swal.FireAsync(new SweetAlertOptions
                {
                    Title = "Product Added",
                    Icon = SweetAlertIcon.Success,
                });
            }

            Product = new ProductDto();
            selectedFile = null;

            await LoadProductsAsync();
           
        }

    }
}
