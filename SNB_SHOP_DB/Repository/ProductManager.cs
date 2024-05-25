using System.IO;
using SNB_SHOP_DB.Data;
using SNB_SHOP_DB.Models;

namespace SNB_SHOP_DB.Repository
{
    public class ProductManager
    {
        private readonly ApplicationDbContext _context;

        public ProductManager(ApplicationDbContext context) 
        {
            _context = context; 
        }
        public async Task<bool> AddProductAsync(ProductModel productModel)
        {
            await _context.AddAsync(productModel);
            await _context.SaveChangesAsync();
            return true;
        }

        public ProductManager RemoveProduct(int id)
        {
            return this;
        }

        public ProductManager UpdateProduct(ProductModel productModel)
        {
            return this;
        }
        //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        public ProductManager ChangeTitle(int id, string newTitle)
        {
            return this;
        }
        //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        public ProductManager GetProduct(int id)
        {
            return null;
        }

        public List<ProductModel> GetProducts()
        {
            return null;
        }
    }
}
