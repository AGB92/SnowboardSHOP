using System.IO;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
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
            try 
            {
                await _context.AddAsync(productModel);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                productModel.ID = 0;
                await _context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<ProductManager> RemoveProduct(int id)
        {
            var productToDelete=await GetProduct(id);
            if (productToDelete != null) 
            {
                 _context.Products.Remove(productToDelete);
                await _context.SaveChangesAsync();
            }
            return this;
        }

        public async Task<ProductManager> UpdateProduct(ProductModel productModel)
        {
            _context.Products.Update(productModel);
            await _context.SaveChangesAsync();
            return this;
        }

        public async Task<ProductManager> ChangeProductType1(int id, string newPType1)
        {
            var productToChangeType1 = await GetProduct(id);
            if (productToChangeType1 != null) 
            {
                productToChangeType1.Product_Type1= newPType1;
                await _context.SaveChangesAsync();
            }
            return this;
        }

        public async Task<ProductModel> GetProduct(int id)
        {
            return await _context.Products.SingleOrDefaultAsync(p=>p.ID == id);
        }

        public async Task<List<ProductModel>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }
    }
}
