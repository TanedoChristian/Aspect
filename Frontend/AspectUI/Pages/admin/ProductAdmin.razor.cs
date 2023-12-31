﻿using AspectUI.Dto;
using AspectUI.Models;
using AspectUI.Services.ProductService;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
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

   

        [Inject]
        private SweetAlertService Swal { get; set; }

        public IEnumerable<Product> Products { get; set; }


        public IEnumerable<Product> FilteredProducts { get; set; }

        public ProductDto Product { get; set; } = new ProductDto();


        public Product ProductUpdate { get; set; } = new Product();

        private  List<IBrowserFile> selectedFiles = new List<IBrowserFile>();

        
        public string Category { get; set; }

        public bool ShowUpdateForm = false;





        protected override async Task OnInitializedAsync()
        {


            await LoadProductsAsync();
            await base.OnInitializedAsync();
        }

        private async Task LoadProductsAsync()
        {
            Products = await _productService.GetAll();
            FilteredProducts = Products;
        }

        public async Task HandleCategory(ChangeEventArgs e)
        {
            Category = e.Value.ToString();

            if(Category == "all")
            {
                FilteredProducts = Products;
            } else
            {
                FilteredProducts = Products.Where(c => c.Gender == Category).ToList();
            }

        }

      

        private void HandleSelection(InputFileChangeEventArgs e)
        {
            foreach (var file in e.GetMultipleFiles())
            {
                selectedFiles.Add(file);
            }
        }




        private async Task HandleSubmit()
        {

            Console.WriteLine(Product.Name);
            if(string.IsNullOrEmpty(Product.Name) || Product.Quantity == 0 || selectedFiles.Count <=0)
            {
                await Swal.FireAsync(new SweetAlertOptions()
                {
                    Title = "Incomplete Form",
                    Icon = SweetAlertIcon.Warning
                });
            } else
            {
                var content = new StringContent(
                 JsonSerializer.Serialize(Product),
                 Encoding.UTF8,
                 "application/json"
         );

                var response = await _httpClient.PostAsync("http://localhost:5140/api/Product", content);

                var responseContent = await response.Content.ReadAsStringAsync();
                var uploadResponse = JsonSerializer.Deserialize<Product>(responseContent, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                int id = uploadResponse.Id;
                var httpClient = new HttpClient();
                var formData = new MultipartFormDataContent();
                formData.Add(new StringContent(id.ToString()), "id");

                foreach (var selectedFile in selectedFiles)
                {
                    var fileStream = selectedFile.OpenReadStream();

                    var fileContent = new StreamContent(fileStream);
                    fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                    {
                        Name = "file",
                        FileName = selectedFile.Name
                    };
                    formData.Add(fileContent);
                }

                await httpClient.PostAsync("http://localhost:5140/api/Photos", formData);


                await Swal.FireAsync(new SweetAlertOptions
                {
                    Title = "Product Added",
                    Icon = SweetAlertIcon.Success,
                });

                await LoadProductsAsync();

                Product = new ProductDto();
                selectedFiles.Clear();
            }

         

         


        }

        public async Task DeleteProduct(int id)
        {
            SweetAlertResult result = await Swal.FireAsync(new SweetAlertOptions
            {
                Title = "Are you Sure?",
                Icon = SweetAlertIcon.Warning,
                ShowCancelButton = true,
                ConfirmButtonText = "Yes",
                CancelButtonText = "No"

            });


            await _productService.Delete(id);

            if (!string.IsNullOrEmpty(result.Value))
            {

               

                await Swal.FireAsync(
                  "Deleted",
                  "Product has been deleted.",
                  SweetAlertIcon.Success
                  );
            }


            await LoadProductsAsync();
        }


        public async Task ToggleUpdate(Product product)
        {
            ProductUpdate = product;
            ShowUpdateForm = true;
        }

        public void CloseModal()
        {
         
            ShowUpdateForm = false;
        }

        public async Task UpdateProduct()
        {
            await _productService.Update(ProductUpdate);

            await Swal.FireAsync(new SweetAlertOptions()
            {
                Title = "Product Updated",
                Icon = SweetAlertIcon.Success
            });

            await LoadProductsAsync();
             CloseModal();
        }

    }
}
