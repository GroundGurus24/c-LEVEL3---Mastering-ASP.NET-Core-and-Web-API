using IMS.Web.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace IMS.Web.DataAccess
{
    public static class DatabaseSeeding
    {
        public static void InitializeData(IServiceProvider serviceProvider) {
            using (var context = new InventoryDbContext(serviceProvider.GetRequiredService<
                DbContextOptions<InventoryDbContext>>()))
            {
                if (context.Products.Any()) {
                    return;
                }

                context.Products.AddRange(
                    new Product { 
                        DateAdded = DateTime.Now,
                        Description = "Electronics",
                        Name = "Samsung Galaxy",
                        PurchasePrice = 45000.50m,
                        SellingPrice = 49000.34m,
                        Stock = 10
                    },
                    new Product {
                        DateAdded = DateTime.Now,
                        Description = "Electronics",
                        Name = "Samsung Inverter AC",
                        PurchasePrice = 4000.50m,
                        SellingPrice = 6000.34m,
                        Stock = 30
                    },
                    new Product{
                        DateAdded = DateTime.Now,
                        Description = "Electronics",
                        Name = "GoPro",
                        PurchasePrice = 5000.50m,
                        SellingPrice = 9000.34m,
                        Stock = 20
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
