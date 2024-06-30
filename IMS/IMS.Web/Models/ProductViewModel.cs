using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using IMS.Web.DataAccess.Entities;

namespace IMS.Web.Models
{
    public class ProductViewModel
    {

        public int Id{ get; set; }

        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public decimal PurchasePrice { get; set; }
        
        public decimal SellingPrice { get; set; }
        
        public int Stock { get; set; }

        //Collection / List
        public List<Product>? Products { get; set; }
    }
}
