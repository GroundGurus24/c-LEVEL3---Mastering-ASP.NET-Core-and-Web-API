using IMS.Web.DataAccess;
using IMS.Web.DataAccess.Entities;
using IMS.Web.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IMS.Web.Repository
{
    public class ProductRepository: IProductRepository
    {
        private readonly InventoryDbContext _dbContext;

        public ProductRepository(InventoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Product>> GetAll()
        {
            try
            {
                return await _dbContext.Products.ToListAsync();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
            
        }

        public async Task<Product> GetById(int id)
        {
            try
            {
                return await _dbContext.Products.FindAsync(id);
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
            
        }
    }
}
