using Microsoft.AspNetCore.Components;
using System.Security.Principal;
using Microsoft.AspNetCore.Components;
namespace AspectUI.Components
{
    public partial class Category
    {

        [Inject]
        NavigationManager navigationManager { get; set; }

        private void Redirect(string url)
        {
            navigationManager.NavigateTo(url);
        }
    }
}
