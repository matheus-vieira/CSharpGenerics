using Generics.Models.Ecommerce;
using Microsoft.EntityFrameworkCore;

namespace Generics.Data
{
    public partial class ApplicationDbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sell> Sells { get; set; }
        public DbSet<SellItem> SellItems { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
    }
}
