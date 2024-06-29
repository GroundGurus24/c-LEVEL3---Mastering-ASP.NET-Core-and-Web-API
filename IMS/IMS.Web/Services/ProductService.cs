using IMS.Web.DataAccess.Entities;
using IMS.Web.Repository.Interfaces;
using IMS.Web.Services.Interfaces;

namespace IMS.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            try
            {
                return await _productRepository.GetAll();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
            
        }

        public async Task<Product> GetProductById(int id)
        {
            try
            {
                return await _productRepository.GetById(id);
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
            
        }

    }
}
