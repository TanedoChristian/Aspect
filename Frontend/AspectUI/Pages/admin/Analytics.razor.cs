using AspectUI.Models;
using AspectUI.Services.OrderService;
using AspectUI.Services.ProductService;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace AspectUI.Pages.admin
{
	public partial class Analytics
	{


		[Inject]
		IOrderService orderService { get; set; }

		public IEnumerable<UserPayment> UserPayment { get; set; }
		public List<ChartSeries> Series { get; set; } = new List<ChartSeries>();
		public string[] XAxisLabels = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
		public string[] YAxisLabels = { "0", "5", "10", "20", "25", "30", "35", "40", "50" };

		protected override async Task OnInitializedAsync()
		{
			await LoadProducts();
		}

		private async Task LoadProducts()
		{
			UserPayment = await orderService.GetAll();

			List<int> monthlyCounts = new List<int>();

			for (int month = 1; month <= 12; month++)
			{
				int count = UserPayment
					.Where(c => c.CreatedAt.Month == month)
					.Count();

				monthlyCounts.Add(count);
			}

			Series.Add(new ChartSeries
			{
				Name = "Orders",
				Data = monthlyCounts.Select(count => (double)count).ToArray()
			});
		}

	}


	
} 
