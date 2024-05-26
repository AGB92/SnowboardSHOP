using Microsoft.AspNetCore.Mvc;
using SNB_SHOP_DB.Models;
using SNB_SHOP_DB.Repository;
using System.CodeDom;

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
            var productList =await _manager.GetProducts();
            return View(productList);
        }

        [HttpGet]
        public IActionResult Add() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add (ProductModel product)
        {
            try 
            {
                await _manager.AddProductAsync(product);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View(product);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Remove(int id) 
        {
            var productToDelete =await _manager.GetProduct(id);
            if(productToDelete != null) 
            {
				return View(productToDelete);
			}
            else 
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveConfirm(int id)
        {
            try 
            {
                await _manager.RemoveProduct(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Remove", id);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var filmToEdit = await _manager.GetProduct(id);
            if(filmToEdit != null)
            {
				return View(filmToEdit);
			}
            else 
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductModel product) 
        {
            await _manager.UpdateProduct(product);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var product=await _manager.GetProduct(id);
            return View(product);
        }
    }
}
