using Microsoft.AspNetCore.Mvc;

namespace SNB_SHOP_DB.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
