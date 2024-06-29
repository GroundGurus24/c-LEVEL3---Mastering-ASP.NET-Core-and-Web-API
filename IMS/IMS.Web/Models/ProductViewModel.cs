using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using IMS.Web.DataAccess.Entities;

namespace IMS.Web.Models
{
    public class ProductViewModel
    {
        public List<Product> Products { get; set; }
    }
}
