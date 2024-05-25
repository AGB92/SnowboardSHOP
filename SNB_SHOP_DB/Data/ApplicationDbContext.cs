using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SNB_SHOP_DB.Models;

namespace SNB_SHOP_DB.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<ProductModel> Products { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
