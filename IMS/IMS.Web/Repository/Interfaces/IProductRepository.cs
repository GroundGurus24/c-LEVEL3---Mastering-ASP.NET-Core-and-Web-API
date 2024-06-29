using IMS.Web.DataAccess.Entities;

namespace IMS.Web.Repository.Interfaces
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetAll();

        public Task<Product> GetById(int id);
    }
}
