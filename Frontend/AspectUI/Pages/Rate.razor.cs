using AspectUI.Models;
using AspectUI.Services.CartService;
using AspectUI.Services.ProductService;
using AspectUI.Services.ReviewService;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;

namespace AspectUI.Pages
{
    public partial class Rate
    {

        [Inject]
        ICartService cartService { get; set; }

        [Inject]
        ILocalStorageService localStorageService { get; set; }
        IEnumerable<Cart> Carts { get; set; }


        [Inject]
        IProductService productService {  get; set; }

        public Product Product { get; set; }

        public bool ShowReviewModal = false;


        [Inject]
        IReviewService reviewService { get; set; }

        public IEnumerable<ProductReview> ProductReview { get; set; }

       




        protected override async Task OnInitializedAsync()
        {
            await LoadCarts();
            await base.OnInitializedAsync();
        }

        public async Task LoadCarts()
        {
            int userid = await localStorageService.GetItemAsync<int>("userid");
            Carts = await cartService.GetAllByUser(userid);
            Carts = Carts.Where(c => c.Status.ToLower() == "done").ToList();
        }



        public async Task  ToggleModal(int id)
        {
            Product = await productService.GetById(id);
            ShowReviewModal = true;
        }
    }
}
