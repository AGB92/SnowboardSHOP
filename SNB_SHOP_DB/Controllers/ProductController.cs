using Microsoft.AspNetCore.Mvc;
using SNB_SHOP_DB.Models;
using SNB_SHOP_DB.Repository;

namespace SNB_SHOP_DB.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductManager _manager;
        public ProductController(ProductManager manager)
        {
            _manager = manager;
        }

        public async Task<IActionResult> Index()
        {
            var product = new ProductModel()
            {
                Product_Type1 = "Odzież",
                Product_Type2="Spodnie",
                Sex="F",
                Brand="Nitro",
                Model="M1",
                Size="M",
                Stock=4,
                Price=1099.99
            };

            await _manager.AddProductAsync(product);
            return View();
        }
    }
}
