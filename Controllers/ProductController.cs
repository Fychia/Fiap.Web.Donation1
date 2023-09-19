using Fiap.Web.Donation1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.Donation1.Controllers;

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
        //ViewBag.Product = products;
        //TempData["Product"] = products;

        return View(products);
    }

    [HttpGet]
    public IActionResult NewProduct()
    {
        return View(new ModelProduct());
    }

    [HttpPost]
    public IActionResult NewProduct(ModelProduct modelProduct)
    {
        //ViewBag.Message = $"Produto registrado com sucesso";
        //ViewBag.Products = products;
        //return View("Index");
        if (string.IsNullOrEmpty(modelProduct.ProductName))
        {
            ViewBag.Message = "O campo nome é requerido";
            return View(modelProduct);
        }
        else
        {
            TempData["Message"] = "Produto registrado com sucesso";

            return RedirectToAction("Index");
        }
    }


    [HttpGet]
    public IActionResult Edit(int id)
    {
        var product = products[id - 1];

        //ViewBag.Product = product;

        return View(product);
    }

    [HttpPost]
    public IActionResult Edit(ModelProduct modelProduct)
    {
        if (string.IsNullOrEmpty(modelProduct.ProductName))
        {
            ViewBag.Message = "O campo nome é requerido";
            return View(modelProduct);
        }else
        {
            TempData["Message"] = "Produto Editado com sucesso";

            return RedirectToAction("Index");
        }
    }




    [HttpGet]
    public IActionResult NewTypeProduct()
    {
        return View(new ModelTypeProduct());
    }

    [HttpPost]
    public IActionResult NewTypeProduct(ModelTypeProduct modelTypeProduct)
    {
        if (string.IsNullOrEmpty(modelTypeProduct.TypeProductName))
        {
            ViewBag.Message = "O campo nome é requerido";
            return View(modelTypeProduct);
        }
        else
        {
            TempData["Message"] = "Tipo de Produto cadastrado com sucesso";

            return RedirectToAction("Index");
        }
    }
}
