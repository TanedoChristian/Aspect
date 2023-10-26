using AspectUI.Models;
using Microsoft.AspNetCore.Components;

namespace AspectUI.Components
{
    public partial class ProductCart
    {

        [Parameter]
        public Cart Cart { get; set; }
    }
}
