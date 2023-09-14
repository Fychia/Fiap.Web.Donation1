using Fiap.Web.Donation1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.Donation1.Controllers
{
    public class ProductController : Controller
    {
        private List<ModelProduct> products;

        public ProductController()
        {
            products = new List<ModelProduct>{

                new ModelProduct()
                {
                    ProductID = 1,
                    ProductName = "Test",
                    ProductType = 1,
                    ProductAvailable = true,
                    ExpirationDate = DateTime.Now,
                },
                new ModelProduct()
                {
                    ProductID = 2,
                    ProductName = "Test",
                    ProductType = 1,
                    ProductAvailable = true,
                    ExpirationDate = DateTime.Now,
                },
                new ModelProduct()
                {
                    ProductID = 3,
                    ProductName = "Test",
                    ProductType = 1,
                    ProductAvailable = true,
                    ExpirationDate = DateTime.Now,
                },
                new ModelProduct()
                {
                    ProductID = 4,
                    ProductName = "Test",
                    ProductType = 1,
                    ProductAvailable = true,
                    ExpirationDate = DateTime.Now,
                },
            };

        }

        [HttpGet]
        public IActionResult Index()
        {

            ViewBag.Product = products;
            //TempData["Product"] = products;
            return View();
        }

        [HttpGet]
        public IActionResult NewProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitProduct(ModelProduct modelProduct)
        {
            //ViewBag.Message = $"Produto registrado com sucesso";
            //ViewBag.Products = products;
            //return View("Index");

            TempData["Message"] = $"Produto registrado com sucesso";
            
            return RedirectToAction("Index");
        }

    }
}
