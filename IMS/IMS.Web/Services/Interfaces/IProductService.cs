using IMS.Web.DataAccess.Entities;

namespace IMS.Web.Services.Interfaces
{
    public interface IProductService
    {
        public Task<List<Product>> GetAllProducts();
        public Task<Product> GetProductById(int id);
    }
}
