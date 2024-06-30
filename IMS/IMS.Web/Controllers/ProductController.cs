using IMS.Web.DataAccess;
using IMS.Web.DataAccess.Entities;
using IMS.Web.Models;
using IMS.Web.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productServices;

        public ProductController(IProductService productService)
        {
            _productServices = productService;
        }

        // GET: ProductController
        public async Task<IActionResult> Index()
        {
            var products = await _productServices.GetAllProducts();

            var vm = new ProductViewModel();

            vm.Products = products;
            
            return View(vm);
        }

        // GET: ProductController/Create
        public async Task<IActionResult> Create()
        {
            var products = await _productServices.GetAllProducts();

            var vm = new ProductViewModel();

            vm.Products = products;

            return View(vm);
        }

        // POST: ProductController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel model)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        [HttpGet]
        public ActionResult Edit(int Id, string Name)
        {
            TempData["id"] = Id;
            TempData["name"] = Name;
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
