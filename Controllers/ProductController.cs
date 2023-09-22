using Fiap.Web.Donation1.Data;
using Fiap.Web.Donation1.Models;
using Fiap.Web.Donation1.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Drawing.Text;

namespace Fiap.Web.Donation1.Controllers;

public class ProductController : Controller
{
    //private List<ModelProduct> products;
    private readonly ProductRepository productRepository;
    private readonly TypeProductRepository typeProductRepository;

    private readonly int UserID = 1;
    public ProductController(DataContext dataContext)
    {
        productRepository = new ProductRepository(dataContext);
        typeProductRepository = new TypeProductRepository(dataContext);

        
    }

    [HttpGet]
    public IActionResult Index()
    {
        //ViewBag.Product = products;
        //TempData["Product"] = products;
        var products = productRepository.FindAllWithType();

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
            modelProduct.UserID = 1;
            productRepository.Insert(modelProduct);
            
            TempData["Message"] = "Produto registrado com sucesso";

            return RedirectToAction("Index");
        }
    }


    [HttpGet]
    public IActionResult Edit(int id)
    {
        TypeProductCombo();

        var product = productRepository.FindById(id);
        //var product = products[id - 1];
        //ViewBag.Product = product;

        return View(product);
    }

    [HttpPost]
    public IActionResult Edit(ModelProduct modelProduct)
    {
        if (string.IsNullOrEmpty(modelProduct.ProductName))
        {
            TypeProductCombo();

            ViewBag.Message = "O campo nome é requerido";
            return View(modelProduct);
        }else
        {
            modelProduct.UserID = 1;
            productRepository.Update(modelProduct);
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

    private void TypeProductCombo()
    {
        var typeProducts = typeProductRepository.FindAll();

        var typeProductCombo = new SelectList(typeProducts, "TypeProductID", "TypeProductName");

        ViewBag.TypeProduct = typeProductCombo;
    }
}
