using IMS.Web.DataAccess;
using IMS.Web.DataAccess.Entities;
using IMS.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IMS.Web.API
{
    [Route("ims/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly InventoryDbContext _context;

        public ProductController(InventoryDbContext context)
        {
            _context = context;
        }

        //public ActionResult  { }

        [Authorize]
        [HttpPost("new")]
        public IActionResult AddProduct(ProductViewModel product)
        {
            var _productExist = _context.Products.FirstOrDefault(p => p.Name == product.Name);

            if (_productExist != null)
            {
                return BadRequest("Product exists");
            }

            var newProduct = new Product 
            { 
                Name = product.Name,
                Description = product.Description,
                PurchasePrice = product.PurchasePrice,
                SellingPrice = product.SellingPrice,
                DateAdded =DateTime.Now,
                Stock = product.Stock
            };

            _context.Products.Add(newProduct);
            _context.SaveChanges();

            return StatusCode(StatusCodes.Status201Created); 
        }
    }
}
